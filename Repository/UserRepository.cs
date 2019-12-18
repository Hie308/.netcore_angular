using CozaStorev2.Models;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Text;
using static Repository.Repository;

namespace Repository
{
    class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        public UserRepository(CozaStoreContext cozaContext)
            : base(cozaContext)
        {
        }
    }
}
