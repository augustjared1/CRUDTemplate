using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportsDB.Startup))]
namespace SportsDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
