using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TemplateSourceCode.Startup))]
namespace TemplateSourceCode
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
