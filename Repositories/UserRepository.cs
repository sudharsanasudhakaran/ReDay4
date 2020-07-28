using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PeopleCRUD.Models;
namespace PeopleCRUD.Repositories
{
    class UserRepository : IUserRepository
    {
        public UserRepository()
        {
        }
            List<User> AllUserData = new List<User>();
            UsersDbContext _db = new UsersDbContext();
            public List<User> Users()
            {
                AllUserData = _db.users.ToList();
                if (AllUserData.Any())
                {
                    Console.WriteLine("Returned List of Users");
                }
                else
                {
                    Console.WriteLine("No data found");
                }
                return AllUserData;
            }
            public User GetUser(int id)
            {
                User person = _db.users.Where(a => a.id == id).FirstOrDefault();

                if (person != null)
                {
                    Console.WriteLine("Retrieving User Data with id=" + id);
                }
                else
                {
                    Console.WriteLine("There is no User with id=" + id);
                }
                return person;
            }

            public List<User> DeleteUser(int id)
            {
                User person = _db.users.Where(a => a.id == id).FirstOrDefault();
                if (person != null)
                {
                    _db.users.Remove(person);
                    _db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("no data found for this id");
                }
                return Users();
            }
            List<User> ActiveUser = new List<User>();
            public List<User> ActiveUsers()
            {
                var x = from u in _db.users
                        where u.isActive == true
                        select u;
                foreach (User activeuser in x)
                {
                    ActiveUser.Add(activeuser);
                }
                return ActiveUser;

            }

            public List<User> AddUser(User addUser)
            {
                _db.users.Add(addUser);
                _db.SaveChanges();
                return Users();
            }
        }
    }
}
