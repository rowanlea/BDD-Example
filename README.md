# BDD-Example
A quick and easy way to explain BDD.

# Plan
1. Picture of Example - given start page, when i click on menu, then i click on button, my end address is X
2. Explanation of example passing page address in, chaining steps
3. Show code driving steps
4. Show steps being reused in other tests, building up a suite
5. Usable by anyone - mention this early

The Playwright library requires some extra setup, which is done via a PowerShell script. This is a little odd for a .NET package, but to get the script you first need to build the project, so go ahead and build the project:

dotnet build
Now the Playwright dependency has been copied into your bin folder, and you can run the PowerShell script. Run the installation script like this:

pwsh bin/Debug/net6.0/playwright.ps1 install
Replace net6.0 with your version of .NET if you're not using .NET 6.

This installation script will install Playwright into your project, including the browsers.