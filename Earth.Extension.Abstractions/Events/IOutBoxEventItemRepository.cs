namespace Earth.Extension.Abstractions.Events
{
    public interface IOutBoxEventItemRepository
    {
        public List<OutBoxEventItem> GetOutBoxEventItemsForPublishe(int maxCount = 100);
        void MarkAsRead(List<OutBoxEventItem> outBoxEventItems);
    }

}
