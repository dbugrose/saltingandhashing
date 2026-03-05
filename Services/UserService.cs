using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using saltingandhashing.Models;
using saltingandhashing.Models.DTO;
using saltingandhashing.Services.Context;

namespace saltingandhashing.Services
{
    public class UserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }
        
        //need a helper method to check if user exists in database

        public bool DoesUserExist(string username)
        {
           //check our tables to see if the username exists
           return _context.UserInfo.SingleOrDefault(user => user.Username == username) != null;
        }        
        public bool AddUser(CreateAccountDTO userToAdd)
        {
            //we are going to need a Hash helper fucntion to help us hash our password
            //we need to set our newUser.Id =  UserToAdd.Id
            // Username
            // Salt
            // Hash

            //then we add it to our DataContext
            //save our changes 
            //return a bool to return true or false

            bool result = false;

            if(userToAdd.Username != null && !DoesUserExist(userToAdd.Username))
            {   UserModel newUser = new UserModel();
               var HashedPassword = HashPassword(userToAdd.Password);
               newUser.Id = userToAdd.Id;
               newUser.Username = userToAdd.Username;
               
               newUser.Salt = HashedPassword.Salt;
               newUser.Hash = HashedPassword.Hash;

               _context.Add(newUser);
               result  = _context.SaveChanges() != 0;
            }
            return result;

        }

        //function that will help us hash our password
        public PasswordDTO HashPassword(string? password)
        {
            PasswordDTO newHashedPassword = new PasswordDTO();
            byte[] SaltBytes = new byte[64];

            var provider = RandomNumberGenerator.Create();
            provider.GetNonZeroBytes(SaltBytes);

            var Salt = Convert.ToBase64String(SaltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password ?? "", SaltBytes, 10000, HashAlgorithmName.SHA256);

            var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = Hash;

            return newHashedPassword;
        }

        public bool VerifyUserPassword(string? Password, string? StoredHash, string? StoredSalt)
        {
           if (StoredSalt == null) 
           {return false;}

           var SaltBytes = Convert.FromBase64String(StoredSalt);

           var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password ?? "", SaltBytes, 10000, HashAlgorithmName.SHA256);

           var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
           return newHash == StoredHash;
        }
    }
}