# template-architecture-cqrs-full
Architecture CQRS Full (.NET 8.0)

#### Migrations

Go to "BAYSOFT.Infrastructures.Data" project folder and open cmd
> cd src/BAYSOFT.Infrastructures.Data

Add migration ex: InitialMigration
> dotnet ef --startup-project ../BAYSOFT.Presentations.Web.Api migrations add [Name of the migration] -c DefaultDbContext -o Default/Migrations


#### dotnet-ef install
> dotnet tool install --global dotnet-ef

#### dotnet-ef update
> dotnet tool update --global dotnet-ef
