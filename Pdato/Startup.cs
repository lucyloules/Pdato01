using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pdato.Startup))]
namespace Pdato
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
