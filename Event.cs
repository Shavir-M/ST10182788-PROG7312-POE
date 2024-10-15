using System;

namespace Programming_3B_Part_1
{
    public class Event
    {
        public int Id { get; set; }  // New ID property for unique event identification
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Importance { get; set; } = 0;  // Default value for Importance
        public string Location { get; set; }  // New Location property

        // Constructor that generates an ID automatically
        public Event(string title, string category, DateTime date, string description, string location, int importance = 0)
        {
            Id = new Random().Next(1, 100000);  // Auto-generate a random ID
            Title = title;
            Category = category;
            Date = date;
            Description = description;
            Location = location;
            Importance = importance;
        }

        // Parameterless constructor for serialization or if needed
        public Event() { }

        public override string ToString()
        {
            return $"{Title} ({Category}) on {Date.ToShortDateString()} - {Description}";
        }
    }
}