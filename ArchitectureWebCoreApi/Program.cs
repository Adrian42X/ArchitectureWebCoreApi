using ArchitectureWebCoreApi.Authentication;
using BL.Messages.Services;
using BL.Users.Services;
using Core.Contracts;
using Core.Repositories;
using DA.Messages;
using DA.Users;
using Microsoft.AspNetCore.Authentication;
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
builder.Services.AddDataProtection();

builder.Services.AddDbContext<ProjectContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectConnection")));

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<IMessageRepository, MessageRepository>();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<ProjectContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions,BasicAuthenticationHandler>("BasicAuthentication",null);
builder.Services.AddAuthorization();

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

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
