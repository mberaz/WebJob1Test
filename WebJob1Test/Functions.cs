using Microsoft.Azure.WebJobs;
using System;

namespace WebJob1Test
{
    public class Functions
    {

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
            var person = new Person
            {
                PartitionKey = "users",
                RowKey = user.Id.ToString(),

                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                IsUser = true
            };

            persons.Add(person);
        }

    }
}
