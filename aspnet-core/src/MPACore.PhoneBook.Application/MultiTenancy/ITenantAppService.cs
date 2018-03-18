using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MPACore.PhoneBook.MultiTenancy.Dto;

namespace MPACore.PhoneBook.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
