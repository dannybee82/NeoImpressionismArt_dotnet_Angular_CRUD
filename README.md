# NeoImpressionismArt\_dotnet\_Angular\_CRUD

An application that shows artworks from the 'Neo Impressionism Art Movement'.  
The main page shows all artworks in a grid, there is a details page and a page to create or update artworks.  
The applicaion has CRUD (Create, Update and Delete) functionality.  
The frontend application is responsive.  
See the images in the root of this project for examples.

This application consists of:

1.  Backend: C#/.NET8 WebApi (Clean Architecture) + EntityFramework.
2.  Frontend: _Angular application_ ([Angular CLI](https://github.com/angular/angular-cli) version 22.2.5) that makes use of the regular HttpClient and Angular Material.
3.  Database: _PostgreSQL_ (version 16).

## Running the application

### _1\. Docker Desktop / Docker_

To see the application in action within a _Docker Container_, use the command from the root of this project:

**docker compose up --build -d**

### _2\. Local installation_

A) PostgreSQL database  
See the folder 'Docker\_PostgreSQL' in this project. Run from that folder the command:  
**docker compose up --build -d**

This will setup the _PostgreSQL_ database.

B) Backend C#/.NET WebApi  
.NET8 is needed, check wether this installed with the command:  
_dotnet --list-sdks_

When not installed, download and install it from the link: [download .NET8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

Install the **dotnet ef-tool** - version: 10.0.10 or above

When the tool is installed, run the command for a _database migration:_

**dotnet ef database update**

Or use the longer command (and replace \*_your\_workspace\*_ by the location of your workspace):

_dotnet ef database update -p "\*your\_workspace\*\\NeoImpressionismArt\_dotnet\_Angular\_CRUD\\backend\\Infrastructure\\Infrastructure.csproj" --startup-project "\*your\_workspace\*\\NeoImpressionismArt\_dotnet\_Angular\_CRUD\\backend\\NeoImpressionismArtWebApi\\NeoImpressionismArtWebApi.csproj"_

For more information see the link below:

[https://learn.microsoft.com/en-us/ef/core/cli/dotnet](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

C) Angular 22 application.

**Angular 22** needs a **Node.js** version of at least _22.22.4_

**Command to install Angular and dependencies (from the frontend folder)**

_npm install_

or shorter:

_npm i_

**Command to run the application (from the frontend folder):**

_ng serve --open_

or shorter:

_ng s --o_

### **Changelog:**

_November 2026_

\- First commit.