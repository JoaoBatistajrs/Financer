using FinancialManager.Domain.Models;
using FinancialManager.InfraStructure.Repositories;
using FinancialManager.Services.Interface;

namespace FinancialManager.Services.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly RegisterRepository _registerRepository;

        public RegisterService(RegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

    }
}
