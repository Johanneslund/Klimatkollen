using Grupp7.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Interfaces
{
    public interface IRepository
    {
        User GetUser(int id);
        void Save(User user);
        List<User> GetUsers();

    }
}
