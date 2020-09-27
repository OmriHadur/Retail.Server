using Core.Server.Web;
using Microsoft.Extensions.Configuration;

namespace Retail.Web
{
    public class Startup : CoreServerStartup
    {
        public Startup(IConfiguration configuration)
           : base(configuration)
        {
        }
    }
}
