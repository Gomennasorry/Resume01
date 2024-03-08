using System;
using System.Collections.Generic;

namespace ResumeDto
{
    public class QuotationModel : BaseModel
    {
        public string QuotationNo { get; set; }
        public string RevisionNo { get; set; }
        public int RevNo { get; set; }
        public string AttentionName { get; set; }
        public string QuotationType { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string SubDistrict { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string PostalCode { get; set; }
        public string QuotationName { get; set; }
        public string RefDemandNo { get; set; }
        public string QuotationNote { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int EstimatedDays { get; set; }
        public string Remark { get; set; }
        public string SaleCode { get; set; }
        public string SaleName { get; set; }
        public string SaleMobile { get; set; }
        public string SaleEmail { get; set; }
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
