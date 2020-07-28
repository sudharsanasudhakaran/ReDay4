
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using PeopleCRUD.Models;
using PeopleCRUD.Repositories;

namespace Day4
{
    public class Program
    {
        static void Main(string[] args)
        {
            UsersDbContext _db = new UsersDbContext();
            UserRepository initializeUser = new UserRepository();
            for (var i = 0; i < 10; i++)
            {
                User userData = new User();

                userData.Name = "Person1" + (i + 1);
                userData.Location = "Location1" + (i + 1);
                userData.Address = "Address1" + (i + 1);

                userData.Email = "person" + (i + 1) + "@gmail.com";
                userData.IsActive = (i + 1) % 2 == 0 ? true : false;
                _db.users.Add(userData);
                _db.SaveChanges();
            }

            List<User> AllUsers = new List<User>();
            AllUsers = initializeUser.Users();
            foreach (User users in AllUsers)
            {
                Console.WriteLine("Id:\t" + users.Id + "Name\t" + users.Name + "Email\t" + users.Email + "Location\t" + users.Location + "Address\t" + users.Address + "ActiveStatus\t" + users.IsActive);

            }

            User GetUser;
            Console.WriteLine("Enter the user id");

            int id = Convert.ToInt32(Console.ReadLine());

            GetUser = initializeUser.GetUser(id);

            Console.WriteLine("Id:\t" + GetUser.Id + "Name\t" + GetUser.Name + "Email\t" + GetUser.Email + "Location\t" + GetUser.Location + "Address\t" + GetUser.Address + "ActiveStatus\t" + GetUser.IsActive);

            Console.WriteLine("Enter the id to Delete");

            int DeleteUser = Convert.ToInt32(Console.ReadLine());

            List<User> DeleteUserList = new List<User>();

            DeleteUserList = initializeUser.DeleteUser(DeleteUser);

            Console.WriteLine("List after deletion");

            Console.WriteLine("Id \t Name \t Email \t \t \tLocation \tAddress\t\tActiveStatus");

            foreach (User users in DeleteUserList)
            {
                Console.WriteLine("Id:\t" + users.Id + "Name\t" + users.Name + "Email\t" + users.Email + "Location\t" + users.Location + "Address\t" + users.Address + "ActiveStatus\t" + users.IsActive);

            }

            Console.WriteLine();

            List<User> ActiveUser = new List<User>();

            ActiveUser = initializeUser.ActiveUsers();

            Console.WriteLine("Active Users in List");

            Console.WriteLine("Id \t Name \t Email \t \t \tLocation \tAddress\t\tActiveStatus");

            foreach (User users in ActiveUser)
            {
                Console.WriteLine("Id:\t" + users.Id + "Name\t" + users.Name + "Email\t" + users.Email + "Location\t" + users.Location + "Address\t" + users.Address + "ActiveStatus\t" + users.IsActive);

            }

            Console.WriteLine("Enter Users Details to add");

            User addUser = new User();

            Console.WriteLine("Enter User Name");
            addUser.Name = Console.ReadLine();

            Console.WriteLine("Enter User Email");
            addUser.Email = Console.ReadLine() + "\t";

            Console.WriteLine("Enter User Location");
            addUser.Location = Console.ReadLine();

            Console.WriteLine("Enter User Address");
            addUser.Address = Console.ReadLine() + "\t";

            Console.WriteLine("Enter User Activity Status");
            addUser.IsActive = Convert.ToBoolean(Console.ReadLine());

            List<User> UserListAfterAddition = new List<User>();
            UserListAfterAddition = initializeUser.AddUser(addUser);

            Console.WriteLine("Id \t Name \t Email \t \t \tLocation \tAddress\t\tActiveStatus");
            foreach (User users in UserListAfterAddition)
            {
                Console.WriteLine("Id:\t" + users.Id + "Name\t" + users.Name + "Email\t" + users.Email + "Location\t" + users.Location + "Address\t" + users.Address + "ActiveStatus\t" + users.IsActive);

            }

        }
    }
}