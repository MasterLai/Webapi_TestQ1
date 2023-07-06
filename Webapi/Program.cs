using System.Data.Entity;
using Application;
using Application.Interface;
using Infrastructure;
using Infrastructure.Interface;
using Infrastructure.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// builder.Services.AddScoped<IGenericRepository<Test>, GenericRepository<Test>>();
// builder.Services.AddScoped(typeof(IGovService), typeof(GovService));
// builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<TestContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "origins",
                      policy  =>
                      {
                          policy.WithOrigins("*");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("origins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
