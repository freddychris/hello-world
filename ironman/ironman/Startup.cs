using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ironman.Startup))]
namespace ironman
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
