using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Service_Bus_Trigger
{
    public class ServiceBusTrigger
    {
        [FunctionName("ServiceBusTrigger")]
        public void Run([ServiceBusTrigger("my-queue", Connection = "ServiceBusConnection")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
