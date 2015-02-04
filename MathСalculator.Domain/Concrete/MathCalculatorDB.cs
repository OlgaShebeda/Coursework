using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using MathСalculator.Domain.Entities;

namespace MathСalculator.Domain.Concrete
{
    class MathCalculatorDB: DbContext
    {
         public DbSet<Users> Users { get; set; }

         static MathCalculatorDB()
        {
            var ensureDllIsCopied = SqlProviderServices.Instance;
        }
    }
}
