using System;
using System.Diagnostics;
using AutoMapper;
using Demo_Responsitory;
using Demo_Responsitory.Entities;
using Demo_Responsitory.Mapping;
using Demo_Responsitory.Repositories.Implements;
using Demo_Responsitory.Repositories.Interface;
using Demo_Responsitory.Sevices.Implement;
using Demo_Responsitory.Sevices.Interface;
using Demo_Responsitory.ViewsModels.ModelsCreate;
using Microsoft.AspNetCore.Builder;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Debugger.Launch();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppilicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection"));
});
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRespository>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
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
