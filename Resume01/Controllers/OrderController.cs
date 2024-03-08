//using BASE.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ResumeDto;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text;

namespace Resume01.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IHttpClientFactory clientFactory;
        IConfiguration configure;
        public OrderController(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            this.clientFactory = clientFactory;
            configure = configuration;
        }

        public async Task<IActionResult> Index()
        {
            MasterItemModel SearchTerm = new MasterItemModel();
            List<MasterItemModel> shippingProviderList = new List<MasterItemModel>();

            using (var client = clientFactory.CreateClient("BaseClient"))
            {
                try
                {
                    string requestJson = JsonConvert.SerializeObject(SearchTerm);
                    HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync("Order/GetShippingProvider", httpContent);
                    if (result.IsSuccessStatusCode)
                    {
                        shippingProviderList = await result.Content.ReadAsAsync<List<MasterItemModel>>();
                    }
                    ViewBag.ShippingProviderList = shippingProviderList;
                    //ViewBag ต้องอยู่ด้านนอกเพราะถ้าอยู่ด้านในเเล้วหาไม่เจอ จะ Error ตอน Binding ที่หน้าจอ

                    //List<CustomerModel> CustomersUsers = UserInfo.CustomersUsers;
                    //if (CustomersUsers.Count() > 1)
                    //    CustomersUsers.Insert(0, new CustomerModel() { CustomerCode = "", CustomerName = "--- All ---" });

                    //ViewBag.Customers = CustomersUsers;

                    //List<CustomersMarketPlaceModel> CustomersMarketPlace = UserInfo.CustomersMarketPlace;
                    //if (CustomersMarketPlace.Count() > 1)
                    //    CustomersMarketPlace.Insert(0, new CustomersMarketPlaceModel() { UserId = UserInfo.UserId, CustomerCode = "", MarketPlace = "All", MarketPlaceName = "--- All ---" });
                    //ViewBag.CustomersMarketPlace = CustomersMarketPlace;
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            return View();
        }

        public IActionResult ReturnAdaptor()
        {
            return View();
        }
        //public async Task<IActionResult> Search(SearchOrderModel SearchTerm)
        //{          
        //    List<SalesOrderModel> wmsOrderList = new List<SalesOrderModel>();
        //    if (string.IsNullOrEmpty(SearchTerm.CustomerCode))
        //        SearchTerm.CustomerCode = string.Join(",", UserInfo.CustomersUsers.Select(c => c.CustomerCode));

        //    using (var client = clientFactory.CreateClient("BaseClient"))
        //    {
        //        try
        //        {
        //            string requestJson = JsonConvert.SerializeObject(SearchTerm);
        //            HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

        //            var response = await client.PostAsync("Order/Search", httpContent);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                //Install-Package Microsoft.AspNet.WebApi.Client
        //                wmsOrderList = await response.Content.ReadAsAsync<List<SalesOrderModel>>();
        //            }

        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine("ERROR: " + ex.Message);
        //        }
        //        return Ok(new { success = this.response.Success, message = this.response.Message, data = wmsOrderList });
        //    }
        //}

        public bool ValidateTokenWEB(string token)
        {
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes($"{configure["JwtToken:SigningKey"]}"));
            var myIssuer = configure["JwtToken:Issuer"];
            var myAudience = configure["JwtToken:Audience"];
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = myIssuer,
                    ValidAudience = myAudience,
                    IssuerSigningKey = mySecurityKey
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }

        //NOTE Order/Index > Use OrderID main ,   Detail(WMS) use DocRefNo Main
        //public async Task<PartialViewResult> PrintDeliveryOrderForm(string DocRefNoWithTrackingNo)
        //public async Task<PartialViewResult> PrintDeliveryOrderForm(string OrderIDWithTrackingNo)
        //{
        //    List<WMSOrderModel> salesOrders = new List<WMSOrderModel>();
        //    using (var client = clientFactory.CreateClient("BaseClient"))
        //    {
        //        try
        //        {
        //            //var response = await client.GetAsync("Order/GetDeliveryOrderByDocRefNo/" + DocRefNoWithTrackingNo);
        //            var response = await client.GetAsync("Order/GetDeliveryOrderByOrderID/" + OrderIDWithTrackingNo);
        //            if (response.IsSuccessStatusCode) { 
        //                salesOrders = await response.Content.ReadAsAsync<List<WMSOrderModel>>();
        //            }
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine("ERROR: " + ex.Message);
        //        }
        //        return PartialView("_DeliveryOrderFormMultiWMS", salesOrders);
        //        //return PartialView("_DeliveryOrderForm", salesOrders);
        //    }
        //}

        public IActionResult UnauthorizedPage()
        {
            return View();
        }
        public IActionResult LabelNotFound()
        {
            return View();
        }

        //NOTE Order/Index > Use OrderID main ,   Detail(WMS) use DocRefNo Main
        //public async Task<IActionResult> GetDetail(string OrderID)
        //{
        //    //SCGEXOrder scgExOrder = await orderRepo.GetOrderSCGEXById(DataOrder.DocRefNo);
        //    WMSOrderModel wmsOrder = new WMSOrderModel();

        //    using (var client = clientFactory.CreateClient("BaseClient"))
        //    {
        //        try
        //        {
        //            var response = await client.GetAsync("Order/GetById/" + OrderID);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                wmsOrder = await response.Content.ReadAsAsync<WMSOrderModel>();
        //            }
        //            else
        //            {
        //                return Ok(new { success = false, message = response.Content, data = response });
        //            }
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine("ERROR: " + ex.Message);
        //            return Ok(new { success = false, message = ex.Message, data = ex });
        //        }
        //    }
        //    return Ok(new { success = true, message = "Success", data = wmsOrder });
        //}

        //[AllowAnonymous]
        //public async Task<IActionResult> Detail(string Id, string token)
        //{
        //    bool isAuthen = ValidateTokenWEB(token);
        //    if (!isAuthen)
        //        return RedirectToAction("UnauthorizedPage", "ZOrder");

        //    HttpContext.Session.SetString(SESSIONID.BEAR_TOKE, token);

        //    MasterItemModel SearchTerm = new MasterItemModel();
        //    List<MasterItemModel> shippingProviderList = new List<MasterItemModel>();

        //    using (var client = clientFactory.CreateClient("BaseClient"))
        //    {
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //        try
        //        {
        //            WMSOrderModel orderDetail = new WMSOrderModel();

        //            if (Id != null)
        //            {
        //                var response2 = await client.GetAsync("Order/GetByDocRefNo/" + Id);
        //                if (response2.IsSuccessStatusCode)
        //                {
        //                    orderDetail = await response2.Content.ReadAsAsync<WMSOrderModel>();
        //                    if(orderDetail == null)
        //                        orderDetail = new WMSOrderModel();
        //                }
        //            }

        //            if (string.IsNullOrEmpty(orderDetail.OrderID))
        //                return RedirectToAction("UnauthorizedPage", "ZOrder");

        //            string requestJson = JsonConvert.SerializeObject(SearchTerm);
        //            HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

        //            var result = await client.PostAsync("Order/GetShippingProvider", httpContent);
        //            if (result.IsSuccessStatusCode)
        //            {
        //                shippingProviderList = await result.Content.ReadAsAsync<List<MasterItemModel>>();
        //            }
        //            ViewBag.ShippingProviderList = shippingProviderList;

        //            return View(orderDetail);
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine("ERROR: " + ex.Message);
        //            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //        }
        //    }
        //}

        //[AllowAnonymous]
        //public async Task<IActionResult> MAPSAT()
        //{
        //    MasterItemModel SearchTerm = new MasterItemModel();
        //    List<MasterItemModel> shippingProviderList = new List<MasterItemModel>();
        //    List<CustomerModel> customerList = new List<CustomerModel>();

        //    using (var client = clientFactory.CreateClient("BaseClient"))
        //    {
        //        try
        //        {
        //            string requestJson = JsonConvert.SerializeObject(SearchTerm);
        //            HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

        //            var result1 = await client.PostAsync("Order/GetShippingProvider", httpContent);
        //            if (result1.IsSuccessStatusCode)
        //            {
        //                shippingProviderList = await result1.Content.ReadAsAsync<List<MasterItemModel>>();
        //            }
        //            ViewBag.ShippingProviderList = shippingProviderList;


        //            var result2 = await client.GetAsync($"Admin/GetAllCustomer");
        //            if (result2.IsSuccessStatusCode)
        //            {
        //                customerList = await result2.Content.ReadAsAsync<List<CustomerModel>>();
        //            }
        //            ViewBag.CustomerList = customerList;


        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine("ERROR: " + ex.Message);
        //            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //        }
        //    }
        //    return View();
        //}
        //[AllowAnonymous]
        //public async Task<IActionResult> DRAGDROPTEST()
        //{
        //    MasterItemModel SearchTerm = new MasterItemModel();
        //    List<MasterItemModel> shippingProviderList = new List<MasterItemModel>();
        //    List<CustomerModel> customerList = new List<CustomerModel>();

        //    using (var client = clientFactory.CreateClient("BaseClient"))
        //    {
        //        try
        //        {
        //            string requestJson = JsonConvert.SerializeObject(SearchTerm);
        //            HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

        //            var result1 = await client.PostAsync("Order/GetShippingProvider", httpContent);
        //            if (result1.IsSuccessStatusCode)
        //            {
        //                shippingProviderList = await result1.Content.ReadAsAsync<List<MasterItemModel>>();
        //            }
        //            ViewBag.ShippingProviderList = shippingProviderList;


        //            var result2 = await client.GetAsync($"Admin/GetAllCustomer");
        //            if (result2.IsSuccessStatusCode)
        //            {
        //                customerList = await result2.Content.ReadAsAsync<List<CustomerModel>>();
        //            }
        //            ViewBag.CustomerList = customerList;


        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine("ERROR: " + ex.Message);
        //            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //        }
        //    }
        //    return View();
        //}

        //public async Task<IActionResult> ChangeAddress(WMSOrderModel DataOrder)
        //{
        //    ResponseModel responseData = new ResponseModel();
        //    using (var client = clientFactory.CreateClient("BaseClient"))
        //    {
        //        try
        //        {
        //            string requestJson = JsonConvert.SerializeObject(DataOrder);
        //            HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

        //            var result = await client.PostAsync("Order/ChangeAddress", httpContent);
        //            if (result.IsSuccessStatusCode)
        //                responseData = await result.Content.ReadAsAsync<ResponseModel>();
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine("ERROR: " + ex.Message);
        //            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //        }
        //        return Ok(new { success = responseData.Success, message = responseData.Message, data = responseData });
        //    }
        //}
        //public async Task<IActionResult> ClearAssignCarrier(WMSOrderModel DataOrder)
        //{
        //    ResponseModel responseData = new ResponseModel();
        //    string urlClearAssign = "Order/ClearAssignCarrier";
        //    if (DataOrder.ProviderCode == "FTL" || DataOrder.ProviderCode == "SCGL")
        //    {
        //        urlClearAssign = "SCGL/ClearAssignCarrier";
        //    }
        //    using (var client = clientFactory.CreateClient("BaseClient"))
        //    {
        //        try
        //        {
        //            string requestJson = JsonConvert.SerializeObject(DataOrder);
        //            HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

        //            var result = await client.PostAsync(urlClearAssign, httpContent);
        //            //var result = await client.PostAsync("Order/ClearAssignCarrier", httpContent);
        //            if (result.IsSuccessStatusCode)
        //                responseData = await result.Content.ReadAsAsync<ResponseModel>();
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine("ERROR: " + ex.Message);
        //            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //        }
        //        return Ok(new { success = responseData.Success, message = responseData.Message, data = responseData });
        //    }
        //}

        //public async Task<IActionResult> ClearTrackingLabel(WMSOrderModel DataOrder)
        //{
        //    ResponseModel responseData = new ResponseModel();
        //    using (var client = clientFactory.CreateClient("BaseClient"))
        //    {
        //        try
        //        {
        //            string requestJson = JsonConvert.SerializeObject(DataOrder);
        //            HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

        //            var result = await client.PostAsync("TrackingLabel/ClearTrackingLabel", httpContent);
        //            if (result.IsSuccessStatusCode)
        //                responseData = await result.Content.ReadAsAsync<ResponseModel>();
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine("ERROR: " + ex.Message);
        //            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //        }
        //        return Ok(new { success = responseData.Success, message = responseData.Message, data = responseData });
        //    }
        //}

        //[AllowAnonymous]
        //public async Task<IActionResult> OrderTest()
        //{
        //    MasterItemModel SearchTerm = new MasterItemModel();
        //    List<MasterItemModel> shippingProviderList = new List<MasterItemModel>();
        //    List<CustomerModel> customerList = new List<CustomerModel>();

        //    using (var client = clientFactory.CreateClient("BaseClient"))
        //    {
        //        try
        //        {
        //            string requestJson = JsonConvert.SerializeObject(SearchTerm);
        //            HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

        //            var result1 = await client.PostAsync("Order/GetShippingProvider", httpContent);
        //            if (result1.IsSuccessStatusCode)
        //            {
        //                shippingProviderList = await result1.Content.ReadAsAsync<List<MasterItemModel>>();
        //            }
        //            ViewBag.ShippingProviderList = shippingProviderList;


        //            var result2 = await client.GetAsync($"Admin/GetAllCustomer");
        //            if (result2.IsSuccessStatusCode)
        //            {
        //                customerList = await result2.Content.ReadAsAsync<List<CustomerModel>>();
        //            }
        //            ViewBag.CustomerList = customerList;


        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine("ERROR: " + ex.Message);
        //            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //        }
        //    }
        //    return View();
        //}

        //public async Task<PartialViewResult> PrintLabelForm(string DocRefNoWithTrackingNo)
        //{
        //    List<WMSOrderModel> salesOrders = new List<WMSOrderModel>();
        //    using (var client = clientFactory.CreateClient("BaseClient"))
        //    {
        //        try
        //        {
        //            var response = await client.GetAsync("Order/GetDeliveryOrderByOrderID/" + DocRefNoWithTrackingNo);
        //            if (response.IsSuccessStatusCode)
        //                salesOrders = await response.Content.ReadAsAsync<List<WMSOrderModel>>();
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine("ERROR: " + ex.Message);
        //        }
        //        return PartialView("_LabelForm", salesOrders[0]);
        //    }
        //}
        //public async Task<IActionResult> AssignCarrier([FromBody] WMSOrderModel DataOrder)
        //{
        //    ResponseModel responseData = new ResponseModel();
        //    using (var client = clientFactory.CreateClient("BaseClient"))
        //    {
        //        try
        //        {
        //            string requestJson = JsonConvert.SerializeObject(DataOrder);
        //            HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

        //            string urlAssignCarrier = "";
        //            if (DataOrder.ProviderCode == "FTL" || DataOrder.ProviderCode == "SCGL")
        //            {
        //                urlAssignCarrier = "SCGL/AssignCarrier";
        //            }
        //            else if (DataOrder.ProviderCode == "OTHER")
        //            {
        //                urlAssignCarrier = "Order/AssignCarrier";
        //            }
        //            else 
        //            {
        //                urlAssignCarrier = "SCGEX/AssignCarrier";
        //            }

        //            var result = await client.PostAsync(urlAssignCarrier, httpContent);
        //            if (result.IsSuccessStatusCode)
        //                responseData = await result.Content.ReadAsAsync<ResponseModel>();
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine("ERROR: " + ex.Message);
        //            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //        }
        //        return Ok(new { success = responseData.Success, message = responseData.Message, data = responseData });
        //    }
        //}

        //public async Task<IActionResult> GetLabel(WMSOrderModel TrackingData)
        //{
        //    string encodeParams = encodeUri(TrackingData.OrderID + "|" + TrackingData.TrackingNo);
        //    FileContentModel labelFile = new FileContentModel();

        //    using (var client = clientFactory.CreateClient("BaseClient"))
        //    {
        //        try
        //        {
        //            var response = await client.GetAsync("TrackingLabel/GetLabelFile/" + encodeParams);
        //            if (response.IsSuccessStatusCode)
        //                labelFile = response.Content.ReadAsAsync<FileContentModel>().Result;

        //            if (string.IsNullOrEmpty(labelFile.Base64String) || labelFile.ContentType == "error")
        //            {
        //                if (TrackingData.ShippingProvider == "SCGEX" || TrackingData.ProviderCode == "SCGEX")
        //                {
        //                    string requestJson = JsonConvert.SerializeObject(TrackingData);
        //                    HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

        //                    var response2 = await client.PostAsync("SCGEX/GetLabel", httpContent);
        //                    if (response2.IsSuccessStatusCode)
        //                    {
        //                        TrackingInfoModel filePDF = await response2.Content.ReadAsAsync<TrackingInfoModel>();
        //                        labelFile.FileName = filePDF.TrackingNo + ".pdf";
        //                        labelFile.Base64String = filePDF.PackingLabel;
        //                        labelFile.ContentType = "pdf";
        //                    }
        //                }
        //                else
        //                {
        //                    WMSOrderModel salesOrders = new WMSOrderModel();

        //                    var response3 = await client.GetAsync("Order/GetByDocRefNo/" + TrackingData.DocRefNo);
        //                    if (response3.IsSuccessStatusCode)
        //                        salesOrders = response3.Content.ReadAsAsync<WMSOrderModel>().Result;

        //                    TrackingInfoModel trackingLabelOrder = new TrackingInfoModel();
        //                    trackingLabelOrder.CustomerCode = salesOrders.Ownercode;
        //                    trackingLabelOrder.SourceSystem = salesOrders.SourceSystem;
        //                    trackingLabelOrder.OrderNumber = salesOrders.OriginalOrder;
        //                    trackingLabelOrder.TrackingNo = salesOrders.TrackingNo;
        //                    trackingLabelOrder.OrderID = salesOrders.OrderID;
        //                    trackingLabelOrder.ShopID = salesOrders.ShopID;

        //                    TrackingInfoModel resultData = new TrackingInfoModel();
        //                    string requestJson = JsonConvert.SerializeObject(trackingLabelOrder);
        //                    HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

        //                    var response4 = await client.PostAsync("Adapter/GetTrackingLabelAdapter", httpContent);
        //                    if (response4.IsSuccessStatusCode)
        //                        resultData = await response4.Content.ReadAsAsync<TrackingInfoModel>();

        //                    if (string.IsNullOrEmpty(resultData.PackingLabel))
        //                        return Ok(new { success = false, message = "Label Not Found", data = "" });

        //                    if (resultData.LabelFileType == "error")
        //                        return Ok(new { success = false, message = "error", data = "" });

        //                    salesOrders.TrackingNo = resultData.TrackingNo;
        //                    //now 1 Original = 1 trackingNo ,  if 1 to many, many to many  error

        //                    ResponseModel updateTrackingMsg = new ResponseModel();
        //                    string requestJson5 = JsonConvert.SerializeObject(salesOrders);
        //                    HttpContent httpContent5 = new StringContent(requestJson5, Encoding.UTF8, "application/json");

        //                    var response5 = await client.PostAsync("TrackingLabel/UpdateTrackingAdapter", httpContent5);
        //                    if (response5.IsSuccessStatusCode)
        //                    {
        //                        updateTrackingMsg = await response5.Content.ReadAsAsync<ResponseModel>();
        //                        if (updateTrackingMsg.Status != "S")
        //                            return Ok(new { success = false, message = updateTrackingMsg.Message, data = "" });
        //                    }
        //                    else
        //                    {
        //                        return Ok(new { success = false, message = "Cannot Update Tracking Adapter", data = response5 });
        //                    }

        //                    resultData.OrderNumber = salesOrders.SOnumber;
        //                    resultData.CustomerCode = salesOrders.Ownercode;
        //                    resultData.SourceSystem = salesOrders.SourceSystem;

        //                    ResponseModel adapterOrders = new ResponseModel();
        //                    string requestJson6 = JsonConvert.SerializeObject(resultData);
        //                    HttpContent httpContent6 = new StringContent(requestJson6, Encoding.UTF8, "application/json");

        //                    var response6 = await client.PostAsync("TrackingLabel/SaveTrackingLabel", httpContent6);
        //                    if (response6.IsSuccessStatusCode)
        //                        adapterOrders = await response6.Content.ReadAsAsync<ResponseModel>();

        //                    if (adapterOrders.Status != "S")
        //                    {
        //                        return Ok(new { success = false, message = adapterOrders.Message, data = "" });
        //                    }
        //                    else
        //                    {
        //                        labelFile.Base64String = resultData.PackingLabel;
        //                        labelFile.ContentType = resultData.LabelFileType;
        //                        return Ok(new { success = true, message = adapterOrders.Message, data = labelFile });
        //                    }
        //                }
        //            }
        //            return Ok(new { success = true, message = "success", data = labelFile });
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine("ERROR: " + ex.Message);
        //            return Ok(new { success = false, message = ex.Message, data = ex });
        //        }
        //    }
        //}

        //public async Task<IActionResult> AssignCarrierSingle([FromBody] WMSOrderModel DataOrder)
        //{
        //    ResponseModel responseData = new ResponseModel();
        //    using (var client = clientFactory.CreateClient("BaseClient"))
        //    {
        //        try
        //        {
        //            string requestJson = JsonConvert.SerializeObject(DataOrder);
        //            HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

        //            var result = await client.PostAsync("Order/AssignCarrierSingle", httpContent);
        //            if (result.IsSuccessStatusCode)
        //                responseData = await result.Content.ReadAsAsync<ResponseModel>();
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine("ERROR: " + ex.Message);
        //            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //        }
        //        return Ok(new { success = responseData.Success, message = responseData.Message, data = responseData });
        //    }
        //}
        public async Task<IActionResult> GetDistrictByPostalCode(MasterItemModel PostalCodeData)
        {
            List<MasterItemModel> districtList = new List<MasterItemModel>();

            using (var client = clientFactory.CreateClient("BaseClient"))
            {
                try
                {
                    string requestJson = JsonConvert.SerializeObject(PostalCodeData);
                    HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("Order/GetDistrictByPostalCode", httpContent);
                    if (response.IsSuccessStatusCode)
                    {
                        //Install-Package Microsoft.AspNet.WebApi.Client
                        districtList = await response.Content.ReadAsAsync<List<MasterItemModel>>();
                        this.response.Status = "S";
                    }

                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
                return Ok(new { success = this.response.Success, message = this.response.Message, data = districtList });
            }
        }
    }
}
