# Programming-3B-ST10182788-POE
 Municipality Event Management App

Overview

The Municipality Event Management App is designed to manage and showcase various community events for a municipality. Users can search, browse, and add events, while admin users have access to additional features such as event creation. The app also recommends events based on users’ search history and preferences, ensuring a personalized experience.

Features

1. Event Management

	•	Users can view events categorized by different themes, such as Government, Community, Entertainment, and Technology.
	•	Events are displayed with relevant details including title, date, description, location, and importance level.

2. Search Functionality

	•	Users can search for events by category or date using a search bar.
	•	The search results are dynamically displayed as users input their search queries.

3. Recommendations

	•	The app analyzes user search patterns and preferences.
	•	Based on search frequency and patterns, related events are recommended and displayed in a user-friendly manner.

4. Admin Privileges

	•	Admin users (identified by a specific user ID) have additional privileges such as the ability to add new events.
	•	Admin features are restricted to users with a certain user ID (e.g., user ID 3).

5. Stacks, Queues, and Priority Queues

	•	A stack is used to keep track of recent search queries, enabling quick analysis of user preferences.
	•	A queue is used to store upcoming events in a First-In-First-Out (FIFO) manner, ensuring that events closest to the current date are shown first.
	•	A priority queue (implemented using a sorted list) is used to sort events based on their importance levels, with more important events being displayed first.

6. Data Structures

	•	HashSets are used to manage and store unique event categories efficiently, ensuring no duplicate categories.
	•	Dictionaries are used to store events, allowing fast lookups by event ID and enabling efficient retrieval of event information.
	•	Search query tracking: A dictionary tracks the frequency of search queries to suggest events related to user preferences.

7. Event List and Grid Views

	•	Events are displayed in a ListView, sorted by priority or upcoming date depending on the user’s selection.
	•	A separate grid is used to show recommended events based on user search patterns.

Getting Started

Prerequisites

	•	.NET 6.0 or later installed on your system
	•	SQLite database for user authentication and event management

Setting Up the Database

	1.	The app uses an SQLite database (prog7312.db) to store user information and event data.
	2.	The database is initialized with two tables: Users (for user login) and Issues (for managing events).
	3.	To initialize the database, the app will check for the presence of prog7312.db. If it doesn’t exist, it will automatically create it and set up the necessary tables.

Running the App

	1.	Clone the repository and open it in Visual Studio or your preferred IDE.
	2.	Build the project.
	3.	Run the application to access the login page.
	4.	Use the admin login (user ID 3) to add events and manage the event data.

Admin Access
		Username:admin Password:1234
	•	Admins are determined based on user ID.
	•	To log in as an admin, use a pre-configured user with ID 3 or modify the database to set your user ID to 3.

Adding Events

	1.	Admins can add events via the “Add Event” button on the main page.
	2.	Events can include categories, locations, importance levels, and more.

Searching for Events

	•	Users can search for events by category or date (in dd/MM/yyyy format).
	•	The search results will be displayed dynamically, with recommendations provided based on search patterns.

Recommendations

	•	As users search for events, the app tracks search patterns and recommends similar events.
	•	Recommendations are displayed in a dedicated section below the search results.

Event Data Structure

Each event has the following properties:

	•	Title: The name of the event.
	•	Category: A category such as Government, Entertainment, or Technology.
	•	Date: The date of the event.
	•	Description: A brief overview of the event.
	•	Location: The place where the event is held.
	•	Importance: A rating from 1-5, with 5 being the most important.

Technologies Used

	•	C# and WPF for building the application.
	•	SQLite for the database layer.
	•	.NET framework for backend logic and UI.

How It Works

	1.	Stacks: Recent search queries are pushed onto a stack to track search patterns and preferences.
	2.	Queues: Events are added to a FIFO queue to manage upcoming events by date.
	3.	Priority Queues: Events are sorted by importance using a priority queue (implemented via sorted lists).
	4.	HashSets: Unique event categories are stored in a HashSet to prevent duplicates.
	5.	Dictionaries: Events are stored in dictionaries for fast retrieval by ID.
