
﻿using EFTest.Models;
using Microsoft.EntityFrameworkCore;

﻿using EFTest.GenericRepository;
using EFTest.Models;


namespace EFTest;
public class UserRepository : GenericRepository<User>, IUserRepository 
{	
	public UserRepository(PopsCarsContext popsCarsContext) : base(popsCarsContext)
	{
	}

}
