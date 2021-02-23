using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Z_Market2.Startup))]
namespace Z_Market2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
