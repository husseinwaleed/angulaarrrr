using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(angularwebb.Startup))]
namespace angularwebb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
