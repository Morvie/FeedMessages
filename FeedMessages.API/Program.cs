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
    typeof(CommandsMediatR.DeleteFeed.DeleteFeedCommand)
});

// Dependency injection:
builder.Services.AddScoped<IQueryFeedInfrastructure, QueryFeedRepository>();
builder.Services.AddScoped<ICommandFeedInfrastructure, CommandFeedRepository>();

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<FeedDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("FeedMessages.API").EnableRetryOnFailure()));

// Add RabbitMQ connection:
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration.GetValue<string>("RabbitMQ:Hosting:URL"), "/", h =>
        {
            h.Username(builder.Configuration.GetValue<string>("RabbitMQ:User_Credentials:Username"));
            h.Password(builder.Configuration.GetValue<string>("RabbitMQ:User_Credentials:Password"));
        });

        cfg.ConfigureEndpoints(context);
    });
});

// Configure RabbitMQ options
builder.Services.AddOptions<MassTransitHostOptions>().Configure(options =>
{
    // Waits until bus is started:
    options.WaitUntilStarted = true;

    // Limit wait time when starting the bus:
    options.StartTimeout = TimeSpan.FromSeconds(10);

    // Limit wait time when stopping the bus:
    options.StopTimeout = TimeSpan.FromSeconds(30);
});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
