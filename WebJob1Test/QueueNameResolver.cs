using Microsoft.Azure.WebJobs;

namespace WebJob1Test
{
    public class QueueNameResolver :INameResolver
    {
        public string Resolve (string name)
        {
            // return ConfigurationManager.AppSettings[name].ToString();
            if(name == "dynamic")

            {
                return "michael-dynamic";
            }
            return null;
        }
    }
}
