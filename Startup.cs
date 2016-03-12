using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PCDetailsWeb.Startup))]
namespace PCDetailsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
