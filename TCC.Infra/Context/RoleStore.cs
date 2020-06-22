using TCC.Domain.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TCC.Infra.Context
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class RoleStore : RoleStore<ApplicationRole, int,  ApplicationUserRole>
    {
        public RoleStore(AcademiaContext context)
            : base(context)
        {
        }
    }
}
