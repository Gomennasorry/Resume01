using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeDto
{
    public class ResponseModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string DocumentNo { get; set; }
        public bool Success { get { return Status == "S"; } } //ถ้า status เป็น S return true; ถ้าเป็นอย่างอื่น return false;
 //       if (1 == "a")
	//{
 //           console.log("Hello");
	//}else {
 //       console.log("World");
 //   }
        public ResponseModel()
        {
            Status = "E";
            //Message = "An error occurred. Please try again later.";
            Message = "";
        }
    }
}
