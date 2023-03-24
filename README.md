# Pierre's Sweet and Savory Treats
#### Special Project #11 for Epicodus, 24 March 2023
### by Mike Donovan

## Description

A C#/ASP.NET/EFCore web app that allows a user to view and, if logged in, edit a database of treats and their flavors.

## Technologies Used
* C#
* .NET
* ASP.NET
* Entity Framework Core

<!-- ## Database diagram

![ScreenShot](/db.png) -->

## Setup/Installation Instructions

1. Clone this repo.
2. In the repo folder, navigate to `TreatShop/` and open `appsettings.json.example`.
3. Replace `[YOUR-DB-NAME]`, `[YOUR-USER-HERE]`, and `[YOUR-PASSWORD-HERE]` with your own credentials.
4. Save the file as `appsettings.json`.
5. Open your shell (e.g., Terminal or GitBash).
6. Navigate to this project's production directory called "TreatShop".
7. If don't have the `dotnet-ef` package installed globally, run the command `dotnet tool install --global dotnet-ef --version 6.0.0`.
8. If you don't have the `Microsoft.EntityFrameworkCore.Design` package installed, run the command `dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.0`.
9. Start a local development server with a program such as MySQL Workbench on port 3306.
10. Run `dotnet ef database update` in the command line.
11. Run `dotnet watch run` in the command line to start the project in development mode with a watcher.
12. Open the browser to _https://localhost:5001_. If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. For more information, [visit the Microsoft documentation on dev-certs](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-dev-certs).

## Known Bugs

No known bugs.

## Legal

MIT License

Copyright (c) 2023 Mike Donovan

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
