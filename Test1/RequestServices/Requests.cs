using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestServices
{
    public class Requests
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public int Status { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
