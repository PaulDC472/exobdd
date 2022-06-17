using Entities;
using InfrastructureLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class UserDomainService : IUserDomainService
    {

        private readonly IUserRepository _repository;


        public UserDomainService(IUserRepository repository)
        {
            _repository = repository;

        }


        public List<User> GetUsersDomain()
        {

            try
            {
                return
                _repository.GetUsersRepo();
            }
            catch (Exception e)
            {
                //throw new DomainException("Pb de récupération de la météo"); 
            }

            return new List<User>();
        }



    }
}
