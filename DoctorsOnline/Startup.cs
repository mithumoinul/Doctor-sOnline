using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoctorsOnline.Startup))]
namespace DoctorsOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
