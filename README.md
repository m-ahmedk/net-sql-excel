# User Reporting System
This is a .NET Core project that allows for CRUD operations on user data, as well as the ability to generate a PDF report of user data using Crystal Reports. The project uses Entity Framework Core to connect to a SQL Server database.

## Getting Started
To get started with this project, follow these steps:

- Clone the repository to your local machine.
- Open the solution in Visual Studio.
- Build the solution to restore all packages.
- Set up the SQL Server database by running the SQL script located in the "Database" folder of the solution.
- Run the application.

## Usage
The main functionality of this application is to allow for CRUD operations on user data. This includes the ability to create, read, update, and delete user records in the database. The application also includes a feature to generate a PDF report of user data using Crystal Reports.

To generate a PDF report of user data, click on the "Reports" link in the application. This will call a function from another project in the same solution that is based on .NET Framework, as Crystal Reports is not supported in .NET Core. The function will generate a PDF report of user data using Crystal Reports and return it to the .NET Core project, where it will be displayed to the user.

## Contributing
If you would like to contribute to this project, please follow these steps:

### Fork the repository to your own GitHub account.
1. Create a new branch for your changes.
2. Make your changes and commit them to the new branch.
3. Create a pull request to merge your changes back into the main branch.

## License
This project is licensed under the MIT License - see the [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/m-ahmedk/crystal-report-proxy/blob/main/LICENSE) file for details.