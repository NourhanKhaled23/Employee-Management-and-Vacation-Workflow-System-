using BackendFirstProject.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendFirstProject.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<VacationRequest> VacationRequests { get; set; }
    public DbSet<VacationType> VacationTypes { get; set; }
    public DbSet<RequestState> RequestStates { get; set; }
    public DbSet<EmployeeVacationApproval> EmployeeVacationApprovals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Entity Configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

     
        SeedRequestStates(modelBuilder);
        SeedVacationTypes(modelBuilder);
    }

    private static void SeedRequestStates(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RequestState>().HasData(
            new RequestState { StateId = 1, StateName = "Submitted" },
            new RequestState { StateId = 2, StateName = "Approved" },
            new RequestState { StateId = 3, StateName = "Declined" }
        );
    }

    private static void SeedVacationTypes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VacationType>().HasData(
            new VacationType { VacationTypeCode = "S", VacationTypeName = "Sick" },
            new VacationType { VacationTypeCode = "U", VacationTypeName = "Unpaid" },
            new VacationType { VacationTypeCode = "A", VacationTypeName = "Annual" },
            new VacationType { VacationTypeCode = "O", VacationTypeName = "Day Off" },
            new VacationType { VacationTypeCode = "B", VacationTypeName = "Business Trip" }
        );
    }
}

