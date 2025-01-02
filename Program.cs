using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using squirrels.Services;
using Squirrels.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "your-issuer",
            ValidAudience = "your-audience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key-123-8888777766665555"))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireClaim("Role", "Admin"));
});


// Adding controllers
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

// Add Swagger middleware
builder.Services.AddSwaggerGen(c =>
{
    // Add Security Definition
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization", // Specifies the name of the header where the token will be passed
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey, // Defines the security scheme type as an API key (used for passing tokens in headers)
        Scheme = "Bearer", // Identifies the type of token; here it's "Bearer" for JWT
        BearerFormat = "JWT", // Specifies the format of the token (JSON Web Token - JWT)
        In = Microsoft.OpenApi.Models.ParameterLocation.Header, // Indicates that the token should be passed in the HTTP request header
        Description = "Enter 'Bearer' followed by your JWT token in the text box. Example: Bearer abc123"
        // Provides a description to guide users on how to input the token (e.g., "Bearer <your-token>")
    });

    // Add Security Requirement
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme, // Refers to the security scheme defined above
                    Id = "Bearer" // The ID must match the ID used in the security definition
                }
            },
            new string[] { } // Specifies that no specific scopes are required for this scheme
        }
    });
});


// Register Services for dependency injection
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/health", () =>
{
    return "ok";
})
.WithName("health");

app.Run();

// pw admin
// port 5432