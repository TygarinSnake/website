﻿using AuthenticationService.Entitys;
using AuthenticationService.Helpers;
using AuthenticationService.Models;

namespace AuthenticationService.Services
{
    public class UserService : IUserService
    {
        //private readonly IEfRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        //private readonly IMapper _mapper;

        public UserService(/*IEfRepository<User> userRepository,*/ IConfiguration configuration/*, IMapper mapper*/)
        {
            //_userRepository = userRepository;
            _configuration = configuration;
            //_mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            User user = new User();
            //var user = _userRepository
            //    .GetAll()
            //    .FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null)
            {
                // todo: need to add logger
                return null;
            }

            var token = _configuration.GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task<AuthenticateResponse> Register(User userModel)
        {
            User user = new User();
            //var user = _mapper.Map<User>(userModel);

            //var addedUser = await _userRepository.Add(user);

            var response = Authenticate(new AuthenticateRequest
            {
                Username = user.Username,
                Password = user.Password
            });

            return response;
        }

        public IEnumerable<User> GetAll()
        {
            //return _userRepository.GetAll();
            return new List<User>();
        }

        public User GetById(int id)
        {
            //return _userRepository.GetById(id);
            return new User();
        }
    }
}
