using EFTest.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EFTest.SeededData;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User("Pop", 1));
        builder.HasData(new User("AJ", 2));
        builder.HasData(new User("Michael", 3));
    }
}

    