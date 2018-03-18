using System.Threading.Tasks;
using Abp.Application.Services;
using MPACore.PhoneBook.Sessions.Dto;

namespace MPACore.PhoneBook.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
