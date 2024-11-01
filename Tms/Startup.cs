using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tms.Startup))]
namespace Tms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }


    }
}
