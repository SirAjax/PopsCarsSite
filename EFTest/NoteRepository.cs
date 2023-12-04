
﻿using EFTest.Models;
using Microsoft.EntityFrameworkCore;

﻿using EFTest.GenericRepository;
using EFTest.Models;


namespace EFTest
{
	public class NoteRepository : GenericRepository<Note>, INoteRepository
	{
		public NoteRepository(PopsCarsContext popsCarsContext) : base(popsCarsContext)
		{

		}
	}
}
