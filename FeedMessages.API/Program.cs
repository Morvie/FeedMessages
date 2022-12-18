using MediatR;
using QueriesMediatR = FeedMessages.Application.Queries;
using CommandsMediatR = FeedMessages.Application.Commands;
using FeedMessages.Application.Interfaces.Infrastructure;
using FeedMessages.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using FeedMessages.Infrastructure.Context;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MediatR dependencies:
builder.Services.AddMediatR(new Type[]
{
    typeof(QueriesMediatR.GetAllFeeds.GetAllFeedsQuery),
    typeof(QueriesMediatR.GetFeed.GetFeedQuery),
    typeof(CommandsMediatR.CreateFeed.CreateFeedCommand),
    typeof(CommandsMediatR.UpdateFeed.UpdateFeedCommand),
    typeof(CommandsMediatR.DeleteFeed.DeleteFeedCommand),
});

// Dependency injection:
builder.Services.AddScoped<IQueryFeedInfrastructure, QueryFeedRepository>();
builder.Services.AddScoped<ICommandFeedInfrastructure, CommandFeedRepository>();

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<FeedDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("FeedMessages.API").EnableRetryOnFailure()));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FeedDbContext>();
    dbContext.Database.EnsureCreated();
}

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
