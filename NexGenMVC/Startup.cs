using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NexGenMVC.Startup))]
namespace NexGenMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
