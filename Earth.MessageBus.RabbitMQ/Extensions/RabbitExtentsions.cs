using System.Text;
using Earth.Extension.Abstractions.MessageBus;
using RabbitMQ.Client.Events;

namespace Earth.MessageBus.RabbitMQ.Extensions;
static class RabbitExtensions
{
    public static Parcel ToParcel(this BasicDeliverEventArgs basicDeliverEventArgs)
    {
        Parcel parcel = new()
        {
            CorrelationId = basicDeliverEventArgs?.BasicProperties?.CorrelationId,
            MessageId = basicDeliverEventArgs?.BasicProperties.MessageId,
            Route = basicDeliverEventArgs.RoutingKey,
            MessageBody = Encoding.UTF8.GetString(basicDeliverEventArgs.Body.ToArray()),
            MessageName = basicDeliverEventArgs.BasicProperties.Type,
            Headers = basicDeliverEventArgs?.BasicProperties?.Headers != null ? (Dictionary<string, object>)basicDeliverEventArgs?.BasicProperties?.Headers : null
        };
        return parcel;
    }
}
