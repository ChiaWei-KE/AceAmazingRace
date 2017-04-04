using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AceAmazingRace.Startup))]
namespace AceAmazingRace
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
