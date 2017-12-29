using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iAttend.Startup))]
namespace iAttend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
