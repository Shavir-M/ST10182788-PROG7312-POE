
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_3B_Part_1
{
    public class ServiceRequestGraph
    {
        
        private Dictionary<int, List<(ServiceRequest, int)>> adjacencyList;

        
        private List<(ServiceRequest from, ServiceRequest to, int weight)> edges;

        
        public ServiceRequestGraph()
        {
            adjacencyList = new Dictionary<int, List<(ServiceRequest, int)>>();
            edges = new List<(ServiceRequest, ServiceRequest, int)>();
        }

        
        public void AddEdge(ServiceRequest from, ServiceRequest to, int weight)
        {
            if (!adjacencyList.ContainsKey(from.ServiceRequestID))
            {
                adjacencyList[from.ServiceRequestID] = new List<(ServiceRequest, int)>();
            }
            if (to != null)
            {
                adjacencyList[from.ServiceRequestID].Add((to, weight));
                edges.Add((from, to, weight));
            }
        }

        
        public void RemoveEdge(ServiceRequest from, ServiceRequest to, int weight)
        {
            if (adjacencyList.ContainsKey(from.ServiceRequestID))
            {
                adjacencyList[from.ServiceRequestID].RemoveAll(edge => edge.Item1.ServiceRequestID == to.ServiceRequestID && edge.Item2 == weight);
            }
            edges.RemoveAll(edge => edge.from.ServiceRequestID == from.ServiceRequestID && edge.to.ServiceRequestID == to.ServiceRequestID && edge.weight == weight);
        }

        
        public Dictionary<ServiceRequest, int> CountDependencies()
        {
            var dependencyCount = new Dictionary<ServiceRequest, int>();

            foreach (var request in GetAllRequests())
            {
                var neighbors = GetNeighbors(request.ServiceRequestID);
                dependencyCount[request] = neighbors.Count;
                Console.WriteLine($"Request '{request.Title}' has {neighbors.Count} dependencies.");
            }

            return dependencyCount;
        }

        
        public List<ServiceRequest> GetNeighbors(int id)
        {
            if (adjacencyList.ContainsKey(id))
            {
                return adjacencyList[id].Select(x => x.Item1).ToList();
            }
            return new List<ServiceRequest>();
        }

        
        public List<ServiceRequest> GetAllRequests()
        {
            var allRequests = new HashSet<ServiceRequest>();

            foreach (var key in adjacencyList.Keys)
            {
                allRequests.Add(new ServiceRequest { ServiceRequestID = key });
            }

            foreach (var edges in adjacencyList.Values)
            {
                foreach (var edge in edges)
                {
                    allRequests.Add(edge.Item1);
                }
            }

            return allRequests.ToList();
        }

        
        public List<(ServiceRequest from, ServiceRequest to, int weight)> GetEdges()
        {
            return edges;
        }

        
        public List<(ServiceRequest from, ServiceRequest to, int weight)> GetMinimumSpanningTree()
        {
            var parent = new Dictionary<int, int>();
            var rank = new Dictionary<int, int>();

            foreach (var edge in edges)
            {
                parent[edge.from.ServiceRequestID] = edge.from.ServiceRequestID;
                parent[edge.to.ServiceRequestID] = edge.to.ServiceRequestID;
                rank[edge.from.ServiceRequestID] = 0;
                rank[edge.to.ServiceRequestID] = 0;
            }

            int Find(int i)
            {
                if (parent[i] != i)
                {
                    parent[i] = Find(parent[i]);
                }
                return parent[i];
            }

            void Union(int x, int y)
            {
                int rootX = Find(x);
                int rootY = Find(y);

                if (rootX != rootY)
                {
                    if (rank[rootX] > rank[rootY])
                    {
                        parent[rootY] = rootX;
                    }
                    else if (rank[rootX] < rank[rootY])
                    {
                        parent[rootX] = rootY;
                    }
                    else
                    {
                        parent[rootY] = rootX;
                        rank[rootX]++;
                    }
                }
            }

            var mst = new List<(ServiceRequest from, ServiceRequest to, int weight)>();
            var sortedEdges = edges.OrderBy(e => e.weight).ToList();

            foreach (var edge in sortedEdges)
            {
                int rootFrom = Find(edge.from.ServiceRequestID);
                int rootTo = Find(edge.to.ServiceRequestID);

                if (rootFrom != rootTo)
                {
                    mst.Add(edge);
                    Union(rootFrom, rootTo);
                }
            }

            return mst;
        }

        
        public bool HasCycle()
        {
            var parent = new Dictionary<int, int>();

            foreach (var edge in edges)
            {
                parent[edge.from.ServiceRequestID] = edge.from.ServiceRequestID;
                if (edge.to != null)
                {
                    parent[edge.to.ServiceRequestID] = edge.to.ServiceRequestID;
                }
            }

            int Find(int i)
            {
                if (parent[i] != i)
                {
                    parent[i] = Find(parent[i]);
                }
                return parent[i];
            }

            void Union(int x, int y)
            {
                int rootX = Find(x);
                int rootY = Find(y);

                if (rootX != rootY)
                {
                    parent[rootY] = rootX;
                }
            }

            foreach (var edge in edges)
            {
                if (edge.to == null) continue;

                int rootFrom = Find(edge.from.ServiceRequestID);
                int rootTo = Find(edge.to.ServiceRequestID);

                if (rootFrom == rootTo)
                {
                    return true;
                }

                Union(rootFrom, rootTo);
            }

            return false;
        }

        
    }
}
