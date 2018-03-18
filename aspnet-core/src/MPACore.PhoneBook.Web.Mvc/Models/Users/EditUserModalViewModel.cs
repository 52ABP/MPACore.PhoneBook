using System.Collections.Generic;
using System.Linq;
using MPACore.PhoneBook.Roles.Dto;
using MPACore.PhoneBook.Users.Dto;

namespace MPACore.PhoneBook.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
