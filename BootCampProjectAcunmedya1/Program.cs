using Business;
using Business.BusinessRules;
using Business.Profiles;
using Business.Services;
using Business.Services.Managers;
using Core.Middleware;
using Core.Repositories;
using Core.Security;
using DataAccess.Connection;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBlacklistService, BlacklistManager>();
builder.Services.AddScoped<IApplicationService, ApplicationManager>();
builder.Services.AddScoped<IBootcampService, BootcampManager>();
builder.Services.AddScoped<IApplicantService, ApplicantManager>();
builder.Services.AddScoped<IBootcampService, BootcampManager>();
builder.Services.AddScoped<IEmployeeService, EmployeeManager>();
builder.Services.AddScoped<IInstructorService, InstructorManager>();
builder.Services.AddScoped<IAuthService, AuthManager>();
//// AutoMapper
builder.Services.AddAutoMapper(typeof(EmployeeProfile));
builder.Services.AddAutoMapper(typeof(ApplicantProfile));
builder.Services.AddAutoMapper(typeof(ApplicationProfile));
builder.Services.AddAutoMapper(typeof(BlacklistProfile));
builder.Services.AddAutoMapper(typeof(BootcampProfile));
builder.Services.AddAutoMapper(typeof(InstructorProfile));
builder.Services.AddAutoMapper(typeof(UserProfile));



builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IBlacklistRepository, BlacklistRepository>();
builder.Services.AddScoped<IBootcampRepository, BootcampRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddScoped<ApplicantBusinessRules>();
builder.Services.AddScoped<ApplicationBusinessRules>();
builder.Services.AddScoped<BlacklistBusinessRules>();
builder.Services.AddScoped<BootcampBusinessRules>();
//builder.Services.AddScoped<EmployeeBusinessRules>();
//builder.Services.AddScoped<InstructorBusinessRules>();
//builder.Services.AddScoped<UserBusinessRules>();

builder.Services.AddScoped<ITokenHelper, JwtHelper>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
