using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;

namespace WebJob1Test
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        private const string cs = "DefaultEndpointsProtocol=https;AccountName=domar;AccountKey=gFIBE/TksQEIyOxCCi/6fnzN4PKnRvvAWbQIKL4MZ7MO77Z7Q+vZPDWqmon7B48spiG0hBhEQWd3eiFzpZDMnA==;EndpointSuffix=core.windows.net";
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {


            var user = new User { Id = 1,Name = "michael berezin",Email = "mbearz@gmail.com" };

            var json = JsonConvert.SerializeObject(user);


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
