using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

public class VacationRequestConfiguration : IEntityTypeConfiguration<VacationRequest>
{
    public void Configure(EntityTypeBuilder<VacationRequest> builder)
    {
        // Primary Key
        builder.HasKey(vr => vr.RequestId);

        // Properties
        builder.Property(vr => vr.RequestSubmissionDate)
            .IsRequired();

        builder.Property(vr => vr.Description)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(vr => vr.StartDate)
            .IsRequired();

        builder.Property(vr => vr.EndDate)
            .IsRequired();

        builder.Property(vr => vr.TotalVacationDays)
            .IsRequired();

        // Relationships
     
        builder.HasOne(vr => vr.Employee)
            .WithMany(e => e.VacationRequests)
            .HasForeignKey(vr => vr.EmployeeNumber)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(vr => vr.VacationType)
            .WithMany(vt => vt.VacationRequests)
            .HasForeignKey(vr => vr.VacationTypeCode)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(vr => vr.RequestState)
            .WithMany(rs => rs.VacationRequests)
            .HasForeignKey(vr => vr.RequestStateId)
            .OnDelete(DeleteBehavior.Restrict);

        // ApprovedBy Employee Relationship
        builder.HasOne(vr => vr.ApprovedByEmployee)
            .WithMany()
            .HasForeignKey(vr => vr.ApprovedByEmployeeNumber)
            .OnDelete(DeleteBehavior.Restrict);

        // DeclinedBy Employee Relationship
        builder.HasOne(vr => vr.DeclinedByEmployee)
            .WithMany()
            .HasForeignKey(vr => vr.DeclinedByEmployeeNumber)
            .OnDelete(DeleteBehavior.Restrict);
    }
}