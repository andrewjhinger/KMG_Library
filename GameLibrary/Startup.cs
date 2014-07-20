using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameLibrary.Startup))]
namespace GameLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
