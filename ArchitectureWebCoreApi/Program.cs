using BL.Messages.Services;
using BL.Users.Services;
using Core.Contracts;
using Core.Repositories;
using DA.Messages;
using DA.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectDatabase.Context;
using ProjectDatabase.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProjectContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectConnection")));

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRepository<ApplicationUser>, UserRepository>();
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<IRepository<Message>, MessageRepository>();

builder.Services.AddIdentityCore<ApplicationUser>()
    .AddEntityFrameworkStores<ProjectContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

//init database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProjectContext>();
    await context.Database.MigrateAsync();
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
