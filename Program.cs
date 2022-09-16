var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCarter();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDataService, DataService>();

//could be improved with IOptionsMonitor
//https://medium.com/@dozieogbo/a-better-way-to-inject-appsettings-in-asp-net-core-96be36ffa22b
//check link for more infos
Settings settings = new();
builder.Configuration.GetSection("Settings").Bind(settings);
builder.Services.AddSingleton(settings);

var app = builder.Build();

app.MapCarter();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();