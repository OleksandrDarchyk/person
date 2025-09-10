using ph;
using ph.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<FakeDB>();// один рбєкт на весь застосунок

builder.Services.AddScoped<IPersonService, PersonServise>();//створюється кожен запит



builder.Services.AddControllers();

builder.Services.AddOpenApiDocument();

var app = builder.Build();

app.MapControllers();
app.UseOpenApi();
app.UseSwaggerUi();
app.Run();
