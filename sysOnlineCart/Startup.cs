using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sysOnlineCart.Startup))]
namespace sysOnlineCart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
