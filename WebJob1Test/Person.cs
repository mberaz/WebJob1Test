using Microsoft.WindowsAzure.Storage.Table;

namespace WebJob1Test
{
    //public class Person
    //{
    //    public string PartitionKey { get; set; }
    //    public string RowKey { get; set; }

    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Email { get; set; }

    //    public bool IsUser { get; set; }
    //}

    public class Person :TableEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public bool IsUser { get; set; }
    }
}
