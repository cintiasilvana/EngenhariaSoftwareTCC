
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using TCC.Domain.Identity;
using TCC.Domain.Objects;
using TCC.Infra.Context;

namespace TCC.Infra.Migrations
{
    public class UserSeed
    {
        public static void Seed(AcademiaContext context)
        {
            CreateRoles(context);
            CreateAdminRole(context);
        }

        private static void CreateAdminRole(AcademiaContext context)
        {
            if (!context.Users.Any(u => u.UserName.Contains("Admin")))
            {
                var store = new UserStore(context);
                var manager = new UserManager<ApplicationUser, int>(store);
                var user = new ApplicationUser { UserName = "admin@tcc.com", Email = "admin@tcc.com" };

                manager.Create(user, "Tcc12345");
                manager.AddToRole(user.Id, "Admin");
            }
        }

        private static void CreateRoles(AcademiaContext context)
        {
            if (!context.Roles.Any(r => r.Name.Contains("Admin")))
            {
                var store = new RoleStore<ApplicationRole, int, ApplicationUserRole>(context);
                var manager = new RoleManager<ApplicationRole, int>(store);

                var role = new List<ApplicationRole> {
                    new ApplicationRole { Name = eTipoPerfil.Admin.ToString() },
                    new ApplicationRole { Name = "Cliente" },
                    new ApplicationRole { Name = eTipoPerfil.Instrutor.ToString() }
                  };

                role.ForEach(r =>
                {
                    manager.Create(r);
                });
            }
        }
    }
}
