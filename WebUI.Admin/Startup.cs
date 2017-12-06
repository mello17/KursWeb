using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebUI.Admin.Startup))]
namespace WebUI.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
