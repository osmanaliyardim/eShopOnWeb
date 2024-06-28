using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;

public class EventPublisher
{
    private readonly string _topicEndpoint;
    private readonly string _topicKey;
    private readonly string _topicHostname;

    public EventPublisher(string topicEndpoint, string topicKey)
    {
        _topicEndpoint = topicEndpoint;
        _topicKey = topicKey;
        _topicHostname = new Uri(topicEndpoint).Host;
    }

    public async Task PublishEventAsync<T>(T eventData, string subject, string eventType)
    {
        var topicCredentials = new TopicCredentials(_topicKey);
        var client = new EventGridClient(topicCredentials);

        var events = new List<EventGridEvent>
        {
            new EventGridEvent
            {
                Id = Guid.NewGuid().ToString(),
                EventType = eventType,
                Data = eventData,
                EventTime = DateTime.UtcNow,
                Subject = subject,
                DataVersion = "1.0"
            }
        };

        await client.PublishEventsAsync(_topicHostname, events);
    }
}

