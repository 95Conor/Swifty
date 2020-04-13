using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Data.Contracts.Services;
using Swifty.Core.Entities;
using Swifty.Data.Contracts.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Swifty.Data.Services
{
    public class UserService : IUserService<User>
    {
        private readonly IBaseRepository<User> _userRepository;

        public UserService(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        // Create user entity in Swifty if the email claim does not exist in any current users
        public async Task InitialiseLogin(string userEmail)
        {
            var allUsers = await _userRepository.ListAllAsync();

            if (!allUsers.Any(x => x.Email.ToLower() == userEmail.ToLower()))
            {
                User newUser = new User() { Email = userEmail };
                await _userRepository.AddAsync(newUser);
            }
        }

        public async Task<User> GetUserByEmail(string userEmail)
        {
            var allUsers = await _userRepository.ListAllAsync();

            return allUsers.FirstOrDefault(x => x.Email.ToLower() == userEmail.ToLower());
        }
    }
}
