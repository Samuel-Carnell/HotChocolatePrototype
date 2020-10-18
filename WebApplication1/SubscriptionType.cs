using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Types;

namespace WebApplication1
{

    // This way of designing subscriptions could be used with the subscribeToMore function provided by the apollo client.
    // The subscribeToMore function in the apollo client allows you to make an initial query, then subscribe to a graphql subscription.
    // Whenever the graphql subscription emits a message, the apollo client can use that message to update the result set accordingly. This
    // avoid the thundering herd problem where multiple client re excute a given query. This would mean that most major data types would roughly have 3 different types of subscription
    // - onObjectCreated - Which would return the object created.
    // - onObjectUpdated - Which would retuern a diff between the new and old object.
    // - onObjectDelete - Which would return the deleted object.

    public class SubscriptionType
    {
        // Creates a OnAppointmentBooked. When the ITopicEventSender sends a message with the topic "OnAppointmentBooked", this function is called with the event message.
        // The return value is then sent back to the client.
        [Topic]
        [Subscribe]
        public Appointment OnAppointmentBooked([EventMessage] Appointment appointment) => appointment;
    }
}
