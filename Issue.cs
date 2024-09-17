using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_3B_Part_1
{
    public class Issue
    {
            public int Id { get; set; }  
            public string Location { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
            public List<string> AttachedFiles { get; set; }
            public int Importance { get; set; }  
        
    }
}
