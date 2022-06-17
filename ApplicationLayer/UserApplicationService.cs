using DomainLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public class UserApplicationService : IUserApplicationService
    {

        private readonly IUserDomainService _domain;

        public UserApplicationService(IUserDomainService domain)
        {
            _domain = domain;

        }


        public List<User> GetUsersApp()
        {
            return _domain.GetUsersDomain();

        }



    }
}
