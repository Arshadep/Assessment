using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test1.ViewModel
{
    public class EditActionViewModel
    {

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public EnumStatus ActionStatus { get; set; }

    }
}