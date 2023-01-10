using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using OAuth;
using OAuth.Authentication;
using OAuth.Handlers;
using OAuth.Options;
using OAuth.Properties;
using OAuth.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IBurekRepository, BurekRepository>();
builder.Services.AddMediatR(typeof(BurekRepository));

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddMediatR(typeof(UserRepository));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

builder.Services.AddSingleton<IJwtProvider, JwtProvider>();

builder.Services.ConfigureOptions<JwtOptionsSetup>(); //when sum1 injects ioptions of jwt options its gonna trigger configure method of jwt options setup
builder.Services.ConfigureOptions<JwtOptionsBearerSetup>();

var app = builder.Build();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();