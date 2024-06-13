# template-architecture-cqrs-full
Architecture CQRS Full (.NET 8.0)

#### Migrations

Go to "BAYSOFT.Infrastructures.Data" project folder and open cmd

> dotnet ef --startup-project ../BAYSOFT.Presentations.API migrations add InitialMigrationDefaultDbContext -c DefaultDbContext -o Default/Migrations
