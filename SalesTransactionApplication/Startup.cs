using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalesTransactionApplication.Startup))]
namespace SalesTransactionApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
