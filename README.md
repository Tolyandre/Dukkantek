# Dukkantek evaluation assignment

We have an inventory with :
- products(name, barcode, description, weight, status(sold, inStock, damaged))
- categories (name)


Using DDD, SQL server, EF Core for the database provider, .Net core, no UI needed just the APIs
- Create 3 APIs
    1) Count the number of products sold, damaged and inStock
    2) Change the status of a product
    3) Sell a product


# Implementation notes

- This is not DDD, sorry. DDD requires some research on domain, but we are given data scheme only.
- Transaction Script design pattern with Vertical Slices featured by MediatR.
- Integration tests covers both logic and API stability.
- RESTful api, with validations.
- Short and clean tests, due to expectations are files in `__Verify__` folder.


# How to run

## Run database with docker

If you don't have SQL Server installed, you can run it with docker:

```powershell
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password_123" -p 1433:1433 -it --rm mcr.microsoft.com/mssql/server:2019-latest
```

This command downloads SQL Server image (~ 400-500Mb) and starts a new container.
You can stop the container by pressing CTRL+C. When stopped, container will be removed WITH application data.


### Connection string

If you want to change connection string, update it in
- [appsettings.json](./Api/appsettings.json),
- [TestDatabaseFixture.cs](./IntegrationTests/TestDatabaseFixture.cs)


### Database

Database is created on startup if not exist.
Also database is re-created on every test run.
To re-create database restart the docker container.


### Initial data

See database initial data in [DukkantekDbContext.cs](./Db/DukkantekDbContext.cs).

## Run app

Tested with Microsoft Visual Studio Community 2022.
Run app and tests as usual. You browser will open swagger-ui.
