using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(I4GUI_eksamen_2016_sommer_Web.Startup))]
namespace I4GUI_eksamen_2016_sommer_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
