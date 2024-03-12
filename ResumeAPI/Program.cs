using ResumeAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Authentication;
//using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
ConnectionStrings.BaseConnection = builder.Configuration.GetConnectionString("DEVDatabase");


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Use the default property (Pascal) casing.
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var SecretKey = Encoding.ASCII.GetBytes($"{builder.Configuration["JwtToken:SigningKey"]}");

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



builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
//builder.Services.AddTransient<IManifestRepository, ManifestRepository>();
//builder.Services.AddTransient<IWMSRepository, WMSRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI(); // Truckgo

    app.UseSwaggerUI(c => // Super
    {
        c.DefaultModelsExpandDepth(-1); // Disable swagger schemas at bottom
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SCGL Super App REST API V1.0");
    });
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI");
        options.RoutePrefix = string.Empty;
    });
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


//string systemID = builder.Configuration["SystemID"];
//App.BaseConnection = builder.Configuration[$"ConnectionStrings:{systemID}Database"];
////App.SystemID = "DEV";
//App.SystemID = "DEV"; // deploy ลง ASPFree ไม่ได้ ไม่อ่าน appsetting
////App.SystemID = systemID.Equals("PRD") ? "PRD" : "DEV"; // deploy ลง ASPFree ไม่ได้ ไม่อ่าน appsetting

app.Run();
