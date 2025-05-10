using Microsoft.EntityFrameworkCore;
using ULearn.LP.Core.Entities;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
var configuration = builder.Configuration;
//Database configuration
builder.Services.AddDbContext<OnlineCourseDbContext>(options =>
{
    options.UseSqlServer(
    configuration.GetConnectionString("DbContext"),
    provideroptions => provideroptions.EnableRetryOnFailure());
});
builder.Services.AddOpenApi();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();