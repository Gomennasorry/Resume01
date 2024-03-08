using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeDto
{
    public class AuthorizedMenuModel
    {
        public string MenuCode { get; set; }
        public string MenuTitle { get; set; }
        public string MenuTitleEn { get; set; }
        //public string ActionUrl { get; set; }
        public string LinkPath { get; set; }
        //public string MenuGroup { get; set; }
        public string ParentCode { get; set; }

        public int GroupSeq { get; set; }
        public int SortOrder { get; set; }
        public string IconClass { get; set; }
        public bool HasUpdate { get; set; }
        public bool HasApprove { get; set; }
        public bool HasPrint { get; set; }


        public bool AllowUpdate { get; set; }
        public bool AllowApprove { get; set; }
        public bool AllowPrint { get; set; }
        public int AllowView { get; set; }

        /////////
        public string MenuCodeGroup { get; set; }
        public string MenuNameGroup { get; set; }


    }
}
