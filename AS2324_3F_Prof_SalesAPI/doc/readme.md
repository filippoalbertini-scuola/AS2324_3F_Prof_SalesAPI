## SalesAPI
Sales API in c#

## adding sqlite database management 
1) Adding from NuGet System.Data.SQLite.Core
2) Adding from NuGet Microsoft.AspNetCore.Mvc.Newtonsoft

// adding DataTable serializing in program.cs
// https://learn.microsoft.com/en-us/answers/questions/1163994/system-notsupportedexception-serialization-and-des
3) builder.Services.AddControllers()
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
