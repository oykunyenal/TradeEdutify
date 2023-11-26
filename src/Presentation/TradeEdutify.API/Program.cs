using TradeEdutify.Application;
using TradeEdutify.Persistence;

var builder = WebApplication.CreateBuilder(args);

var environmentName = builder.Configuration.GetSection("ASPNETCORE_ENVIRONMENT").Value;
builder.Configuration.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceRegistration(builder.Configuration);
builder.Services.AddApplicationRegistration(builder.Configuration);
    
var app = builder.Build();

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
