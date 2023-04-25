using EmployeeDirectory.DAL;
using EmployeeDirectory.Services.Contracts;
using EmployeeDirectory.Services.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);// It is a theft
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();//It is a theft
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
builder.Services.AddScoped<IEmployeeContract, EmployeeProvider>();
builder.Services.AddScoped<IOfficeContract, OfficeProvider>();
builder.Services.AddScoped<ITokenServicecs, TokenService>();
builder.Services.AddScoped<IDepartmentContract, DepartmentProvider>();
builder.Services.AddScoped<IDesignationContract, DesignationProvider>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());//It is a theft

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });
builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())//It is a theft
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
