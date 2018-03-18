using Abp.Authorization;
using MPACore.PhoneBook.Authorization.Roles;
using MPACore.PhoneBook.Authorization.Users;

namespace MPACore.PhoneBook.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
