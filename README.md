## GameLibrary

Currently, it is an API that only holds information about games and performs CRUD and filtering operations.

## Requirements

- [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [SQL Server](https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads)
- [SQL Server Management Studio](https://learn.microsoft.com/tr-TR/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16) For Management the data

## Installation
  ```shell
  git clone https://github.com/altanyenigun/GameLibrary.git
  ```

If you have db settings other than default, you need to update the "Server" parameter in the "DefaultConnection" with your own information.

```json
   "ConnectionStrings": {
      "DefaultConnection":"Server=.\\SqlExpress; Database=GameLibrary; Trusted_Connection=true; TrustServerCertificate=true;"
  },
```


Run on terminal:
```shell
    # Enter the project directory if not already entered.
    cd .\GameLibraryApi\

    # Run 
    dotnet build
    dotnet ef database update

    # For backend start
    dotnet watch run
  
  ```

## Test Users
Username : admin | Password = admin | Role = "Admin" 

Token
```
eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTY5NTc1NzMwOH0.NFP5CVeIdYax3ge4rUI_sn49UQ1oSTvqld5xDVdVZ8SVM_I9gr3KmBETzvhPIxg24JzemFKbBcijFq2p8QVpHQ
```

##

Username : altan | Password = altan123 | Role = "User" 

Token
```
eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWx0YW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNjk1NzU3MjI2fQ.nEM6YGne_oaAM3XSlKhez4m80EagBMAE6luJlwnrdXI5o11dxxUFUgHP-V7Ec_1Qf7-54Eq7IImreHmy-dzecA
```

##

Username : patika | Password = dev | Role = "User" 

Token
```
eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoicGF0aWthIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXNlciIsImV4cCI6MTY5NTc1NzM0Nn0.CpP9L8DnInsbtEJEJlSe8MaKFdFXl8PhfswWa6WxNhAPENl8g5Z8P-tY5LUG-rm7JEqAlII4itSe7MVJZxhImQ
```

##

After the backend is up, you can only use the /register and /login endpoints unless the bearer token is logged in. After entering the bearer token, you can run or not run various endpoints depending on the privileges of the entered user. For example, only a user with the "Admin" role can add, delete or update a game.


## How to Authorize on Swagger
![swaggerToken](./Documentation/swaggerToken.png)

After pressing the "Authorize" button on Swagger, it is enough to enter "bearer {token}" in the "Value" section in the window that opens.

For the token we need here, I added sample tokens for the users I have previously defined above. You can authorization with these tokens.

If you register with a new user and then log in, the result of the login process will return you the Token you need here.

## Endpoint List

![endpointList](./Documentation/endpointList.PNG)

### Auth

---

Where new user creation and login operations are performed.

  * POST - /register
  * POST - /login

### Game

---

These are basic endpoints for CRUD

* GET  - api/Games
* POST - api/Games
* GET  - api/Games/{id}
* PUT - api/Games/{id}
* DELETE - api/Games/{id}


#### GET - api/Games/List

![List](./Documentation/list.PNG)

In the most basic terms, you write a basic SQL query as 'ORDER BY NAME ASC'. In the Field parameter, you write the field you want to sort by, and in the OrderBy section, type 'ASC' or 'DESC'.

#### POST - api/Games/Filter

![List](./Documentation/filter.PNG)

Here you can filter by all fields in the table at the same time. If you do not enter any filters, it will bring all the data, as you add filters, it will bring the relevant data.You can add as many filters as you want, but remember that filters work in combination.

### UserInvertory

---

It performs operations such as fetching the games owned by the logged-in user, adding or deleting new games according to the user's wishes, and filtering the games owned by the user.

  * GET - api/MyGames
  * POST - api/BuyGame
  * POST - api/RemoveGame
  * POST - api/ByFilterMyGames

