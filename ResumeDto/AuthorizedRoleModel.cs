using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeDto
{
    public class AuthorizedRoleModel
    {
        public AuthorizedRoleModel()
        {
            MenuList = new List<AuthorizedMenuModel>();
        }
        public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        public string UserType { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ChangedDate { get; set; }
        public string ChangedUser { get; set; }
        public string DisplayText { get; set; }

        public string Code { get; set; }
        public string Text { get; set; }

        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }

        public List<AuthorizedMenuModel> MenuList { get; set; }
    }
}
