using Microsoft.Azure.WebJobs;
using System.Configuration;

namespace WebJob1Test
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
 
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {

            var cs = ConfigurationManager.AppSettings["cs"];
 
            var config = new JobHostConfiguration();

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }
            config.StorageConnectionString = cs;
            config.DashboardConnectionString = cs;
            config.Queues.BatchSize = 1;
 
            var host = new JobHost(config);
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();



            
        }
    }
}
