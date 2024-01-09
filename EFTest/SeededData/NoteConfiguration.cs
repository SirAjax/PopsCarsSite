using EFTest.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EFTest.SeededData;
public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
	public void Configure(EntityTypeBuilder<Note> builder)
	{
		builder.HasData(new Note(1, 1, 1, "this car should be a Chevy Biscayne"));
	}
}


