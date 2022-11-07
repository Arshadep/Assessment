using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test1.Models
{
    public class Request
    {
        public int RequestId { get; set; }

        [Required(ErrorMessage ="please Select valid date")]
        [DataType(DataType.DateTime)]
        [Display(Name ="Request Date")]
        public DateTime CreatedAt { get; set; }

        public int Status { get; set; }

        
        public DateTime? UpdatedAt { get; set; }

    }
}