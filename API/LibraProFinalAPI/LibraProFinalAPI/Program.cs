using LibraProFinalAPI.Model;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Hangfire;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

//Adding configuration variable
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

//builder.Services.AddControllers().AddJsonOptions(options =>
//{
  //  options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    //options.JsonSerializerOptions.MaxDepth = 64; 
//});

builder.Services.AddDbContext<LibraProFinalDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn"),

        sqlServerOptionsAction: sqlOptions => {
            sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(5),
            errorNumbersToAdd: null);
        });
});

//Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

//Authentication
.AddJwtBearer(Options =>
{
    Options.SaveToken = true;
    Options.RequireHttpsMetadata = false;
    Options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});

builder.Services.AddDbContext<LibraProFinalAPI.Model.LibraProFinalDataContext>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
        new string[]{}
       }
    });
});


//Uploading files in the database
builder.Services.Configure<FormOptions>(O =>
{
    O.ValueLengthLimit = int.MaxValue;
    O.MultipartBodyLengthLimit = int.MaxValue;
    O.MemoryBufferThreshold = int.MaxValue;
});

//Cors enabler
var _cors = "appCors";
builder.Services.AddCors(o =>
{
    o.AddPolicy(_cors, policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500").AllowAnyOrigin().AllowAnyHeader();
    });
});

// Register the NotificationTimerService
builder.Services.AddHostedService<NotificationTimerService>();


var app = builder.Build();

 //Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}

//Enable cors 
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseHangfireServer();
app.UseHangfireDashboard();