# ASP.NET Core MVC Demo App

This is the readme file from the Dot Net Core 1.0 version of this demo app.

- **TestingWithFakeRepositories** demonstrates the use of fake repositories to facilitate unit testing of controller methods by means of Dependency Injection (DI).
- **[AddingEFCore](./docs/EfCore.md)** demonstrates using Entity Framework Core as an ORM (Object Relational Mapper) for a SQL database. The repository pattern continues to be used.
- **Navigation** demonstrates searching and adding a navigation menu to the shared layout.
- **InputForm** demonstrates implementing an input form and saving data to the database via a repository and Entity Framework.
- **Validation** demonstrates validating input both in the browser and on the server using Tag Helpers and Data Annotations.
- **Authentication** demonstrates Registration, login, and authentication of users with Identity.
- **ReviewByReader** demonstrates adding an Identity user via the SeedData class and making a user object the member of a domain model. The Identity user and the domain entities are stored in separate databases.
- **Authorization** demonstrates adding adding a role, assigning a user to a role, and restricting a controller method to only allow users in that role. The role added is "Reviewers" and the restricted method is Review/ReviewForm.

This demo was written for CS 296N, Web Development 2: ASP.NET, at Lane Community College.
For more information on courses and degrees at Lane Community college visit <https://www.lanecc.edu/cit>
