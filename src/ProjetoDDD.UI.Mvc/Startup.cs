using ProjetoDDD.UI.Mvc;
using Microsoft.Owin;
using Owin;

/*[assembly: OwinStartup(typeof(Startup))]*/
namespace ProjetoDDD.UI.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
