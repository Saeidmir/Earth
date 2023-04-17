namespace Earth.Extension.Abstractions.MessageBus;
public interface IMessageInboxItemRepository
{
    bool AllowReceive(string messageId, string fromService);
    void Receive(string messageId, string fromService,string payload);
}
