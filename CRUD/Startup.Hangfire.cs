using System;
using System.Collections.Generic;
using System.Configuration;
using CRUD.Jobs;
using Hangfire;
using Hangfire.MySql;
using MySql.Data.MySqlClient;
using Owin;

namespace CRUD
{
    public partial class Startup
    {
        private void ConfigureHangfireStorage()
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseStorage(new MySqlStorage(
                    GetHangfireConnectionString(),
                    new MySqlStorageOptions
                    {
                        QueuePollInterval = TimeSpan.FromSeconds(30),
                        JobExpirationCheckInterval = TimeSpan.FromHours(1),
                        CountersAggregateInterval = TimeSpan.FromMinutes(5),
                        PrepareSchemaIfNecessary = true
                    }));
        }

        //public void ConfigureHangfire(IAppBuilder app)
        //{
        //    ConfigureHangfireStorage();
        //    app.UseHangfireServer();
        //    app.UseHangfireDashboard();

        //    RecurringJob.AddOrUpdate<ProjectPmPaymentRecurringJobs>(
        //        "project-pm-epay-nightly-reverify",
        //        job => job.ReverifyAllEpayPayments(),
        //        ConfigurationManager.AppSettings["Hangfire:EpayReverifyCron"] ?? "0 0 * * *",
        //        GetIndiaTimeZone());
        //}

        private static string GetHangfireConnectionString()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["reraConn"];
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder(settings.ConnectionString);

            if (!builder.AllowUserVariables)
            {
                builder.AllowUserVariables = true;
            }

            return builder.ConnectionString;
        }

        private static TimeZoneInfo GetIndiaTimeZone()
        {
            return TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        }
    }
}