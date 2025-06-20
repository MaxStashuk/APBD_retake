To build the app we need to have a file named "appsettings.json"

```json
  {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*", 
  "ConnectionStrings": {
    "DefaultConnection" : "Data Source=localhost; Initial Catalog=master; User Id=sa; Password=database_CONNECTION_2025; Trust Server Certificate=true;"
  },
}
```
