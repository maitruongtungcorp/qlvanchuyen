using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaiNguyen.GUI.Startup))]
namespace MaiNguyen.GUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
