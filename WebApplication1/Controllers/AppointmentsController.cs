using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Types;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly ITopicEventSender EventSender;

        // The ITopicEventSender is injected automatically by hot chocolate. This service can be used to send events to different topics (subscriptions).
        public AppointmentsController([Service] ITopicEventSender eventSender)
        {
            EventSender = eventSender;
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var appointment = new Appointment();
            // Sends a message to the OnAppointmentBooked topic (subscription), which in turn updates any client subscribed to it.
            await EventSender.SendAsync(nameof(SubscriptionType.OnAppointmentBooked), appointment);
            return new JsonResult(appointment);
        }

    }
}
