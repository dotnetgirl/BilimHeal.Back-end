using BilimHeal.Server.Domain.Entities;
using BilimHeal.Server.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BilimHeal.Server.DAL.Configuration;

public class AdminConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User()
        {
            Id = 3,
            FirstName = "Dilafruza",
            LastName = "Joraboyeva",
            PhoneNumber = "+998945096449",
            Password = "\"$2a$11$J2zT3dYr2GlgbLFd3.FrmOgHbdvuw2GA1nFfG4WL/f4uehALYXlrS\"",
            Salt = "\"f55d9b3b-4d07-4daa-9f3e-81c8f0d34f28\"",
            Role = UserRole.Admin,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        });
    }
}
