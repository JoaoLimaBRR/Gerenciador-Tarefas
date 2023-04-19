using System.Text;
using GerenciadorTarefas.Insfrastructre.Extensions;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.ConfigureServices();
var app = builder.Build();


app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();


