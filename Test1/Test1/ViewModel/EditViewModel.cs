using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test1.Models;

namespace Test1.ViewModel
{
    public class EditViewModel
    {
        public EditViewModel()
        {
           // ActionStatus = new List<EnumStatus>();
        }
        public Request EditViewRequest { get; set; }
        public EnumStatus ActionStatus { get; set; }
    }
}