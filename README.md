### REST API
in json format.
|        | API	             | Description	           | Request body |	Response body        |
|--------|-------------------|-------------------------|:------------:|:--------------------:|
| GET    | /api/Answers      | Get all to-do items	   | None	        | Array of to-do items |
| GET    | /api/Answers/{id} | Get an item by ID	     | None	        | To-do item           |
| POST   | /api/Answers	     | Add a new item	         | Answer item  | To-do item           |
| PUT    | /api/Answers/{id} | Update an existing item | Answer item	| None                 |
| DELETE | /api/Answers/{id} | Delete an item          | None	        | None                 |
#### Open Visual Studio Code
CTRL+\`
and if packages are not yet added:
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-aspnet-codegenerator
```

Tool to generate Controllers and probably others
Sample usage:
```bash
dotnet aspnet-codegenerator controller -name AnswersController -async -api -m UserAnswer -dc AnswerContext -outDir Controllers
```
generates AnswersController, for [UserAnswer](https://raw.githubusercontent.com/pereav/cs-e-book/master/AnswerApi/Models/UserAnswer.cs) model, to dbcontext [AnswerContext]((https://raw.githubusercontent.com/pereav/cs-e-book/master/AnswerApi/Models/AnswerContext.cs)) (currently InMemory)

#### To run
Go to Visual Studio Code and press CTRL+F5
* URLs: localhost:5000 & localhost:5001
for example: access 1st answer in localhost:5000/api/Answers/1

#### Postman
* To test API, Disable SSL certificate verification
** From File > Settings (General tab), disable SSL certificate verification.
** Warning: Re-enable SSL certificate verification after testing the controller.
For more info, see Install Postman section [here](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio-code#install-postman)

### Tutorial
[ASP.NET](https://github.com/pereav/cs-e-book/issues/8)

