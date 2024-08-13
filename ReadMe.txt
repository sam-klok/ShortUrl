Application to shorten URLs and store them in the database.
Currently I'm writing it on standard .Net Framework 4.7.2 and MVC.
I'm planning to rewrite it under .Net 6 and Blazor later.

It convert long URL to short URL. 
E.g. https://stackoverflow.com/questions/3863678/asp-net-mvc-controller-parameter-optional-i-e-indexint-id 
became https://localhost:44311/S/U/McWvRsU

Thank you,
Sergiy

It loosly based on:
1. How to Build a URL Shortener With .NET
https://www.milanjovanovic.tech/blog/how-to-build-a-url-shortener-with-dotnet

2. Working with older version of Entity Framework
https://learn.microsoft.com/en-us/aspnet/web-forms/overview/older-versions-getting-started/getting-started-with-ef/the-entity-framework-and-aspnet-getting-started-part-1

3. Code first, create table

3.1 You have to install newer version of EntityFramework version 6.2.0 >> 6.5.1

3.2 Go to Package Manager Console, run
PM>Enable-Migrations

3.3 Potential error when your try to enable migrations:
https://stackoverflow.com/questions/49148464/add-migration-value-cannot-be-null-parameter-name-language
3.4. Run SQL to update database
PM>Update-Database -Verbose