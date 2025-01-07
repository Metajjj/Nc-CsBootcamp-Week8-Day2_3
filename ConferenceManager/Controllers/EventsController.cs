using System.Text.Json;

using ConferenceManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private IEventService eventService;
        public EventsController(IEventService es)
        {
            eventService = es;
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            return Ok(eventService.GetAllEvents());
        }

        [HttpGet("{id}")]
        public IActionResult GetEventByID(string id)
        {
            try
            {
                var teacher = eventService.GetEventById(id);

                return (teacher == null) ? NotFound("Teacher of given ID is not found!") : Ok(JsonSerializer.Serialize(teacher, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (FormatException ex)
            { return BadRequest("param is NaN! (not a number)"); }
        }
    }
}
