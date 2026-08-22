### **Tables Discovered:**



\-**Customers Table** (

&#x09;Id (int) primary key, 

&#x09;CompanyName (text) NOT NULL, 

&#x09;ContactName (text) NOT NULL, 

&#x09;Email (text) NOT NULL, 

&#x09;Phone (text), 

&#x09;CreatedAt (text) NOT NULL,

&#x09;IsActive (int) NOT NULL; default = 1

)





\-**Departments Table**(

&#x09;Id (int) primary key,

&#x09;Name (text) unique NOT NULL,

&#x09;Description (text),

&#x09;IsActive (int) NOT NULL; default = 1



)





\-**Employees Table**(

&#x09;Id (int) primary key,

&#x09;DepartmentId (int)  normal index NOT NULL,

&#x09;FirstName (text) NOT NULL,

&#x09;LastName (text) NOT NULL,

&#x09;Email (text) unique NOT NULL,

&#x09;JobTitle (text) NOT NULL,

&#x09;HireDate (text) NOT NULL,

&#x09;IsActive (int) NOT NULL; default = 1



)



\-**Tags Table**(

&#x09;Id (int) primary key,

&#x09;Name (text) unique NOT NULL

)



\-**TeamMembers Table**(

&#x09;Composite Primary Key(

&#x09;	TeamId (int) NOT NULL,

&#x09;	EmployeeId (int) foreign key normal index NOT NULL

&#x09;),

&#x09;JoinedAt (text) NOT NULL

&#x09;

)



\-**Teams Table**(

&#x09;Id (int) primary key,

&#x09;DepartmentId (int) foreign key normal index unique NOT NULL,

&#x09;Name (text) unique NOT NULL,

&#x09;Description (text)

)



\-**TicketAssignments Table**(

&#x09;Composite Primary Key(

&#x09;	TicketId (int) foreign key NOT NULL,

&#x09;	EmployeeId (int) foreign key normal index NOT NULL

&#x09;),



&#x09;AssignedAt (text) NOT NULL,

&#x09;UnassignedAt (text),

&#x09;IsPrimary (int) NOT NULL; default = 0

&#x09;

)



\-**TicketAttachments Table**(

&#x09;Id (int) primary key,

&#x09;TicketId (int) foreign key normal index NOT NULL,

&#x09;FileName (text) NOT NULL,

&#x09;ContentType (text) NOT NULL,

&#x09;FileSize (int) NOT NULL,

&#x09;UploadedAt (text) NOT NULL

)



\-**TicketCategories Table**(

&#x09;Id (int) primary key,

&#x09;ParentCategoryId (int) self-referencing (TicketCategories(Id)) optional relationship,

&#x09;Name (text) NOT NULL,

&#x09;Description (text)

)



\-**TicketComments Table**(

&#x09;Id (int) primary key,

&#x09;TicketId (int) foreign key NOT NULL,

&#x09;EmployeeId (int) foreign key optional relationship,

&#x09;Comment (text) NOT NULL,

&#x09;CreatedAt (text) NOT NULL,

&#x09;IsInternal (int)NOT NULL; default = 0

)



\-**TicketPriorities Table**(

&#x09;Id (int) primary key,

&#x09;Name (text) unique NOT NULL,

&#x09;SortOrder (int) NOT NULL,

&#x09;ResponseHours (int) NOT NULL

)



\-**Tickets Table**(

&#x09;Id (int) primary key,

&#x09;CustomerId (int) foreign key normal indexNOT NULL,

&#x09;CategoryId (int) foreign key normal index NOT NULL,

&#x09;PriorityId (int) foreign key normal index NOT NULL,

&#x09;StatusId (int) foreign key normal index NOT NULL,

&#x09;Subject (text) NOT NULL,

&#x09;Description (text) NOT NULL,

&#x09;CreatedAt (text) normal index NOT NULL,

&#x09;UpdatedAt (text) NOT NULL,

&#x09;DueAt (text),

&#x09;ResolvedAt (text),

&#x09;ClosedAt (text)

)



\-**TicketStatuses Table**(

&#x09;Id (int) primary key,

&#x09;Name (text) unique NOT NULL,

&#x09;IsClosed (int) NOT NULL; default = 0

)



\-**TicketTags Table**(

&#x09;Composite Primary Key(

&#x09;	TicketId (int) foreign key NOT NULL,

&#x09;	TagId (int) foreign key NOT NULL

&#x09;)

)







### **One-To-Many Relationships:**



**Employees \& Departments**(Id --> DepartmentId)

**Teams \& Departments**(Id --> DepartmentId)

**TicketAttachments \& Tickets**(Id -->  TicketId)

**TicketCategories**(Id --> ParentCategoryId)

**TicketComments \& Tickets**(Id --> TicketId)

**TicketComments \& Employees**(Id --> EmployeeId)

**Tickets \& TicketCategories**(Id --> CategoryId)

**Tickets \& Customers**(Id --> CustomerId)

**Tickets \& TicketPriorities**(Id --> PriorityId)

**Tickets \& TicketStatuses**(Id --> StatusId)



### **Many-To-Many Relationships:**



**TeamMembers \& Employees**(TeamId --> EmployeeId)

**TicketAssignments \& Employees**(TicketId --> EmployeeId)

**TicketTags \& TicketTags**(TicketId --> TagId)





