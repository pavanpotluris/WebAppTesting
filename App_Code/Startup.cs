using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppTesting.Startup))]
namespace WebAppTesting
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
