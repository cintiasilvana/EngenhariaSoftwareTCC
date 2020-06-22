using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TCC.Web.Startup))]
namespace TCC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
