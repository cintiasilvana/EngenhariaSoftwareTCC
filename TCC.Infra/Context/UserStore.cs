using TCC.Domain.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TCC.Infra.Context
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class UserStore : UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public UserStore(AcademiaContext context)
            : base(context)
        {
        }
    }
}
