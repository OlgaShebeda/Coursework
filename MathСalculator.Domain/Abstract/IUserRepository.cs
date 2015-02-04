using MathСalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathСalculator.Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<Users> Get { get; }
        bool Update(Users user);
        bool Create(Users user);
        bool Authentication(string userName, string userPassword);
        bool CheckExist(string userLogin);
        bool Delete(Users user);

    }
}
