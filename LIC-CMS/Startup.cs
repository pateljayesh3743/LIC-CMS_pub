using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LIC_CMS.Startup))]
namespace LIC_CMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
