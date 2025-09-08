# LinkShortener

## Structure
* [WebUI](/src/LinkShortener.WebUI/) - Constains ASP.NET Core MVC WebApp projects.
* [BusinessLogic Layer](/src/LinkShortener.BusinessLogic/) - Constains ASP.NET Core WebAPI project.
* [Common](src/LinkShortener.Common/) - Contains entity classes and validation of exception class.
* [DataAccess Layer](src/LinkShortener.DataAccess/) - Contains repository for each entity.
* [Unit Tests](test/LinkShortener.UnitTests/) Unit tests for business logic's of Controllers.
* [Database](_!LinkShorter.snapshotDB.sql) SQL-script database deploy + stored procedures

# How to build and run the whole solution
1. Need to deploy a [Database](_!LinkShorter.snapshotDB.sql) from sql-script file.

To specify Connection string, enter its in [appsettings.Development.json](/src/LinkShortener.WebUI/appsettings.Development.json):
```
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=linkshortener;Uid=root;Pwd=;"
  }
```

