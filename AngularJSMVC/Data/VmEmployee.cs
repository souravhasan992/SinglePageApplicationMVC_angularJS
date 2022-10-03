using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSMVC.Data
{
    public class VmEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        
        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public DateTime JoiningDate { get; set; }

        
        public decimal Salary { get; set; }

        public virtual VmGender Gender { get; set; }
    }
}