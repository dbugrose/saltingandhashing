using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        internal bool AddUser(CreateAccountDTO userToAdd)
        {
            throw new NotImplementedException();
        }
    }
}