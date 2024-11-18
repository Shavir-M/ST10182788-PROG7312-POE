# Programming-3B-ST10182788-POE

Municipal Services Application

This is a Windows Forms application developed as part of the PROG7312 course for efficiently managing municipal service requests. The application enables users to view and track the status of their requests, report issues, and stay informed about local events and announcements.

Table of Contents

	•	Features
	•	Project Structure
	•	Requirements
	•	Installation and Setup
	•	Running the Application
	•	Using the Application
	•	Troubleshooting
	•	Contribution Guidelines
	•	License
	•	Contact

Features

	•	Service Request Status Display: Easily view and track the status of service requests.
	•	Issue Reporting: Report issues or request services with relevant details.
	•	Local Events and Announcements: Access local updates and event information.
	•	Advanced Data Management: Efficient handling of data using advanced structures such as trees, heaps, and graphs.

Project Structure

	•	Forms: Contains all forms related to the user interface, such as the Service Request Status page and Issue Reporting form.
	•	Data Management: Implements data structures for efficient data retrieval and organization.
	•	Business Logic: Handles application logic, including validation and interaction between forms.

Requirements

To run this application, ensure the following are installed on your system:
	•	Visual Studio 2022 or later
	•	.NET SDK (version compatible with the project)
	•	Git (for version control)

Installation and Setup

Follow these steps to set up the project on your local machine:
1.	Clone the Repository
 
•	Open Visual Studio and go to File > Clone Repository.
 
•	Enter the repository URL: [https://github.com/ST10172466/Prog7312POE.git](https://github.com/Shavir-M/ST10182788-PROG7312-POE.git)

•	Select a local folder for cloning.
 
	
 2.	Open the Project
 
	
 •	Once cloned, open the project in Visual Studio by selecting the .sln file.
 
	
 3.	Install Dependencies
    
•	Open NuGet Package Manager (Tools > NuGet Package Manager > Manage NuGet Packages for Solution…) and restore any missing packages.
	
 4.	Build the Project
	
 •	Set the main project as the startup project.
	
 •	Build the project by selecting Build > Build Solution from the Visual Studio menu.
	
 •	Confirm that there are no build errors before proceeding.

Running the Application

1.	Start the Application
	
 •	Press F5 or select Debug > Start Debugging to run the application in Debug mode.
	
 •	Alternatively, go to Debug > Start Without Debugging to run it without debug messages.
 
2.	Navigate Through the Application

•	Use the main menu to access features such as Service Request Status, Report Issues, and Events and Announcements.

Using the Application

	•	Service Request Status Page
	•	View all your active and resolved service requests.
	•	Service requests are organized using data structures for quick access and sorting.
	•	Report Issues
	•	Fill in the form with relevant details about the issue or service request.
	•	Submit the form to log the request in the system for municipal review.
	•	Events and Announcements
	•	Check for local event listings and announcements.
	•	Stay informed about upcoming events and recent updates in the municipality.

Troubleshooting

	•	Build Errors: Ensure all dependencies are installed and that your .NET SDK version matches the project requirements.
	•	Visual Studio Crashes: Restart Visual Studio and try re-opening the solution. Check for any missing dependencies and confirm you are using a compatible version of Visual Studio.

Contribution Guidelines

Contributions are welcome! Please follow these guidelines:
1.	Fork the Repository

•	Create a fork of this repository and clone it locally.

2.	Create a Feature Branch

•	Create a branch for any new features or fixes (git checkout -b feature-branch-name).

3.	Commit Changes

•	Write meaningful commit messages and document changes thoroughly.

4.	Pull Request

•	Submit a pull request to the main branch with a description of changes.


Here’s a refined version for your README file:

Using the Application

Upon launching the application, you’ll have four main options:

1. Report Issues

This option opens a new page where you can submit details about an issue you’d like to report. Please fill in the following required fields:
•	Issue Name
•	Address
•	Category
•	Description
•	Media Attachment

Once all fields are completed, click the Submit button. You can then choose to submit another report or view all your submitted reports. To review your submitted reports, click the View Reports button, which will take you to the appropriate page.

2. Report View

In this section, you can select a report entry by its name, and all associated details will be displayed.

3. Local Events and Announcements

This option opens a page where you can browse and view various local events. Available actions include:
•	Search Events: Search by event title.
•	Filter Events: Filter events by category and date range.
•	Sort Events: Organize events by title, category, or date.
•	View Event: See detailed information about a selected event.

4. Services

This section displays all service requests in your area. Available actions include:
	•	Search Requests: Search requests by title.
	•	Filter Requests: Filter by status and date range.
	•	Sort Requests: Sort requests by title, status, date, or priority.
	•	View Requests: View detailed information about a specific request.

Data Structures Used

4.1 Binary Tree

Used for structuring all service request data, a binary tree allows efficient navigation and supports multiple traversal techniques for various display needs.

Advantages:
•	Logical organization for easy navigation.
•	Quick data addition without disrupting structure.

4.2 Binary Search Tree (BST)

The BST enables efficient searching, retrieving, and filtering of service requests by arranging data so each left node is smaller than its parent, and each right node is larger.

Advantages:
•	Efficient search and in-order data retrieval.
•	Supports dynamic insertion and deletion.
•	Ideal for range queries (e.g., service requests between two dates).

4.3 Weighted Graph

This structure manages complex relationships between service requests, especially where dependencies exist. Nodes represent requests, and weights indicate the priority or connection cost.

Advantages:
•	Represents requests with dependencies.
•	Supports directed, undirected, and weighted relationships.
•	Enables easy visualization of relationships.

4.4 Minimum Spanning Tree (MST)

The MST, using Kruskal’s algorithm, prevents cyclical errors by ensuring the graph remains acyclic, which is essential for dependency management.

Advantages:
	•	Keeps the dependency network acyclic.
	•	Ensures minimum total weight for the network.
	•	Suitable for managing large dependency networks.

4.5 Heap

A heap, particularly useful for identifying the most urgent service requests, is structured to prioritize requests based on urgency.

Advantages:
•	Quickly identifies high-priority requests.
•	Compact storage compared to other priority queue options.
•	Configurable as a min-heap or max-heap, depending on needs.

This detailed explanation of each option and data structure helps users understand how to navigate and interact with the application efficiently.
License

This project is licensed under the MIT License. See the LICENSE file for more information.

