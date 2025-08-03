using Microsoft.AspNetCore.Mvc;
using Strapi.Backend.Demo.Api;
using Strapi.Backend.Demo.Api.Interfaces;
using Strapi.Backend.Demo.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure dependencies for services
builder.Services.AddHttpClient<IArticleService, ArticleService>();
builder.Configuration.AddEnvironmentVariables();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Register the API endpoints
ApiConfig.ConfigRoutes(app);


app.Run();

