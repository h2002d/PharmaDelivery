using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PharmaDelivery.Startup))]
namespace PharmaDelivery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
