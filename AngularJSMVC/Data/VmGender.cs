using System.Collections.Generic;

namespace AngularJSMVC.Data
{
    public class VmGender
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public virtual ICollection<VmEmployee> Employees { get; set; }
    }
}