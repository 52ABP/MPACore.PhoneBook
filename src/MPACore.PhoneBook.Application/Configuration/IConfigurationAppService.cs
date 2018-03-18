using System.Threading.Tasks;
using MPACore.PhoneBook.Configuration.Dto;

namespace MPACore.PhoneBook.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
