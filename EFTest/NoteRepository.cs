using EFTest.Models;
using Microsoft.EntityFrameworkCore;
using EFTest.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        public NoteRepository _noteRepository;
        public NoteRepository(PopsCarsContext popsCarsContext) : base(popsCarsContext)
        {

        }
      
      
    }
}
