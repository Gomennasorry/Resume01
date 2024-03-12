//using BASE.Dto;
//using BASE.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace ResumeAPI.Services
{
    public class AdapterService
    {
        private string baseUrl = string.Empty;
        private string authToken = string.Empty;
        private IConfiguration configure;

        public AdapterService(IConfiguration configuration)
        {
            configure = configuration;
            //SCG EX
            //configure["BlobStorage:ConnectionString"];
            //baseUrl = configure[$"ADAPTER_{App.SystemID}:BaseUrl"];
            //authToken = configure[$"ADAPTER_{App.SystemID}:Token"];
        }

        //public async Task<TrackingInfoModel> GetTrackingLabel(TrackingInfoModel TrackingLabel)
        //{
        //    TrackingInfoModel resultData = new TrackingInfoModel();
        //    string requestJson = "";
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(baseUrl);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
        //        Logger.WriteLog(LogType.Adapter, "GetLabel => Tracking Number", TrackingLabel.TrackingNo);

        //        //POST Method  send OriginalOrder in OrderNumber
        //        requestJson = JsonConvert.SerializeObject(TrackingLabel);
        //        HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await client.PostAsync("", httpContent);
        //        //HttpResponseMessage response = await client.PostAsync("A2_Get_Label_Ultra-Task", httpContent);
        //        string jsonString = response.Content.ReadAsStringAsync().Result;
        //        //Logger.WriteLog(LogType.WMS, "GetLabel ADAPTER => Response", jsonString);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            JObject jObject = JObject.Parse(jsonString);
        //            //Messege = (string)jObject.Last.Last;
        //            resultData.PackingLabel = (string)jObject.SelectToken("file_content");
        //            resultData.LabelFileType = (string)jObject.SelectToken("file_type");
        //            // send 1 get 1  , send Array get only tracking_number[0]  1 ;
        //            try
        //            {
        //                resultData.TrackingNo = (string)jObject.SelectToken("tracking_number"); // maybe shopee ?
        //                //resultData.TrackingNo = (string)jObject.SelectToken("tracking_number");

        //            }
        //            catch (Exception ex)
        //            {
        //                resultData.TrackingNo = (string)jObject.SelectToken("tracking_number[0]"); // lazada dev 
        //            }
        //            resultData.Status = "S";
        //            resultData.Message = "Get Service Success" + resultData.TrackingNo;
        //        }
        //    }
        //    return resultData;
        //}
    }
}
