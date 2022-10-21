using FinancialManager.Application.DTOs;
using FinancialManager.Application.DTOs.Validations;
using FinancialManager.Application.Services.Interface;
using FinancialManager.Domain.Authentication;
using FinancialManager.Domain.Repositories.Interface;

namespace FinancialManager.Application.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResultService<dynamic>> GenerateTokenAsync(UserDto userDto)
        {
            if (userDto == null)
                return ResultService.Fail<dynamic>("Objeto deve ser informado.");

            var validator = new UserDtoValidator().Validate(userDto);

            if (!validator.IsValid)
                return ResultService.RequestError<dynamic>("Problemas na validação.", validator);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(userDto.Email, userDto.Password);

            if (user == null)
                return ResultService.Fail<dynamic>("Usuário ou Senha não encontrados.");

            return ResultService.Ok(_tokenGenerator.Generator(user));
        }
    }
}
