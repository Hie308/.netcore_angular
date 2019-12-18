using CozaStorev2.Models;
using DataContracts;
using EntityModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class AuthRepository : IAuthRepository
    {
       

        private readonly CozaStoreContext _context;
        public AuthRepository(CozaStoreContext context)
        {
            _context = context;
        }
        public bool IsUserExists(string email)
        {
            if (_context.Users.Any(x => x.Email == email))
                return true;
            return false;
        }

        public Users Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
                return null;
            if (user.Password != password)
                return null;
          
            return user;
        }


        public UserDto Register(Users user)
        {
            
            _context.Users.Add(user);
            _context.SaveChanges();
            UserDto result = new UserDto()
            {
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber
            };
            return result;
        }
    }
}
