using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using DataLayer.DBContext;

[assembly: OwinStartup(typeof(Test.API.Startup))]

namespace Test.API
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //Configure the db context to use a single instance per request
            app.CreatePerOwinContext(TestContext.Create);
        }
    }
}
