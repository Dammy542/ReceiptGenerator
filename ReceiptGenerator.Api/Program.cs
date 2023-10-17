using Microsoft.AspNetCore.Mvc;
using ReceiptGenerator.Api.Attribute;
using ReceiptGenerator.Core.Helpers;
using Serilog;


var MyAllowSpecificOrigins = "ReceiptGeneratorService";

var builder = WebApplication.CreateBuilder(args);

//Serilog setup
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddCoreServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy(MyAllowSpecificOrigins, builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
//enable model attribute validation  
builder.Services.Configure<ApiBehaviorOptions>(options
    => options.SuppressModelStateInvalidFilter = true);


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();