using DB;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PPI_web_Api.DB;
using PPI_web_Api.Service;
using PPI_web_Api.Mapper;
using Microsoft.EntityFrameworkCore.Internal;

var builder = WebApplication.CreateBuilder(args);


var secret = builder.Configuration.GetSection("Settings").GetSection("secretkey");
var secretBytes = Encoding.UTF8.GetBytes(secret.ToString());

builder.Services.AddAuthentication(conf =>
    {
        conf.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        conf.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(conf =>
    {
        conf.RequireHttpsMetadata = false;
        conf.SaveToken = true;
        conf.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<InitialData>();
builder.Services.AddScoped<OrdenService>();
builder.Services.AddAutoMapper(typeof(Orden_OrdenAccionDTO_profile)
                              ,typeof(Orden_OrdenBonoDTO_profile)
                              ,typeof(Orden_OrdenFCIDTO_profile)
                              ,typeof(Orden_OrdenDTO_profile)
                              ,typeof(OrdenDTO_Add_Orden_profile)
                              ,typeof(OrdenDTO_Orden_profile)
                              );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbPPIContext>(option => 
                    option.UseSqlServer(builder.Configuration.GetConnectionString("PPIDbConnection"))
);

var app = builder.Build();


using( var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DbPPIContext>();
    context.Database.EnsureCreated();
    context.Database.Migrate();

    scope.ServiceProvider.GetRequiredService<InitialData>().InitAll();
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

app.MapControllers();

app.Run();
