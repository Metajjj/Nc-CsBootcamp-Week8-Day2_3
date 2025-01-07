using System.Text.Json;

namespace ConferenceManager.Data
{
    public interface IEventModel
    {
        public List<Event> GetAllEvents();
        public Event GetEventById(int id);
        public bool AddEvent(Event e);
    }
    public class EventModel : IEventModel
    {
        private string fPth = @$"{Environment.CurrentDirectory}/Resources/EventData.json";

        public List<Event> GetAllEvents()
        {
            return JsonSerializer.Deserialize<List<Event>>(File.ReadAllText(fPth), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            //Json is case-sensitive
        }

        public Event GetEventById(int id)
        {
            return GetAllEvents().FirstOrDefault(x => x.Id == id);
        }


        public bool AddEvent(Event e)
        {
            var currEvents = GetAllEvents();

            if (currEvents.Any(E => E.Id == e.Id))
            {
                return false;
            }

            currEvents.Add(e);
                //Write into file

            return true;
        }
    }
}
