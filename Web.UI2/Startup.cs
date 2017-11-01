using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.UI2.Startup))]
namespace Web.UI2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
