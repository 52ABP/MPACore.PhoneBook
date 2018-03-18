using Abp.AutoMapper;
using MPACore.PhoneBook.Sessions.Dto;

namespace MPACore.PhoneBook.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
