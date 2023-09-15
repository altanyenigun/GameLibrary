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

## Endpoint List

![endpointList](./Documentation/endpointList.PNG)

These are basic endpoints for CRUD

* GET  - api/Games
* POST - api/Games
* GET  - api/Games/{id}
* PUT - api/Games/{id}
* DELETE - api/Games/{id}


### GET - api/Games/List

![List](./Documentation/list.PNG)

In the most basic terms, you write a basic SQL query as 'ORDER BY NAME ASC'. In the Field parameter, you write the field you want to sort by, and in the OrderBy section, type 'ASC' or 'DESC'.

### POST - api/Games/Filter

![List](./Documentation/filter.PNG)

Here you can filter by all fields in the table at the same time. If you do not enter any filters, it will bring all the data, as you add filters, it will bring the relevant data.You can add as many filters as you want, but remember that filters work in combination.