using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_3B_Part_1
{
    public class ServiceRequestBST
    {
       
        private TreeNode root;
        
        public bool Insert(ServiceRequest request)
        {
            if (request == null || Search(request.ServiceRequestID) != null)
            {
                return false;
            }
            root = InsertNode(root, request);
            return true;
        }

        
        private TreeNode InsertNode(TreeNode node, ServiceRequest request)
        {
            if (node == null)
                return new TreeNode(request);

            if (request.ServiceRequestID < node.Data.ServiceRequestID)
                node.Left = InsertNode(node.Left, request);
            else if (request.ServiceRequestID > node.Data.ServiceRequestID)
                node.Right = InsertNode(node.Right, request);

            return node;
        }

        
        public ServiceRequest Search(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Error: Invalid service request ID.");
                return null;
            }
            return SearchNode(root, id)?.Data;
        }

        
        private TreeNode SearchNode(TreeNode node, int id)
        {
            if (node == null)
                return null;

            if (id == node.Data.ServiceRequestID)
                return node;
            else if (id < node.Data.ServiceRequestID)
                return SearchNode(node.Left, id);
            else
                return SearchNode(node.Right, id);
        }

        
        public List<ServiceRequest> DisplayAllRequests()
        {
            if (root == null)
            {
                Console.WriteLine("No service requests available.");
                return new List<ServiceRequest> { new ServiceRequest { Title = "No service requests found." } };
            }
            List<ServiceRequest> requests = InOrderTraversal(root);
            return requests;
        }

        
        private List<ServiceRequest> InOrderTraversal(TreeNode node)
        {
            List<ServiceRequest> requests = new List<ServiceRequest>();

            if (node != null)
            {
                requests.AddRange(InOrderTraversal(node.Left));
                requests.Add(node.Data);
                requests.AddRange(InOrderTraversal(node.Right));
            }

            return requests;
        }
        
    }
}


