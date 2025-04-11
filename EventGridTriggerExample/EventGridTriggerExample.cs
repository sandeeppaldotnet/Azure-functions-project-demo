using Azure.Messaging.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;

namespace EventGridTriggerExample
{
    public static class EventGridTriggerFunction
    {
        [FunctionName("EventGridTriggerExample")]
        public static void Run(
            [EventGridTrigger] Azure.Messaging.EventGrid.EventGridEvent eventGridEvent,
            ILogger log)
        {
            log.LogInformation($"EventGridEvent data: {eventGridEvent.Data}");

            var eventType = eventGridEvent.EventType;
            var eventTime = eventGridEvent.EventTime;
            var subject = eventGridEvent.Subject;

            log.LogInformation($"Event Type: {eventType}");
            log.LogInformation($"Event Time: {eventTime}");
            log.LogInformation($"Subject: {subject}");

            // Add additional event processing logic here.
        }
    }
}
