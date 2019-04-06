# serilog-azure-claims-sample   
   
This is a sample showing how to insert aditional columns in Serilog database that require a middleware, While using a real life scenerio of logging also which user was using the system at the time of logging.   
   
## Libraries Used   
### Nice GUI to fiddle with the API   
Install-Package Swashbuckle.AspNetCore   -Version 4.0.1   
   
### Azure Authetication Library   
Install-Package Microsoft.AspNetCore.Authentication.AzureAD.UI -Version 2.2.0   
   
### Serilog Libraries   
Install-Package Serilog.AspNetCore -Version 2.1.1   
Install-Package Serilog.Settings.Configuration -Version 3.0.1   
Install-Package Serilog.Sinks.MSSqlServer -Version   5.1.3-dev-00232   
   
### Caveats
   
change launchSettings.json   
```
  "launchUrl": "swagger", 
```   
If you are tempted to install the following because the of dev   
   
Install-Package Serilog.Sinks.MSSqlServer -Version 5.1.2   
   
be warned     
```
          "columnOptionsSection": {
            "customColumns": [
              {
                "ColumnName": "Oid",
                "DataType": "nvarchar",
                "DataLength": 256,
                "AllowNull": true
              },
              {
                "ColumnName": "ApplicationCode",
                "DataType": "nvarchar",
                "DataLength": 450,
                "AllowNull": true
              }
            ]
          }
```
will not work   
   
For OidMiddleware to work, you must set   
```
config.Enrich.FromLogContext();   
```
   
Enrich in json config does not work   
