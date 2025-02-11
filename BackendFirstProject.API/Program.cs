using BackendFirstProject.Core.Entities;
using BackendFirstProject.Core.Interfaces;
using BackendFirstProject.Infrastructure.Data;
using BackendFirstProject.Infrastructure.Repositories;
using BackendFirstProject.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Configure Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Register Repositories & Services
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<IVacationRequestRepository, VacationRequestRepository>();
builder.Services.AddScoped<VacationRequestService>();
builder.Services.AddScoped<DataSeeder>();

// ✅ Enable Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

var app = builder.Build();

// ✅ Migrations & Seed Data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();

    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

    if (!dbContext.Departments.Any() || !dbContext.Positions.Any())
    {
        Console.WriteLine("Seeding Departments & Positions...");
        dataSeeder.SeedDepartmentsAndPositions();
        Console.WriteLine("✅ Departments & Positions Seeding Completed.");
    }

    var employeeService = scope.ServiceProvider.GetRequiredService<EmployeeService>();

    if (!dbContext.Employees.Any())
    {
        Console.WriteLine(" Seeding Employees...");
        employeeService.AddEmployeeAsync(new Employee
        {
            EmployeeNumber = "E001",
            Name = "John Doe",
            DepartmentId = 1,
            PositionId = 1,
            Salary = 5000
        }).Wait(); // 🔥 Fix: Ensure async method runs in sync

        Console.WriteLine("✅ Employees Seeding Completed.");
    }
    else
    {
        Console.WriteLine("Employees already exist. Skipping seeding.");
    }
}

// ✅ Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
