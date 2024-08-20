using Microsoft.EntityFrameworkCore;
using PersonelManagement.Core.Interfaces;
using PersonelManagement.Data.Context;
using PersonelManagement.Business.Services.Concrete;
using PersonelManagement.DataAccess.Repositories.Concrete;
using PersonelManagement.Business.Profiles;
using FluentValidation;
using PersonelManagement.Business.FluentValidatiors.PersonelValidatiors;
using PersonelManagement.DTO.Personels;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidation();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));

// Unit of Work and Service layers
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPersonelService, PersonelService>();

// Validators
builder.Services.AddScoped<IValidator<PersonelCreateDTO>, PersonelCreateValidatior>();
builder.Services.AddScoped<IValidator<PersonelUpdateDTO>, PersonelUpdateValidatior>();

// AutoMappers
builder.Services.AddAutoMapper(typeof(PersonelProfile));
builder.Services.AddAutoMapper(typeof(DebitProfile));

// CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

// HttpClient for API consumption
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

