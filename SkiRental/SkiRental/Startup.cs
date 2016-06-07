using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkiRental.Startup))]
namespace SkiRental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
