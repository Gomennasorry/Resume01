using System;
using System.Collections.Generic;

namespace ResumeDto
{
    public class StudentModel : BaseModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public string StudentDescription { get; set; }
      
        //public List<QuotationCategory> Materials { get; set; }
        //public List<QuotationItemModel> Items { get; set; }
        //public CustomerModel CustomerData { get; set; }
        //public QuotationModel()
        //{
        //    Materials = new List<QuotationCategory>();
        //    Items = new List<QuotationItemModel>();
        //    CustomerData = new CustomerModel();
        //}

    }
}
