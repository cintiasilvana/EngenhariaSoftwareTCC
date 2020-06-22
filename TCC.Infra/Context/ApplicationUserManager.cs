
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TCC.Domain.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin;

namespace TCC.Infra.Context
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store)
            : base(store)
        {
        }

        private readonly AcademiaContext _db = new AcademiaContext();

        private readonly RoleManager<ApplicationRole, int> _roleManager = new RoleManager<ApplicationRole, int>(
            new RoleStore(new AcademiaContext()));

        private readonly UserManager<ApplicationUser, int> _userManager = new UserManager<ApplicationUser, int>(
            new UserStore(new AcademiaContext()));

        public bool RoleExists(string name)
        {
            return _roleManager.RoleExists(name);
        }

        public async Task<bool> IsUserLockoutByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                if (user.LockoutEnabled)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task ActiveUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                user.LockoutEnabled = false;
                user.LockoutEndDateUtc = null;
            }

            _userManager.Update(user);
        }


        public IdentityResult CreateRole(string name, string description = "")
        {
            return _roleManager.Create(new ApplicationRole { Name = name });
        }

        public List<ApplicationRole> GetRoles()
        {
            return _roleManager.Roles.ToList();
        }

        public List<UserDto> GetUsersInRole(int idRole)
        {           
            return Users.Where(c => c.Roles.Any(r => r.RoleId == idRole))
                .Select(c => new UserDto
                {
                    Id = c.Id,
                    IdPerfil = idRole,
                    Nome = c.UserName
                }).ToList();
        }

        //public int CreateUserRole(ColaboradorDto colaborador)
        //{
        //    var user = new ApplicationUser { UserName = colaborador.Email, Email = colaborador.Email };

        //    var isSucceed = _userManager.Create(user, colaborador.Password).Succeeded;
        //    if (isSucceed)
        //    {
        //        _userManager.AddToRole(user.Id, colaborador.IdPerfil.ToString());
        //    }
        //    return user.Id;
        //}

        public void ClearUserRoles(int userId)
        {
            var user = _userManager.FindById(userId);
            var currentRoles = new List<ApplicationUserRole>();

            currentRoles.AddRange(user.Roles);

            foreach (var role in currentRoles)
            {
                _userManager.RemoveFromRole(userId, role.RoleId.ToString());
            }
        }

        public void UpdateUser(ApplicationUser user, string role)
        {
            var oldUser = _userManager.FindById(user.Id);
            if (oldUser == null)
            {
                return;
            }

            var oldRoleId = oldUser.Roles.SingleOrDefault()?.RoleId;
            var oldRoleName = _roleManager.Roles.SingleOrDefault(r => r.Id == oldRoleId)?.Name;

            if (oldRoleName != null && oldRoleName != role)
            {
                _userManager.RemoveFromRole(user.Id, oldRoleName);
                _userManager.AddToRole(user.Id, role);
            }

            if (string.IsNullOrEmpty(user.PasswordHash))
            {
                return;
            }

            oldUser.PasswordHash = user.PasswordHash;
            oldUser.Email = user.Email;
            oldUser.UserName = user.Email;

            _userManager.Update(oldUser);
            _userManager.UpdateSecurityStamp(user.Id);
        }

        public void UpdateUserFirstAccess(int userId)
        {
            var oldUser = _userManager.FindById(userId);
            oldUser.FirstAccess = true;

            _userManager.Update(oldUser);
            _userManager.UpdateSecurityStamp(oldUser.Id);
        }


        public void UpdateUserCeo(int userId)
        {
            var oldUser = _userManager.FindById(userId);
            //oldUser.Ceo = true;

            _userManager.Update(oldUser);
        }


        public void DisabledUser(int userId)
        {
            var oldUser = _userManager.FindById(userId);
            if (oldUser != null)
            {
                oldUser.LockoutEndDateUtc = new DateTime(9999, 12, 30);
                oldUser.LockoutEnabled = true;

                _userManager.Update(oldUser);
            }
        }

        public void DeleteUser(int id)
        {
            var oldUser = _userManager.FindById(id);

            ClearUserRoles(id);
            _userManager.Delete(oldUser);
        }


        public void RemoveFromRole(int userId, string roleName)
        {
            _userManager.RemoveFromRole(userId, roleName);
        }

        public void DeleteRole(int roleId)
        {
            IQueryable<ApplicationUser> roleUsers = _db.Users.Where(u => u.Roles.Any(r => r.RoleId == roleId));
            ApplicationRole role = _db.Roles.Find(roleId);

            foreach (ApplicationUser user in roleUsers)
            {
                RemoveFromRole(user.Id, role.Name);
            }
            _db.Roles.Remove(role);
            _db.SaveChanges();
        }

        //public async Task<IdentityResult> ChangePassword(int userId, string newPassword)
        //{
        //    var token = await _userManager.GeneratePasswordResetTokenAsync(userId);
        //    var result = await _userManager.ResetPasswordAsync(userId, token, newPassword);

        //    return result;
        //}   

        public void CreateUserClaim(List<ApplicationUserClaim> userClaim)
        {
            userClaim.ForEach(c =>
            {
                _db.Claim.Add(c);
            });
            _db.SaveChanges();

        }

        public List<ApplicationUserClaim> GetUserClaim(int userId)
        {
            var claimUser = _db.Claim.Where(c => c.UserId == userId).ToList();
            return claimUser;
        }

        public List<ApplicationUserClaim> GetUserClaim(List<int> userId, List<ApplicationUserClaim> claims)
        {
            var claimUser = _db.Claim.Where(c => userId.Contains(c.UserId)).ToList();

            var result = claimUser.Where(c => claims.Any(d => c.ClaimType == d.ClaimType && c.ClaimValue == d.ClaimValue)).ToList();
            return result;
        }

        public void DeleteUserClaim(List<int> userId, List<ApplicationUserClaim> claims)
        {
            var claimsAll = GetUserClaim(userId, claims);

            foreach (var item in claimsAll)
            {
                _db.Claim.Remove(item);
            }
            _db.SaveChanges();
        }

        public void DeleteUserClaim(int userId, List<ApplicationUserClaim> claims)
        {
            var claimsAll = _userManager.GetClaims(userId);
            var claimFilter = claims?
                .Select(c => claimsAll.FirstOrDefault(d => d.Type == c.ClaimType && d.Value == c.ClaimValue))
                .ToList();

            foreach (var item in claimFilter)
            {
                if (item != null)
                {
                    _userManager.RemoveClaim(userId, item);
                }
            }
        }

        public void DeleteUserClaim(int userId)
        {
            var claims = GetUserClaim(userId);
            foreach (var item in claims)
            {
                _db.Claim.Remove(item);
            }
            _db.SaveChanges();

        }


        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore(context.Get<AcademiaContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser, int>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser, int>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, int>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }



        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            var msg = new MailMessage
            {
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true
            };

            msg.To.Add(message.Destination);

            // Plug in your email service here to send an email.
            using (var client = new SmtpClient())
            {
                await client.SendMailAsync(msg);
            }
        }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public int IdPerfil { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; internal set; }
    }
}
