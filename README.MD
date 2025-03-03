
crear la migracion
dotnet ef migrations add InitialCreate --project Infrastructure\Infrastructure.csproj --startup-project API\API.csproj

correr la migracion
 dotnet ef database update --project Infrastructure\Infrastructure.csproj --startup-project API\API.csproj