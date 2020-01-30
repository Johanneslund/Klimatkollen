using Grupp7.Data;
using Grupp7.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    //Detta är den skarpa databasen
    public class Repository : IRepository
    {
        private ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public User GetUser(int id) 
        {
            return context.Users.Where(x => x.UserId == id).FirstOrDefault();
        }

        public void  AddUser(User user)
        {
            context.Add(user);
            context.SaveChanges();
        }

        public List<User> GetUsers() 
        {
            return null;
        }
    }
}
