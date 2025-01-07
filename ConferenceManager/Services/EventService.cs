using ConferenceManager.Data;

namespace ConferenceManager.Services
{
    public interface IEventService
    {
        public List<Event> GetAllEvents();
        public Event GetEventById(string id);
    }
    public class EventService : IEventService
    {
        private IEventModel eventData;
        public EventService(IEventModel ed)
        {
            eventData = ed;
        }

        public List<Event> GetAllEvents()
        {
            return eventData.GetAllEvents();
        }

        public Event GetEventById(string id)
        {
            return eventData.GetEventById(int.Parse(id));
        }
    }
}
