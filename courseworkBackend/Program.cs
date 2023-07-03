//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();



// ------------------------------

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddControllers();

// // Add CORS services.
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowMyOrigin",
//     builder =>
//     {
//         builder.WithOrigins("http://localhost:3000") // React Web app running URL
//             .AllowAnyHeader()
//             .AllowAnyMethod();
//     });
// });

// // Add Swagger services
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// app.UseCors("AllowMyOrigin"); // Use the CORS policy

// app.UseAuthorization();

// app.MapControllers();

// app.Run();

// ------------------------------


using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using courseworkBackend.DataStore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add CORS services.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
    builder =>
    {
        builder.WithOrigins("http://localhost:3000") // React Web app running URL
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add DbContext service
builder.Services.AddDbContext<FitnessDbContext>(options => 
    options.UseInMemoryDatabase("FitnessDb"));

// Add JWT Authentication services
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "thevinmalaka.com",
            ValidAudience = "thevinmalaka.com",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMySuperSecretKeyForFitnessAppInMyMSCourseWork"))
        };
    });

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowMyOrigin"); // Use the CORS policy

app.UseAuthentication(); // Use JWT Authentication

app.UseAuthorization();

app.MapControllers();

app.Run();

