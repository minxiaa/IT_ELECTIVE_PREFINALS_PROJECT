# it-elective-2-prelim-assignment-1

Project Overview
- Application: ASP.NET Core MVC application built on top of an existing SQLite database
- Framework & ORM: Built using .NET 8.0 SDK and Entity Framework Core 8.0.
- Database Role: The supplied SQLite database acts as the single source of truth.

Required NuGet Packages
- Microsoft.EntityFrameworkCore (Version 8.0.0)
- Microsoft.EntityFrameworkCore.Sqlite (Version 8.0.0)
- Microsoft.EntityFrameworkCore.Design (Version 8.0.0)

Repository Structure:
The Controllers contains:
- CustomersController.cs
- DepartmentsController.cs
- EmployeesController.cs
- HomeController.cs
- ReportsController.cs
- TeamsController.cs
- TicketsController.cs

The Data contain ApplicationDbContext.cs for EF Core context and model mappings.

The Models contains manually Entites:
- Department.cs
- Employee.cs
- ErrorViewModel.cs
- Tag.cs
- Team.cs
- TeamMember.cs
- TicketAssignment.cs
- TicketAttachments.cs
- TicketCategories.cs
- TicketComments.cs
- TicketPriority.cs
- TicketStatus.cs
- TicketTag.cs
- Tickets.cs

Properties contain:
- launchSettings.json

ViewModels contains models for complex reporting views:
- DepartmentWorkloadViewModel.cs
- EmployeeWorkloadViewModel.cs

Views contains Razor views for UI pages, layouts, and custom report views:
Views/Customers 
- Index.cshtml

Views/Departments 
- Index.cshtml

Views/Employees 
- Index.cshtml

Views/Home
- CategoryHierarchy.cshtml

Views/Report 
- Index.cshtml

Views/Reports 
- DepartmentWorkload.cshtml
- EmployeeWorkload.cshtml
- MultipleAssigneeTickets.cshtml
- PrimaryAssignee.cshtml

Views/Shared 
- Error.cshtml
- _Layout.cshtml
- _Layout.cshtml.css
- _ValidationScriptsPartial.cshtml
- Index.cshtml

View/Teams
- Index.cshtml

Views/Tickets
- Views/UnassignedTickets.cshtml
- Views/_ViewImports.cshtml
- Views/_ViewStart.cshtml


Features:
Departments & Employees: Lists active status, full contact info, and employee counts per department.

Teams & Customers: Displays team assignments and customer contact details.

Employee Workload: Active employees with their unresolved ticket count (includes 0 counts).

Department Workload: Departments with employee totals and unresolved ticket counts.

Unassigned Tickets: Displays tickets currently lacking active assignees.

Multiple-Assignee Tickets: Displays tickets assigned to more than one person or team.

Primary Assignee: Shows the primary assignee or "Unassigned" if empty.

