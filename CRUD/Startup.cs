using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.MemoryStorage;
using CRUD.Job;

[assembly: OwinStartupAttribute(typeof(CRUD.Startup))]
namespace CRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //ConfigureHangfire(app);

            //GlobalConfiguration.Configuration.UseMemoryStorage();
            //app.UseHangfireServer();
            //app.UseHangfireDashboard(); // optional, browse to /hangfire

            //RecurringJob.AddOrUpdate(
            //    "auto-reverify-payments",
            //    () => PaymentAutoReverifyJob.Run(),
            //    "*/1 * * * *");
        }
    }
}
