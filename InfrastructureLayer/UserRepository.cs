using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public class UserRepository : IUserRepository
    {


        //injection de dependance du DbContext
        private DbContext SqlContext { get; }


        public UserRepository( DbContext context)
        {
            SqlContext = context;
        }


        public List<User> GetUsersRepo()
        {
                return SqlContext.Set<User>().ToList();            


        }
    }
}
