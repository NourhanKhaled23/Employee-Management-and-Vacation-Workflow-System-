using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        // Primary Key
        builder.HasKey(e => e.EmployeeNumber);

        // Properties
        builder.Property(e => e.EmployeeNumber)
            .HasMaxLength(6)
            .IsRequired();

        builder.Property(e => e.Name)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.GenderCode)
            .HasMaxLength(1);

        builder.Property(e => e.ReportedToEmployeeNumber) // Configure FK column
            .HasMaxLength(6)
            .IsRequired(false);

        builder.Property(e => e.VacationDaysLeft)
            .IsRequired();

        builder.Property(e => e.Salary)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        // Relationships
        builder.HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Position)
            .WithMany(p => p.Employees)
            .HasForeignKey(e => e.PositionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ReportedTo) 
            .WithMany() 
            .HasForeignKey(e => e.ReportedToEmployeeNumber) // FK column
            .OnDelete(DeleteBehavior.Restrict);

        
    }
}
