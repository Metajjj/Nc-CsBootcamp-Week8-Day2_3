using ConferenceManager.Data;

namespace ConferenceManager.Services
{
    public interface IEventService
    {
        public List<Event> GetAllEvents();
        public Event GetEventById(string id);

        public bool AddEvent(Event e);
    }
    public class EventService : IEventService
    {
        private IEventModel eventModel;
        public EventService(IEventModel ed)
        {
            eventModel = ed;
        }

        public bool AddEvent(Event e)
        {
            return eventModel.AddEvent(e);
        }

        public List<Event> GetAllEvents()
        {
            return eventModel.GetAllEvents();
        }

        public Event GetEventById(string id)
        {
            return eventModel.GetEventById(int.Parse(id));
        }
    }
}
