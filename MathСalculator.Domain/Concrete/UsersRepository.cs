using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathСalculator.Domain.Abstract;
using MathСalculator.Domain.Entities;

namespace MathСalculator.Domain.Concrete
{
    public class UsersRepository : IUserRepository
    {
        private MathCalculatorDB mathDb = new MathCalculatorDB();

        public bool Create(Users user)
        {
            if (user.Id == 0)
                mathDb.Users.Add(user);
            mathDb.SaveChanges();
            return false;
        }

        public bool Update(Users user)
        {
            var userOfDb = mathDb.Users.Find(user.Id);
            if (userOfDb == null)
                return false;

            userOfDb.Login = user.Login;
            userOfDb.Password = user.Password;
            userOfDb.Email = user.Email;
            mathDb.SaveChanges();
            return true;
        }

        public bool Authentication(string userNameorEmail, string userPassword)
        {
            var hash = userPassword.GetHashCode().ToString();
            var usersCount = mathDb.Users.Count(u => u.Login == userNameorEmail && u.Password == hash);
            return usersCount != 0;
        }

        public bool CheckExist(string userLogin)
        {
            var list = mathDb.Users.Count(m => m.Login.Equals(userLogin));
            return list != 0;
        }

        public bool Delete(Users user)
        {
            if (user == null)
                return false;

            var userForDelete = mathDb.Users.FirstOrDefault(p => p.Id == user.Id);
            mathDb.Users.Remove(userForDelete);
            mathDb.SaveChanges();
            return true;
        }

        public IQueryable<Users> Get
        {
            get
            {
                return mathDb.Users;
            }
        }
    }
}
