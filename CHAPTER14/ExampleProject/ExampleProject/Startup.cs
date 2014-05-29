using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExampleProject.Startup))]
namespace ExampleProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
