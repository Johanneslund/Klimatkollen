using Grupp7.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    //Detta är hårdkodad testdata
    public class MockRepository : IRepository
    {

        private List<User> users = new List<User>();

        public MockRepository()
        {
            User user = new User()
            {
                UserId = 1,
                Firstname = "Martin",
                Lastname = "Timell",
                Username = "Bajsmannen",
                Email = "Marreparre@live.se",
                Password = "lllll",
                Phone = "07228321"

            };
            users.Add(user);
        }

        public User GetUser(int id) 
        {
            return users.Where(x => x.UserId.Equals(id)).FirstOrDefault();
        
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public List <User> GetUsers() => users;

        public List<Animal> GetAnimals()
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
            throw new NotImplementedException();
        }

        public Animal getAnimal(int id)
        {
            throw new NotImplementedException();
        }

        public void updateAimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public List<Weather> GetWeathers()
        {
            throw new NotImplementedException();
        }
    }
}
