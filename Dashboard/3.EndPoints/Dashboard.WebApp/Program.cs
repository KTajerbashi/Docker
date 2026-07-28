using Dashboard.WebApp;

var builder = WebApplication.CreateBuilder(args);
var app = builder.AddWebApp().Build();
app.UseWebApp();
app.Run();