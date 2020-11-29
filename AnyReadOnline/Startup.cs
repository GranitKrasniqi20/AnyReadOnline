using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnyReadOnline.Startup))]
namespace AnyReadOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
