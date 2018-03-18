using System.Collections.Generic;
using MPACore.PhoneBook.Roles.Dto;
using MPACore.PhoneBook.Users.Dto;

namespace MPACore.PhoneBook.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
