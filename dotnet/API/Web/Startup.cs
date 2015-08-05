using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.Startup))]
namespace Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
