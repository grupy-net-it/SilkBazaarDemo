using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SilkBazaar.Startup))]
namespace SilkBazaar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
