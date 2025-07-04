
using MediatR;
using Microsoft.EntityFrameworkCore;
using RunAtRate.Application;
using RunAtRate.Application.Interfaces.Services;
using RunAtRate.Appllication.Interfaces.Repositories;
using RunAtRate.Core.Interfaces;
using RunAtRate.infrastructure.Data;
using RunAtRate.infrastructure.Repositories;
using RunAtRate.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IInspectionService, InspectionService>();
builder.Services.AddScoped<IInspectionRepostory, InspectionRepository>();    

// Add MediatR
builder.Services.AddMediatR(typeof(ApplicationAssemblyMarker).Assembly);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
