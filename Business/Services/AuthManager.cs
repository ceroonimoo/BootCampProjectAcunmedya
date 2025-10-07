using AutoMapper;
using Business.Requests;
using Business.Responses;
using DataAccess.Repositories;
using Entity.Entities;
using Entity.Helpers;

namespace Business.Services
{
    public class AuthManager : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
        }

        public async Task<RegisteredUserResponse> RegisterAsync(RegisterUserRequest request)
        {
            if (await _userRepository.GetByEmailAsync(request.Email) != null)
                throw new Exception("Bu e-posta adresi zaten kayıtlı.");

            HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                NationalityIdentity = request.NationalityIdentity,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var token = _tokenHelper.CreateToken(user);

            return new RegisteredUserResponse
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                Token = token
            };
        }

        public async Task<LoggedInUserResponse> LoginAsync(LoginUserRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                throw new Exception("Kullanıcı bulunamadı.");

            if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Şifre hatalı.");

            var token = _tokenHelper.CreateToken(user);

            return new LoggedInUserResponse
            {
                Email = user.Email,
                Token = token
            };
        }
    }
}
