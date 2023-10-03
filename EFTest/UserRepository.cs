using EFTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest;
public class UserRepository
{
    private readonly PopsCarsContext _popsCarsContext;

    public UserRepository(PopsCarsContext popsCarsContext)
    {
        _popsCarsContext = popsCarsContext;
    }

    public User CreateUser(User user)
    {
        _popsCarsContext.Add(user);
        _popsCarsContext.SaveChanges();
        return user;
    }

    public List<User> GetAllUsers()
    {
        return _popsCarsContext.User.ToList();
    }

    public List<User> GetUserByName(string userName)
    {
        return _popsCarsContext.User.Where(a => a.UserName == userName).ToList();
    }

    public User? GetUserObject(string userName)
        {
        return _popsCarsContext.User.Where(a => a.UserName == userName).FirstOrDefault();
        }

    public User UpdateUser(User user)
    {
        User? currentUser =_popsCarsContext.User.Find(user.Id);
        _popsCarsContext.Entry(currentUser!).CurrentValues.SetValues(user);
        _popsCarsContext.SaveChanges();
        return user; 
    }

    public void DeleteUser(User user)
    {
        _popsCarsContext.Remove(user);
        _popsCarsContext.SaveChanges();
    }
    
}
