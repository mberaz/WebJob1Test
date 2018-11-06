using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace WebJob1Test
{
    public class Functions
    {
        //{"Id":1,"Name":"michael berezin","Email":"mbearz@gmail.com"}
        public static void Step1 (
            [QueueTrigger("michaeltest")] User user,
            [Queue("michaeltestsecond")] out UserMetaData metaData)
        {
            metaData = new UserMetaData
            {
                User = user,
                HandeltedAt = DateTime.UtcNow.ToString()
            };
        }

        public static void Step2 (
        [QueueTrigger("michaeltestsecond")] UserMetaData metaData,
        [Queue("michaeltest3")] out UserMetaData metaDataOut)
        {
            metaDataOut = new UserMetaData
            {
                User = metaData.User,
                IsDone = true,
                HandeltedAt = DateTime.UtcNow.ToString()
            };
        }


        public static void Step3 (
        [QueueTrigger("michaeltest3")] UserMetaData metaData,
        [Table("Persons")] ICollector<Person> persons)
        {
            var user = metaData.User;
            if(metaData.IsDone)
            {
                var person = new Person
                {
                    PartitionKey = "users",
                    RowKey = DateTime.UtcNow.Ticks.ToString(),

                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    IsUser = true
                };

                persons.Add(person);
            }

        }

        //name resolved in QueueNameResolver   class
        public async static Task Dynamic ([QueueTrigger("%dynamic%")] User user,IBinder binder)
        {

            var metaDataOut = new UserMetaData
            {
                User = user,
                IsDone = true,
                HandeltedAt = DateTime.UtcNow.ToString()
            };


            QueueAttribute queueAttribute = new QueueAttribute("michaeltest3");
            CloudQueue outputQueue = binder.Bind<CloudQueue>(queueAttribute);
            await outputQueue.AddMessageAsync(new CloudQueueMessage(JsonConvert.SerializeObject(metaDataOut)));

        }
    }
}
