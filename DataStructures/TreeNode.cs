using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_3B_Part_1
{
    public class TreeNode
    {
        public ServiceRequest Data { get; set; }

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }

        public TreeNode(ServiceRequest data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        
    }
}
