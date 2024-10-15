using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Programming_3B_Part_1
{
    public partial class LocalEventsForm : Window
    {
        private int userId;  

        // Placeholder text value for search box
        private const string PlaceholderText = "Search by category or date...";

        // Stack to store recent search queries
        private Stack<string> searchHistoryStack = new Stack<string>();

        // Dictionary to store events by ID
        private Dictionary<int, Event> eventDictionary = new Dictionary<int, Event>();

        // Queue for upcoming events 
        private Queue<Event> upcomingEventsQueue = new Queue<Event>();

        // List to act as a priority queue, sorting by importance
        private List<Event> priorityQueue = new List<Event>();

        // HashSet to store unique categories
        private HashSet<string> uniqueCategories = new HashSet<string>(); 

        // Dictionary to track the frequency of search queries
        private Dictionary<string, int> searchQueryFrequency = new Dictionary<string, int>();

        // List to accumulate recommended events
        private List<Event> recommendedEventsList = new List<Event>();

        public LocalEventsForm(int loggedInUserId)
        {
            InitializeComponent();
            int userId = loggedInUserId;  
            InitializePlaceholderText();
            LoadEvents();
            DequeueExpiredUpcomingEvents();  
            LoadNextUpcomingEvent();
            LoadNextHighPriorityEvent();

            
            CheckAdminPrivileges(userId);
        }

        private void CheckAdminPrivileges(int userId)
        { 

            
            if (userId == 3)
            {
                // Show the Add Event button
                btnAddEvent.Visibility = Visibility.Visible;
            }
            else
            {
                // Hide the Add Event button for non-admin users
                btnAddEvent.Visibility = Visibility.Collapsed;
            }
        }

        // Method to initialize the placeholder text in the search box
        private void InitializePlaceholderText()
        {
            SearchTextBox.Text = PlaceholderText;
            SearchTextBox.Foreground = Brushes.Gray;  
        }

        // Event handler for GotFocus (when the user clicks into the search box)
        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text == PlaceholderText)
            {
                SearchTextBox.Text = string.Empty;  
                SearchTextBox.Foreground = Brushes.Black;  
            }
        }

        // Event handler for LostFocus (when the user leaves the search box)
        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = PlaceholderText;  
                SearchTextBox.Foreground = Brushes.Gray;  
            }
        }

        private void LoadEvents()
        {

            AddEvent(new Event("Town Hall Meeting", "Government", DateTime.ParseExact("16/10/2024", "dd/MM/yyyy", null), "Discuss local policies and issues.", "Town Hall", 5));
            AddEvent(new Event("Music Festival", "Entertainment", DateTime.ParseExact("05/12/2024", "dd/MM/yyyy", null), "A fun day filled with music and performances.", "City Park", 2));
            AddEvent(new Event("Charity Run", "Community", DateTime.ParseExact("10/11/2024", "dd/MM/yyyy", null), "Join us for a charity run to raise funds for local causes.", "Central Square", 3));
            AddEvent(new Event("City Council Meeting", "Government", DateTime.ParseExact("25/10/2024", "dd/MM/yyyy", null), "Council members discuss local policies.", "City Hall", 4));
            AddEvent(new Event("Tech Conference", "Technology", DateTime.ParseExact("20/10/2024", "dd/MM/yyyy", null), "Learn about the latest advancements in technology.", "Convention Center", 5));
            AddEvent(new Event("Comedy Show", "Entertainment", DateTime.ParseExact("12/11/2024", "dd/MM/yyyy", null), "Stand-up comedy show featuring local comedians.", "Grand Theater", 3));
            AddEvent(new Event("Community Clean-up", "Community", DateTime.ParseExact("20/10/2024", "dd/MM/yyyy", null), "Help clean up the local park.", "Local Park", 2));
            AddEvent(new Event("Food Festival", "Entertainment", DateTime.ParseExact("15/11/2024", "dd/MM/yyyy", null), "Taste a variety of foods from different cultures.", "Downtown", 3));
            AddEvent(new Event("AI Expo", "Technology", DateTime.ParseExact("08/12/2024", "dd/MM/yyyy", null), "Explore the future of artificial intelligence.", "Tech Hub", 4)); 
            DisplayEvents();
        }

        public void AddEvent(Event newEvent)
        {
            if (!eventDictionary.ContainsKey(newEvent.Id))
            {
                // Add the event to the dictionary
                eventDictionary[newEvent.Id] = newEvent;

                // Add the category to the HashSet 
                uniqueCategories.Add(newEvent.Category);  // This ensures categories are unique

                 
                EnqueueUpcomingEvent(newEvent);  // Queue based on time 
                EnqueuePriorityEvent(newEvent);  // Queue based on importance

                RefreshEventList();  
            }
            else
            {
                MessageBox.Show("An event with this ID already exists.");
            }
        }

        // Method to return unique categories as a list for ComboBox binding
        public List<string> GetUniqueCategories()
        {
            return uniqueCategories.ToList();  
        }

        // Enqueue the event to the upcoming events queue 
        private void EnqueueUpcomingEvent(Event newEvent)
        {
            upcomingEventsQueue.Enqueue(newEvent);  
        }

        // Enqueue the event to the priority queue 
        private void EnqueuePriorityEvent(Event newEvent)
        {
            priorityQueue.Add(newEvent);  
            priorityQueue = priorityQueue.OrderByDescending(ev => ev.Importance).ThenBy(ev => ev.Date).ToList(); 
        }

        // Dequeue expired events (past events) 
        private void DequeueExpiredUpcomingEvents()
        {
            while (upcomingEventsQueue.Count > 0 && upcomingEventsQueue.Peek().Date < DateTime.Now)
            {
                var expiredEvent = upcomingEventsQueue.Dequeue();  
                
            }
        }

        // Load the next upcoming event 
        private void LoadNextUpcomingEvent()
        {
            if (upcomingEventsQueue.Count > 0)
            {
                var nextEvent = upcomingEventsQueue.Peek();  
                DisplayNextEvent(nextEvent);  
            }
            else
            {
                
                NextEventTitle.Text = "Title: N/A";
                NextEventCategory.Text = "Category: N/A";
                NextEventDate.Text = "Date: N/A";
                NextEventLocation.Text = "Location: N/A";
            }
        }

        // Load the next high-priority event 
        private void LoadNextHighPriorityEvent()
        {
            if (priorityQueue.Count > 0)
            {
                var nextEvent = priorityQueue.First();  
                priorityQueue.Remove(nextEvent);
            }
        }

        private void DisplayNextEvent(Event nextEvent)
        {
            // Update the TextBlocks with the next event details
            NextEventTitle.Text = $"Title: {nextEvent.Title}";
            NextEventCategory.Text = $"Category: {nextEvent.Category}";
            NextEventDate.Text = $"Date: {nextEvent.Date.ToShortDateString()}";
            NextEventLocation.Text = $"Location: {nextEvent.Location}";
        }

        private void DisplayEvents()
        {
            var eventList = eventDictionary.Values.ToList();
            EventsListView.ItemsSource = eventList;
        }

        // Refresh the ListView by setting its ItemsSource to the event values
        private void RefreshEventList()
        {
            EventsListView.ItemsSource = null;  
            EventsListView.ItemsSource = eventDictionary.Values.ToList();  
        }

        private void SearchEvents(string query)
        {
            // Track the search query to determine patterns and preferences
            searchHistoryStack.Push(query);

            // Track the frequency of the search term
            TrackSearchPattern(query);

            // Simple search by category or date
            var filteredEvents = eventDictionary.Values
                .Where(ev => ev.Category.Contains(query, StringComparison.OrdinalIgnoreCase)
                             || ev.Date.ToString("dd/MM/yyyy").Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();

            EventsListView.ItemsSource = filteredEvents;

            // Accumulate recommendations based on the current search
            AccumulateRecommendedEvents(query);  
        }

        // Track the search patterns and store frequency
        private void TrackSearchPattern(string query)
        {
            if (!string.IsNullOrWhiteSpace(query))
            {
                if (searchQueryFrequency.ContainsKey(query))
                {
                    searchQueryFrequency[query]++;
                }
                else
                {
                    searchQueryFrequency[query] = 1;
                }
            }
        }

        private void AccumulateRecommendedEvents(string currentSearch)
        {
            // Find events related to the current search 
            var recommendedEvents = eventDictionary.Values
                .Where(ev => ev.Category.Contains(currentSearch, StringComparison.OrdinalIgnoreCase)
                             || ev.Title.Contains(currentSearch, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Add only unique events to the recommended list
            foreach (var eventItem in recommendedEvents)
            {
                if (!recommendedEventsList.Contains(eventItem))  
                {
                    recommendedEventsList.Add(eventItem);
                    RecommendedEventsGrid.Items.Add(eventItem);  
                }
            }

            
            RefreshRecommendationsUI();
        }

        private void RefreshRecommendationsUI()
        {
            RecommendedEventsGrid.Items.Refresh();  
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchEvents(SearchTextBox.Text);
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            
            SearchTextBox.Text = string.Empty;
            DisplayEvents();
        }

        private void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            
            AddEventForm addEventForm = new AddEventForm(uniqueCategories);
            addEventForm.ShowDialog();

            
            RefreshEventList();
        }

        // Refresh the ListView by setting its ItemsSource to the event values
        private void RefreshEventList(List<Event> eventList)
        {
            EventsListView.ItemsSource = null;  
            EventsListView.ItemsSource = eventList;  
        }

        // Event handler to show upcoming events 
        private void btnShowUpcoming_Click(object sender, RoutedEventArgs e)
        {
            RefreshEventList(upcomingEventsQueue.ToList());  
        }

        // Event handler to show priority events (sorted by importance)
        private void btnShowPriority_Click(object sender, RoutedEventArgs e)
        {
            RefreshEventList(priorityQueue);  
        }

        private void btnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(userId);
            mainWindow.Show();
            this.Close();
        }
    }
}