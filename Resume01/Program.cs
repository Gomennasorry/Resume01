using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Resume01;

string systemID = string.Empty;
string bearerToken = string.Empty;

var builder = WebApplication.CreateBuilder(args);

systemID = builder.Configuration["SystemID"];

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
//builder.Services.AddRazorPages();


builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    // Use the default property (Pascal) casing.
    
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


//Provide a secret key to Encrypt and Decrypt the Token
var SecretKey = Encoding.ASCII.GetBytes($"{builder.Configuration["JwtToken:SigningKey"]}");
//Configure JWT Token Authentication
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(token =>
{
    token.RequireHttpsMetadata = false;
    token.SaveToken = true;
    token.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        RequireExpirationTime = true,
        ValidIssuer = builder.Configuration["JwtToken:Issuer"],
        ValidAudience = builder.Configuration["JwtToken:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(SecretKey),
        ClockSkew = TimeSpan.Zero // remove delay of token when expire
    };
});

builder.Services.AddHttpClient("BaseClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration[$"BASEApi_{systemID}"]);

    // Add authorization if found
    if (!string.IsNullOrEmpty(bearerToken))
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
    }

});

builder.Services.AddHttpContextAccessor();



var app = builder.Build();

app.Use(async (context, next) =>
{
    if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized) // 401
    {
        //context.Response.ContentType = "application/json";
        //await context.Response.WriteAsync("StatusCode = 401, Message = Token is not valid");

        context.Response.Redirect("Home/BasicForm");
        return;
    }

    await next(context);
});



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}


//testkrirk
//app.UseFileServer();
//app.UseDefaultFiles();



app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseSession();
app.Use(async (context, next) =>
{
    //Add JWToken to all incoming HTTP Request Header
    //Must set on above JWToken Authentication service
    //bearerToken = context.Session.GetString(SESSIONID.BEAR_TOKE);
    bearerToken = context.Session.GetString("BEAR_TOKE");
    //context.Request.Headers.Add("Authorization", "Bearer " + bearerToken);
    context.Request.Headers.Append("Authorization", "Bearer " + bearerToken);

    await next.Invoke();
});



app.UseRouting();

app.UseAuthorization();

app.UseStatusCodePages(context => {
    var response = context.HttpContext.Response;
    if (response.StatusCode == (int)HttpStatusCode.Unauthorized ||
        response.StatusCode == (int)HttpStatusCode.Forbidden)
        response.Redirect("/Authen/LoginPage");
    return Task.CompletedTask;
});

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


App.SystemID = systemID.Equals("PRD") ? "PRD" : "DEV";


app.Run();
