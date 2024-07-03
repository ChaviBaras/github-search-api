using github_search_api.Services.Bookmark;
using github_search_api.Services.Github;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Principal;
using System;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
builder.Services.AddSession();
builder.Services.AddScoped<IGithubService, GithubService>();
builder.Services.AddSingleton<IBookmarkService, BookmarkService>();
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

// TODO: UseJwtBearerAuthentication

app.Use(async (context, next) =>
{
    var userId = context.Request.Cookies["x-user-id"];

    if (string.IsNullOrWhiteSpace(userId))
    {
        userId = Guid.NewGuid().ToString();
        context.Response.Cookies.Append("x-user-id", userId, new CookieOptions()
        {
            Expires = DateTimeOffset.UtcNow.AddDays(7)
        });
    }

    context.User = new GenericPrincipal(new GenericIdentity(userId), new string[0]);

    await next.Invoke();
});

app.MapControllers();

app.Run();
