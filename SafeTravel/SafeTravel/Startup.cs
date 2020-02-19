using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SafeTravel.Startup))]
namespace SafeTravel
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
