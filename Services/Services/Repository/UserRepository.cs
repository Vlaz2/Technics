using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technics.com.Models;
using Technics.com.Repository.Interfaces;

namespace Technics.com.Repository
{
    public class UserRepository : IAllUser
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public List<User> GetAllUsers => appDbContext.Users.Include(x=>x.Orders).ThenInclude(x=>x.ProductsOrders).ToList();

        public async Task AddUserAsync(User user)
        {
            await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
        }


        public User GetUserByEmail(string email)
        {
            return GetAllUsers.FirstOrDefault(x => x.Email == email);
        }

        public User GetUserById(long id)
        {
            return GetAllUsers.FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateUserAsync(User newUser)
        {
            appDbContext.Users.Update(newUser);
            await appDbContext.SaveChangesAsync();
        }

        public User GetUserByToken(string token)
        {
            return GetAllUsers.FirstOrDefault(x => x.Token == token);
        }
    }
}
