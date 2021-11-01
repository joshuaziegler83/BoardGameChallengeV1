using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoardGameChallengeV1.WebMVC.Startup))]
namespace BoardGameChallengeV1.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
