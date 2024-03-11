using ResumeAPI.Repositories;
using ResumeAPI.Services;
using ResumeDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;


namespace ResumeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    [AllowAnonymous]
    public class StudentController : BaseController
    {
        IConfiguration configure;
        IStudentRepository studentRepo;
        //IOrderRepository orderRepo;

        public StudentController(IStudentRepository studentRepository, IConfiguration configuration)
        {
            configure = configuration;
            studentRepo = studentRepository;
        }



        [HttpPost("[action]")]
        public async Task<IEnumerable<StudentModel>> SearchStudent(StudentModel StudentData)
        {
            
            //SearchTerm.UserId = this.Username;
            IEnumerable<StudentModel> studentLists = await studentRepo.SearchStudent(StudentData);

            return studentLists;
        }

        [HttpGet("[action]/{StudentId}")]
        public async Task<StudentModel> GetStudentById(int StudentId)
        {

            //SearchTerm.UserId = this.Username;
            StudentModel studentData = await studentRepo.GetStudentById(StudentId);

            return studentData;
        }

        [HttpPost("[action]")]
        public async Task<ResponseModel> UpdateStudent(StudentModel StudentData)
        {

            //SearchTerm.UserId = this.Username;
            ResponseModel response = await studentRepo.UpdateStudent(StudentData);

            return response;
        }
        [HttpPost("[action]")]
        public async Task<ResponseModel> AddStudent(StudentModel StudentData)
        {

            //SearchTerm.UserId = this.Username;
            ResponseModel response = await studentRepo.AddStudent(StudentData);

            return response;
        }
        [HttpGet("[action]/{StudentId}")]
        public async Task<ResponseModel> DeleteStudent(int StudentId)
        {

            //SearchTerm.UserId = this.Username;
            ResponseModel response = await studentRepo.DeleteStudent(StudentId);

            return response;
        }

        //[HttpPost("[action]")]
        //public async Task<IEnumerable<SalesOrderModel>> SearchDashBoard(SearchOrderModel SearchTerm)
        //{
        //    IEnumerable<SalesOrderModel> salesOrders = await orderRepo.SearchDashBoard(SearchTerm);

        //    return salesOrders;
        //}
        //[HttpPost("[action]")]
        //public async Task<IEnumerable<MasterItemModel>> GetDistrictByPostalCode(MasterItemModel PostalCodeData)
        //{
        //    IEnumerable<MasterItemModel> districtList = await orderRepo.GetDistrictByPostalCode(PostalCodeData);

        //    return districtList;
        //}

        //[HttpPost("[action]")]
        //public async Task<DashBoardOrderModel> SearchDashBoardByStore(SearchOrderModel SearchTerm)
        //{

        //    SearchTerm.UserId = this.Username;
        //    DashBoardOrderModel dashboardOrder = await orderRepo.SearchDashBoardByStore(SearchTerm);

        //    return dashboardOrder;
        //}


        //multi Assign , not use
        //[HttpPost("[action]")]
        //public async Task<List<SCGEXOrderResponse>> AssignCarrier(List<WMSOrderModel> DataOrders)
        //{
        //    List<SCGEXOrderResponse> scgExResults = new List<SCGEXOrderResponse>();

        //    SCGEXService scgExSvc = new SCGEXService(configure);
        //    foreach (var order in DataOrders)
        //    {
        //        SCGEXOrder scgExOrder = await orderRepo.GetOrderSCGEXById(order.DocRefNo);
        //        scgExOrder.Tel = string.IsNullOrEmpty(scgExOrder.Tel) ? "-" : scgExOrder.Tel;

        //        List<int> packList = order.Items.Select(i => i.PackNumber).Distinct().ToList();

        //        SCGEXOrderResponse scgExResponse = scgExSvc.CreateOrder(scgExOrder).Result;
        //        scgExResults.Add(scgExResponse);

        //        if (scgExResponse.status)
        //        {
        //            string retMsg = "";
        //            string retSuccess = "";

        //            for (int i = 0; i < order.TotalBoxs; i++)
        //            {
        //                order.TrackingNo = (order.TotalBoxs > 1 ? scgExResponse.trackingNumber[i].ToString() : scgExResponse.trackingNumber);
        //                order.PackNumber = packList.Count > i ? packList[i] : 0;
        //                ResponseModel response = await orderRepo.Assign(order);
        //                retMsg += response.Message;
        //                retSuccess = response.Status;
        //            }
        //        }
        //    }

        //    return scgExResults;
        //}

        //[HttpPost("[action]")]
        //public async Task<IEnumerable<MasterItemModel>> GetShippingProvider(MasterItemModel SearchTerm)
        //{
        //    IEnumerable<MasterItemModel> shippings = await orderRepo.GetShippingProvider(SearchTerm);

        //    return shippings;
        //}

        //[HttpGet("[action]/{DocRefNo}")]
        //public async Task<SCGEXOrder> GetOrderSCGEXById(string DocRefNo)
        //{
        //    SCGEXOrder scgExOrder = await orderRepo.GetOrderSCGEXById(DocRefNo);
        //    return scgExOrder;
        //}


        //[HttpGet("[action]/{DocRefNoWithTrackingNo}")]
        //public async Task<WMSOrderModel> GetDeliveryOrderByDocRefNo(string DocRefNoWithTrackingNo)
        //{
        //    this.uriParams = decodeUri(DocRefNoWithTrackingNo);
        //    WMSOrderModel salesOrders = await orderRepo.GetDeliveryOrderByDocRefNo(uriParams[0], uriParams[1]);
        //    return salesOrders;
        //}

        //[HttpGet("[action]/{OrderIDWithTrackingNo}")]
        //public async Task<IEnumerable<WMSOrderModel>> GetDeliveryOrderByOrderID(string OrderIDWithTrackingNo)
        //{
        //    this.uriParams = decodeUri(OrderIDWithTrackingNo);
        //    IEnumerable<WMSOrderModel> salesOrders = await orderRepo.GetDeliveryOrderByOrderID(uriParams[0], uriParams[1]);
        //    return salesOrders;
        //}

        //[HttpGet("[action]/{Id}")]
        //public async Task<WMSOrderModel> GetByDocRefNo(string Id)
        //{
        //    WMSOrderModel salesOrders = await orderRepo.GetByDocRefNo(Id);
        //    return salesOrders;
        //}

        //[HttpGet("[action]/{Id}")]
        //public async Task<WMSOrderModel> GetById(string Id)
        //{
        //    WMSOrderModel salesOrders = await orderRepo.GetById(Id);
        //    return salesOrders;
        //}

        //[HttpGet("[action]/{Id}")]
        //public async Task<WMSOrderModel> GetDocRefNoByOrderID(string Id)
        //{
        //    WMSOrderModel salesOrders = await orderRepo.GetDocRefNoByOrderID(Id);
        //    return salesOrders;
        //}

        //[HttpPost("[action]")]
        //public async Task<ResponseModel> Assign(WMSOrderModel DataOrder)
        //{
        //    ResponseModel response = await orderRepo.Assign(DataOrder);

        //    return response;
        //}

        //[HttpPost("[action]")]
        //public async Task<ResponseModel> AssignCarrier(WMSOrderModel DataOrder)
        //{
        //    if (DataOrder.ProviderCode == "OTHER")
        //    {
        //        List<int> packList = DataOrder.Items.Select(i => i.PackNumber).Distinct().ToList();


        //        ResponseModel resultResponse = new ResponseModel();
        //        string retMsg = "";
        //        string retSuccess = "";

        //        if (!DataOrder.ControlPackID)
        //            DataOrder.TotalBoxs = 1;

        //        for (int i = 0; i < DataOrder.TotalBoxs; i++)
        //        {
        //            //DataOrder.TrackingNo = (DataOrder.TotalBoxs > 1 ? scgExResponse.trackingNumber[i].ToString() : scgExResponse.trackingNumber);
        //            DataOrder.PackNumber = packList.Count > i ? packList[i] : 0;
        //            ResponseModel response = await orderRepo.Assign(DataOrder);
        //            retMsg += response.Message;
        //            retSuccess = response.Status;
        //        }

        //        resultResponse.Status = retSuccess;
        //        resultResponse.Message = retMsg;

        //        return resultResponse;

        //    }
        //    return null;
        //}

        //[HttpPost("[action]")]
        //public async Task<ResponseModel> ClearAssignCarrier(WMSOrderModel DataOrder)
        //{
        //    ResponseModel response = await orderRepo.ClearAssignCarrier(DataOrder);

        //    return response;
        //}

        //[HttpPost("[action]")]
        //public async Task<ResponseModel> ChangeAddress(WMSOrderModel DataOrder)
        //{
        //    ResponseModel response = await orderRepo.ChangeAddress(DataOrder);

        //    return response;
        //}

    }
}
