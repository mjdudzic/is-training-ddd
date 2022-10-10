using ClaimsSubmission.Application;
using ClaimsSubmission.Infrastructure;
using ClaimsSubmission.Infrastructure.Persistence.DbContexts;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, lc) => lc
    .WriteTo.Console());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddClaimsSubmissionApplication(builder.Configuration);
builder.Services.AddClaimsSubmissionInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseClaimsSubmissionInfrastructure();

app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ClaimsSubmissionContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}

app.Run();

public partial class Program { }