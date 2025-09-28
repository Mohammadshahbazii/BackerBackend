using Backer.Application;
using Backer.Core.Interfaces;
using Backer.Infrastructure;
using Backer.Infrastructure.Data;
using Backer.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

//Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddMemoryCache();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region JWT
builder.Services.AddScoped<ITokenService, JwtTokenService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
#endregion JWT

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Helps debug 500 errors
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseRouting();

//app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();