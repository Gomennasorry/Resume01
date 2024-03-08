using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeDto
{
    public class AuthorizedUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string BusinessId { get; set; }
        public string Organization { get; set; }


        public string FullName { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiryDate { get; set; }

        public byte[] PictureBytes { get; set; }
        public string PictureBase64 { get; set; }

        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string UserType { get; set; }
        public bool IsActive { get; set; }
        public bool IsAuthorize { get; set; }
        public string Language { get; set; }

        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }

        // UserPage
        public string CustomerCode { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }



        public List<AuthorizedMenuModel> AuthorizedMenus { get; set; }
        //public List<CustomerModel> CustomersUsers { get; set; }
        //public List<CustomersMarketPlaceModel> CustomersMarketPlace { get; set; }

        //public AuthorizedUserModel()
        //{
        //    CustomersUsers = new List<CustomerModel>();
        //    CustomersMarketPlace = new List<CustomersMarketPlaceModel>();


        //}



    }
}
