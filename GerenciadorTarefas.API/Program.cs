using GerenciadorTarefas.Insfrastructre.Extension;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.ConfigureServices();
var app = builder.Build();
app.MapControllers();
app.Run();


