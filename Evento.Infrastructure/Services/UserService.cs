using Evento.Core.Domain;
using Evento.Core.Repositories;
using Evento.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;
        public UserService(IUserRepository userRepository, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
        }

        public async Task<TokenDto> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new Exception($"Invalid Credentials");
            }
            if (user.Password != password)
            {
                throw new Exception($"Invalid Credentials");
            }
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            return new TokenDto
            {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = user.Role
            };
        }

        public async Task RegisterAsync(Guid userId, string email, string name, string password, string role = "user")
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception($"User with email: '{email}' already exists.");
            }
            user = new User(userId, email, name, password, role);
            await _userRepository.AddAsync(user);
        }
    }
}
