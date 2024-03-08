//using BASE.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeAPI.Repositories;
using System.ComponentModel;
using System.Text;

namespace ResumeAPI.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected string[] uriParams;


        [ReadOnly(true)]
        public string Username
        {
            get
            {
                return User?.Claims.FirstOrDefault(c => c.Type.EndsWith("claims/sid"))?.Value;
            }
        }

        [HttpGet]
        [Route("api/test")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<string>> Test()
        {
            string result = $"{DateTime.Now}: Ready...";
            return await Task.FromResult(result);
        }

        [HttpGet]
        [Route("sql/test")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<string>> Connect()
        {
            DBContext dbCtx = new DBContext();
            string result = dbCtx.DBInfo();
            return await Task.FromResult(result);
        }
        static public string encodeUri(string plainText)
        {
            var e = Encoding.GetEncoding("iso-8859-1");
            byte[] plainTextBytes = e.GetBytes(plainText);
            string returnValue = System.Convert.ToBase64String(plainTextBytes);
            return returnValue;
        }
        protected string[] decodeUri(string id)
        {
            var e = Encoding.GetEncoding("iso-8859-1");
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(id);
            string returnValue = e.GetString(encodedDataAsBytes);
            //return returnValue;
            uriParams = returnValue.Split('|');
            return uriParams;
        }

        protected string decodeStr(string id)
        {
            var e = Encoding.GetEncoding("iso-8859-1");
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(id);
            string returnValue = e.GetString(encodedDataAsBytes);
            return returnValue;
        }
    }
}
