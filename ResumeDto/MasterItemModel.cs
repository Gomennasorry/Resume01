using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeDto
{
    public enum SelectionMaster
    {
        Role
    }
    public class MasterItemModel 
    {
        public string ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemText { get; set; }
        public string Description { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string ReferCode { get; set; }
        public string ReferText { get; set; }
        public string Category { get; set; }
        public int ItemNo { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }

        public bool IsActive { get; set; }
        public string ActiveStatus { get; set; }    // A = All, T = True, F = False
    }
}
