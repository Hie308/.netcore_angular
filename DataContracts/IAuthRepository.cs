using CozaStorev2.Models;
using EntityModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts
{
    public interface IAuthRepository
    {
        UserDto Register(Users user);
        Users Login(string email, string password);
        bool IsUserExists(string email);

    }
}
