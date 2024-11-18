using Programming_3B_Part_1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Programming_3B_Part_1
{
    public class ServiceRequestViewModel : INotifyPropertyChanged
    {
        
        private ServiceRequestBST serviceRequestBST;

        private ServiceRequestGraph serviceRequestGraph;

        private ObservableCollection<ServiceRequest> serviceRequests;

        public ObservableCollection<ServiceRequest> ServiceRequests
        {
            get => serviceRequests;
            set { serviceRequests = value; OnPropertyChanged(nameof(ServiceRequests)); }
        }
        private string mostUrgentRequestID;


        public string MostUrgentRequestID
        {
            get { return mostUrgentRequestID; }
            set
            {
                mostUrgentRequestID = value;
                OnPropertyChanged(nameof(MostUrgentRequestID));
            }
        }

        private string mostUrgentRequestTitle;

        public string MostUrgentRequestTitle
        {
            get { return mostUrgentRequestTitle; }
            set
            {
                mostUrgentRequestTitle = value;
                OnPropertyChanged(nameof(MostUrgentRequestTitle));
            }
        }

        private ObservableCollection<ServiceRequest> mostUrgentRequestDependencies;
        public ObservableCollection<ServiceRequest> MostUrgentRequestDependencies
        {
            get => mostUrgentRequestDependencies;
            set
            {
                mostUrgentRequestDependencies = value;
                OnPropertyChanged(nameof(MostUrgentRequestDependencies));
            }
        }


        public ServiceRequestViewModel()
        {
            serviceRequestBST = new ServiceRequestBST();
            serviceRequestGraph = new ServiceRequestGraph();
            serviceRequests = new ObservableCollection<ServiceRequest>
    {
        new ServiceRequest { ServiceRequestID = 101, Title = "Water Main Burst", DateSubmitted = DateTime.Now.AddDays(-3), Status = "In Progress", Description = "Major water main burst affecting local area.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 102, Title = "Road Patch Repair", DateSubmitted = DateTime.Now.AddDays(-8), Status = "Completed", Description = "Patch pothole on residential road.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 103, Title = "Power Line Check", DateSubmitted = DateTime.Now.AddDays(-1), Status = "Pending", Description = "Inspect damaged power line near school.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 104, Title = "Community Center Cleaning", DateSubmitted = DateTime.Now.AddDays(-6), Status = "In Progress", Description = "Regular cleaning for community center.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 106, Title = "Stop Sign Replacement", DateSubmitted = DateTime.Now.AddDays(-5), Status = "Completed", Description = "Replace missing stop sign at crosswalk.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 107, Title = "Park Graffiti Removal", DateSubmitted = DateTime.Now.AddDays(-2), Status = "Pending", Description = "Remove graffiti from public park entrance.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 108, Title = "Picnic Bench Repair", DateSubmitted = DateTime.Now.AddDays(-10), Status = "Completed", Description = "Repair broken picnic bench in playground.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 109, Title = "Sidewalk Tree Trimming", DateSubmitted = DateTime.Now.AddDays(-3), Status = "In Progress", Description = "Trim tree branches encroaching on sidewalk.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 110, Title = "Playground Sand Refill", DateSubmitted = DateTime.Now.AddDays(-4), Status = "Pending", Description = "Refill sand in playground area.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 111, Title = "New Speed Limit Signs", DateSubmitted = DateTime.Now.AddDays(-7), Status = "In Progress", Description = "Install new speed limit signs in school zone.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 112, Title = "Library Roof Repair", DateSubmitted = DateTime.Now.AddDays(-14), Status = "Completed", Description = "Repair damaged roof at local library.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 113, Title = "Animal Control in Park", DateSubmitted = DateTime.Now.AddDays(-1), Status = "In Progress", Description = "Capture stray animals spotted in park.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 114, Title = "Bus Stop Shelter Repair", DateSubmitted = DateTime.Now.AddDays(-3), Status = "Pending", Description = "Repair broken shelter at bus stop.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 115, Title = "Weekly Street Sweeping", DateSubmitted = DateTime.Now.AddDays(-9), Status = "Completed", Description = "Routine street sweeping in downtown area.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 116, Title = "Fire Hydrant Checkup", DateSubmitted = DateTime.Now.AddDays(-12), Status = "Completed", Description = "Inspect and test fire hydrants for functionality.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 117, Title = "Noise Control Enforcement", DateSubmitted = DateTime.Now.AddDays(-6), Status = "In Progress", Description = "Investigate noise complaints from construction site.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 118, Title = "Storm Drain Maintenance", DateSubmitted = DateTime.Now.AddDays(-2), Status = "Pending", Description = "Clear debris from storm drain to prevent flooding.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 119, Title = "Fence Painting at Park", DateSubmitted = DateTime.Now.AddDays(-13), Status = "Completed", Description = "Repaint old fencing at community park.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 120, Title = "Bike Lane Redesign", DateSubmitted = DateTime.Now.AddDays(-8), Status = "In Progress", Description = "Redesign bike lane layout to improve safety.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 121, Title = "Street Light Upgrades", DateSubmitted = DateTime.Now.AddDays(-4), Status = "Pending", Description = "Upgrade old street lights to energy-efficient models.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 122, Title = "Public Telephone Booth Repair", DateSubmitted = DateTime.Now.AddDays(-3), Status = "In Progress", Description = "Fix vandalized public telephone booth.", Priority = 1 },
        new ServiceRequest { ServiceRequestID = 124, Title = "Mosquito Control Spray", DateSubmitted = DateTime.Now.AddDays(-1), Status = "In Progress", Description = "Spray to control mosquito population in affected areas.", Priority = 1 }
    };

            foreach (var request in serviceRequests)
            {
                serviceRequestBST.Insert(request);
                serviceRequestGraph.AddEdge(request, null, 0);
            }

            // Define dependencies
            AddDependency(101, 102, 5); 
            AddDependency(123, 122, 1); 
            AddDependency(123, 120, 1); 
            AddDependency(123, 109, 1); 
            AddDependency(101, 118, 3); 

            DetermineMostUrgentRequest();
        }


        /// Method to add a service request
        public void AddServiceRequest(ServiceRequest request)
        {
            if (serviceRequestBST.Insert(request))
            {
                ServiceRequests.Add(request);

                
                serviceRequestGraph.AddEdge(request, null, 0);
            }
        }

        /// Method to add a dependency between service requests

        public void AddDependency(int fromId, int toId, int weight)
        {
            var from = serviceRequests.FirstOrDefault(sr => sr.ServiceRequestID == fromId);
            var to = serviceRequests.FirstOrDefault(sr => sr.ServiceRequestID == toId);

            if (from == null || to == null)
            {
                Console.WriteLine("Invalid service request ID(s) provided.");
                return;
            }

            Console.WriteLine($"Attempting to add dependency from '{from.Title}' to '{to?.Title}' with weight {weight}.");

            serviceRequestGraph.AddEdge(from, to, weight);
            if (serviceRequestGraph.HasCycle())
            {
                
                serviceRequestGraph.RemoveEdge(from, to, weight);

                
                Console.WriteLine($"Adding from: {from.Title} to: {to.Title}, this dependency creates a cycle. Dependency not added.");
            }
            else
            {
                Console.WriteLine($"Dependency from '{from.Title}' to '{to?.Title}' with weight {weight} added successfully.");
            }
        }


        /// Method to determine the most urgent request

        public void DetermineMostUrgentRequest()
        {
            var dependencyCount = serviceRequestGraph.CountDependencies();
            var heap = new ServiceRequestHeap();

            foreach (var kvp in dependencyCount)
            {
                heap.Insert(kvp.Key, kvp.Value);
            }

            var mostUrgentRequest = dependencyCount.OrderBy(dc => dc.Value).FirstOrDefault().Key;

            if (mostUrgentRequest != null)
            {
                mostUrgentRequest = heap.ExtractMax().request;
                MostUrgentRequestID = mostUrgentRequest.ServiceRequestID.ToString();
                MostUrgentRequestTitle = serviceRequestBST.Search(mostUrgentRequest.ServiceRequestID).Title;

                Console.WriteLine($"Most urgent request determined: '{MostUrgentRequestTitle}' with ID {MostUrgentRequestID}.");

                var dependencies = serviceRequestGraph.GetNeighbors(mostUrgentRequest.ServiceRequestID);
                MostUrgentRequestDependencies = new ObservableCollection<ServiceRequest>(dependencies);
            }
            else
            {
                MostUrgentRequestID = "N/A";
                MostUrgentRequestTitle = "N/A";
            }

            
            OnPropertyChanged(nameof(MostUrgentRequestID));
            OnPropertyChanged(nameof(MostUrgentRequestTitle));
        }


        /// Method to filter service requests

        public void FilterRequests(string searchTerm, string selectedStatus, DateTime? startDate, DateTime? endDate)
        {
            var allRequests = serviceRequestBST.DisplayAllRequests();

            var filteredRequests = allRequests;

            // Filter by search term
            if (!string.IsNullOrEmpty(searchTerm))
            {
                filteredRequests = filteredRequests.Where(r => r.Title.ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            // Filter by status
            if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "-- Filter by Status --")
            {
                filteredRequests = filteredRequests.Where(r => r.Status == selectedStatus).ToList();
            }

            // Filter by date range
            if (startDate.HasValue)
            {
                filteredRequests = filteredRequests.Where(r => r.DateSubmitted >= startDate.Value).ToList();
            }

            if (endDate.HasValue)
            {
                filteredRequests = filteredRequests.Where(r => r.DateSubmitted <= endDate.Value).ToList();
            }

            // Update the ObservableCollection
            ServiceRequests.Clear();
            foreach (var request in filteredRequests)
            {
                ServiceRequests.Add(request);
            }

            OnPropertyChanged(nameof(ServiceRequests));
        }


        /// Method to search service requests by title

        public void SearchRequests(string searchTerm)
        {
            var lowerSearchTerm = searchTerm?.ToLower();

            var filteredRequests = serviceRequestBST.DisplayAllRequests()
                .Where(r => string.IsNullOrEmpty(lowerSearchTerm) || r.Title.ToLower().Contains(lowerSearchTerm))
                .ToList();

            ServiceRequests.Clear();
            foreach (var request in filteredRequests)
            {
                ServiceRequests.Add(request);
            }
        }


        /// Method to sort service requests by title

        public void SortRequestsByTitle(bool ascending, List<ServiceRequest> filteredRequests)
        {
            var sortedRequests = ascending
         ? filteredRequests.OrderBy(r => r.Title).ToList()
         : filteredRequests.OrderByDescending(r => r.Title).ToList();

            Console.WriteLine("Sorted by Title:");
            foreach (var request in sortedRequests)
            {
                Console.WriteLine($"Title: {request.Title}, Status: {request.Status}, Order: {ascending}");
            }

            ServiceRequests.Clear();
            foreach (var request in sortedRequests)
            {
                ServiceRequests.Add(request);
            }

            OnPropertyChanged(nameof(ServiceRequests));
        }


        /// Method to filter service requests by status

        public void FilterRequestsByStatus(string status)
        {
            var allRequests = serviceRequestBST.DisplayAllRequests();
            if (allRequests == null)
            {
                
                return;
            }

            var filteredRequests = allRequests
                .Where(r => r.Status == status || status == "-- Filter by Status --")
                .ToList();

            ServiceRequests.Clear();
            foreach (var request in filteredRequests)
            {
                ServiceRequests.Add(request);
            }
        }


        /// Method to sort service requests by status

        public void SortRequestsByStatus(bool ascending, List<ServiceRequest> filteredRequests)
        {
            var sortedRequests = ascending
         ? filteredRequests.OrderBy(r => r.Status).ToList()
         : filteredRequests.OrderByDescending(r => r.Status).ToList();

            ServiceRequests.Clear();
            foreach (var request in sortedRequests)
            {
                ServiceRequests.Add(request);
            }

            OnPropertyChanged(nameof(ServiceRequests));
        }


        public void FilterRequestsByDate(DateTime? startDate, DateTime? endDate)
        {
            var filteredRequests = serviceRequestBST.DisplayAllRequests()
                .Where(r => (!startDate.HasValue || r.DateSubmitted >= startDate.Value) &&
                            (!endDate.HasValue || r.DateSubmitted <= endDate.Value))
                .ToList();

            ServiceRequests.Clear();
            foreach (var request in filteredRequests)
            {
                ServiceRequests.Add(request);
            }
        }


        /// Method to sort service requests by date

        public void SortRequestsByDate(bool ascending, List<ServiceRequest> filteredRequests)
        {
            var sortedRequests = ascending
       ? filteredRequests.OrderBy(r => r.DateSubmitted).ToList()
       : filteredRequests.OrderByDescending(r => r.DateSubmitted).ToList();

            ServiceRequests.Clear();
            foreach (var request in sortedRequests)
            {
                ServiceRequests.Add(request);
            }
            OnPropertyChanged(nameof(ServiceRequests));
        }


        /// INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
