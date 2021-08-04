==================================
# IDispatcher ASP.NET Core Project
==================================

IDispatcher is my web project defence for the module ASP.NET Core in SoftUni.
It is a website for freelancers, employers and customers, with a forum and blog section.

The focus of the project is the ability to build a back-end project with the ASP.NET Core framework using: 
 - Razor template engine for generating the UI
 - Sections and partial views
 - MVC Areas
 - User roles
 - Web APIs,
 - Caching
 - Error handling and data validation 
 - Prevent from security vulnerabilities like SQL Injection, XSS, CSRF, parameter tampering, etc.
 - The best practices for Object-Oriented design and high-quality code 
 - Microsoft SQL Server as Database Service and Entity Framework Core to access your database
 - Unit Tests 


=== Project map ====

 Home
  * =>	Find Talent
        * o	Search
        * o	Create
        * o	Read Ad    
             * - Edit (only owner)
    	        * - Delete (only owner)
  =>	Find Job
        o	Search
        o	Create
        o	Read Ad
            -	Edit (only owner)
            -	Delete (only owner)
  =>	Forum
        o	Create
        o	Read a post
           -	Edit (only owner)
           -	Delete (only owner)
           -	Set to Solved (only owner)
           -	Comment
           -	Vote
  =>	Blog
        o	Create
        o	Read/Watch video
           -	Edit (only owner)
           -	Delete (only owner)
  =>	Register
  =>	Login
  =>	Edit profile
        o	Profile
        o	Email
        o	Password
        o	Data manager
            -	Add (all data types)
            -	Delete (all data types)
            -	Edit (all data types)
        o	Profile review
  =>	Logout
  =>	Admin (only for Admin users)
        o Administration (Admin Dashboard)
            - Data Access (all kinds of data)
