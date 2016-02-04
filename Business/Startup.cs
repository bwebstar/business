using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Business.Startup))]
namespace Business
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
