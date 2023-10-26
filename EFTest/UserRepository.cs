using EFTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest;
public class UserRepository : IUserRepository
{
    private readonly PopsCarsContext _popsCarsContext;

    public UserRepository(PopsCarsContext popsCarsContext)
    {
        _popsCarsContext = popsCarsContext;
    }

    public async Task<User> CreateUser(User user)
    {
        _popsCarsContext.Add(user);
        await _popsCarsContext.SaveChangesAsync();
        return user;
    }
    public async Task<List<User>> GetAllUserAsync()
    {
        return await _popsCarsContext.User.ToListAsync();
    }

    public async Task<List<User>> GetUserByName(string userName)
    {
        return await _popsCarsContext.User.Where(a => a.UserName == userName).ToListAsync();  
    }

    public User? GetUserObject(string userName)
        {
        return _popsCarsContext.User.Where(a => a.UserName == userName).FirstOrDefault();
        }

    public User UpdateUser(User user)
    {
        User? currentUser =_popsCarsContext.User.Find(user.UserId);
        _popsCarsContext.Entry(currentUser!).CurrentValues.SetValues(user);
        _popsCarsContext.SaveChanges();
        return user; 
    }

    public void DeleteUser(User user)
    {
        User? currentUser = _popsCarsContext.User.OrderBy(i => i.UserId).FirstOrDefault(a => a.UserName == user.UserName);
        _popsCarsContext.Remove(currentUser!);
        _popsCarsContext.SaveChanges();
    }
    
}
