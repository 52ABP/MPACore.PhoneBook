using System.Threading.Tasks;
using Abp.Application.Services;
using MPACore.PhoneBook.Authorization.Accounts.Dto;

namespace MPACore.PhoneBook.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
