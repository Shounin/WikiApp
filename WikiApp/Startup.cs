using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WikiApp.Startup))]
namespace WikiApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
