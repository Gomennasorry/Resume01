using System;

namespace ResumeDto
{
    public class BaseModel
    {
        public bool IsActive { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ChangedUser { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
