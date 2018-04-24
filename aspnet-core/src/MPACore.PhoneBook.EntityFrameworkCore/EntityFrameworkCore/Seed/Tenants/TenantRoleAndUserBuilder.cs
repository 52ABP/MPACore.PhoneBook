using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using MPACore.PhoneBook.Authorization;
using MPACore.PhoneBook.Authorization.Roles;
using MPACore.PhoneBook.Authorization.Users;
using MPACore.PhoneBook.PhoneBooks.Persons;
using MPACore.PhoneBook.PhoneBooks.PhoneNumbers;

namespace MPACore.PhoneBook.EntityFrameworkCore.Seed.Tenants
{
    public class TenantRoleAndUserBuilder
    {
        private readonly PhoneBookDbContext _context;
        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(PhoneBookDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            CreateRolesAndUsers();
            CreatePhone();
        }

        private void CreateRolesAndUsers()
        {
            // Admin role

            var adminRole = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Tenants.Admin);
            if (adminRole == null)
            {
                adminRole = _context.Roles.Add(new Role(_tenantId, StaticRoleNames.Tenants.Admin, StaticRoleNames.Tenants.Admin) { IsStatic = true }).Entity;
                _context.SaveChanges();
            }

            // Grant all permissions to admin role

            var grantedPermissions = _context.Permissions.IgnoreQueryFilters()
                .OfType<RolePermissionSetting>()
                .Where(p => p.TenantId == _tenantId && p.RoleId == adminRole.Id)
                .Select(p => p.Name)
                .ToList();

            var permissions = PermissionFinder
                .GetAllPermissions(new PhoneBookAuthorizationProvider())
                .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant) &&
                            !grantedPermissions.Contains(p.Name))
                .ToList();

            if (permissions.Any())
            {
                _context.Permissions.AddRange(
                    permissions.Select(permission => new RolePermissionSetting
                    {
                        TenantId = _tenantId,
                        Name = permission.Name,
                        IsGranted = true,
                        RoleId = adminRole.Id
                    })
                );
                _context.SaveChanges();
            }

            // Admin user

            var adminUser = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == AbpUserBase.AdminUserName);
            if (adminUser == null)
            {
                adminUser = User.CreateTenantAdminUser(_tenantId, "admin@defaulttenant.com");
                adminUser.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(adminUser, "123qwe");
                adminUser.IsEmailConfirmed = true;
                adminUser.IsActive = true;

                _context.Users.Add(adminUser);
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, adminUser.Id, adminRole.Id));
                _context.SaveChanges();

                // User account of admin user
                if (_tenantId == 1)
                {
                    _context.UserAccounts.Add(new UserAccount
                    {
                        TenantId = _tenantId,
                        UserId = adminUser.Id,
                        UserName = AbpUserBase.AdminUserName,
                        EmailAddress = adminUser.EmailAddress
                    });
                    _context.SaveChanges();
                }
            }
        }
        private void CreatePhone()
        {
            var defaultPhone = _context.Persons.FirstOrDefault(p => p.EmailAddress == "admin@yoyocms.com");
            if (defaultPhone == null)
            {
                _context.Persons.Add(new Person()
                {
                    Name = "张三",
                    EmailAddress = "admin@yoyocms.com",
                    PhoneNumbers = new List<PhoneNumber>()
                    {
                        new PhoneNumber() {Type = PhoneNumberType.Company,Number = "87115555"},
                        new PhoneNumber() {Type = PhoneNumberType.Home,Number = "010-1109"}
                    }
                });
            }
            var defaultPerson = _context.Persons.FirstOrDefault(p => p.EmailAddress == "lisi@yoyocms.com");
            if (defaultPerson == null)
            {
                _context.Persons.Add(new Person()
                {
                    Name = "李四",
                    EmailAddress = "lisi@yoyocms.com",
                    PhoneNumbers = new List<PhoneNumber>()
                    {
                        new PhoneNumber() {Type = PhoneNumberType.Company,Number = "88452675"},
                        new PhoneNumber() {Type = PhoneNumberType.Home,Number = "010-441109"}
                    }
                });
            }
            _context.SaveChanges();

        }




    }
}
