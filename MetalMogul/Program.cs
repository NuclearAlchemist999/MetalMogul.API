using MetalMogul;
using MetalMogul.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.ConfigureDatabase(builder.Configuration);

builder.Services.IgnoreCycles();

builder.Services.ConfigureServices();

var app = builder.Build();

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
