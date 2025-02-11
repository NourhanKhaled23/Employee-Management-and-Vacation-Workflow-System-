using BackendFirstProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendFirstProject.Infrastructure.Data.Configurations;

public class EmployeeVacationApprovalConfiguration : IEntityTypeConfiguration<EmployeeVacationApproval>
{
    public void Configure(EntityTypeBuilder<EmployeeVacationApproval> builder)
    {
        // Composite Primary Key
        builder.HasKey(eva => new { eva.EmployeeNumber, eva.VacationRequestId });

        // Relationships
        builder.HasOne(eva => eva.Employee)
            .WithMany()
            .HasForeignKey(eva => eva.EmployeeNumber)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(eva => eva.VacationRequest)
            .WithMany()
            .HasForeignKey(eva => eva.VacationRequestId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}