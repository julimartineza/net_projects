using UCR.ECCI.PI.Backend.Presentation.Buildings.Endpoints;
using UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Endpoints;
using UCR.ECCI.PI.Backend.Presentation.Unit.Endpoints;
using UCR.ECCI.PI.Backend.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using UCR.ECCI.PI.Backend.Presentation.LearningObjects.Endpoints;

using UCR.ECCI.PI.Backend.Presentation.Users.Endpoints;

using UCR.ECCI.PI.Backend.Presentation.Trees.Endpoints;


var builder = WebApplication.CreateBuilder(args);


// Adds Microsoft Identity platform (Azure AD B2C) support to protect this Api
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApi(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options);

    options.TokenValidationParameters.NameClaimType = "name";
},
options => { builder.Configuration.Bind("AzureAdB2C", options); });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor ingrese el token JWT con el prefijo 'Bearer '",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.RegisterCleanArchitectureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.RegisterBuildingEndpoints();
app.RegisterLearningSpaceEndpoints();
app.RegisterPhysicalUnitEndpoints();
app.RegisterAdministrativeUnitEndpoints();
app.RegisterLearningObjectEndpoints();

app.RegisterPersonEndpoints();
app.RegisterUserEndpoints();

app.RegisterTreeEndpoints();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
