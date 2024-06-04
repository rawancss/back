
using ApiWithJWT;
using ApiWithJWT.Data.Seeds;
using Microsoft.AspNetCore.Identity;
using ApiWithJWT.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddApplicationServices(builder.Configuration);

//add cors to connect with fron

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});


builder.Services.AddControllers();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigins");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// seeding data
using var scope = app.Services.CreateScope();
var scopedService = scope.ServiceProvider;
await DefaultRoles.SeedAsync(scopedService.GetRequiredService<RoleManager<Role>>());
await DefaultAdminUserData.SeedAsync(scopedService.GetRequiredService<UserManager<Account>>());

app.Run();
