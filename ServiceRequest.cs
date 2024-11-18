using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_3B_Part_1
{

    public class ServiceRequest
    {
        public int ServiceRequestID { get; set; }
        
        public string Title { get; set; }
        
        public string Status { get; set; }
        
        public DateTime DateSubmitted { get; set; }
        
        public string Description { get; set; }
        
        public int Priority { get; set; }

    }
}
