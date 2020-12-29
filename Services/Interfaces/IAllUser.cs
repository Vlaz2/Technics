using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technics.com.Models;

namespace Technics.com.Repository.Interfaces
{
    public interface IAllUser
    {
        List<User> GetAllUsers { get;}

        Task AddUserAsync(User user);

        User GetUserByEmail(string email);

        User GetUserById(long id);

        Task UpdateUserAsync(User newUser);

        User GetUserByToken(string token);
    }
}
