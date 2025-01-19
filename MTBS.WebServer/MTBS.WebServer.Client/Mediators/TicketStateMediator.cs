using MTBS.WebServer.Client.Components;

namespace MTBS.WebServer.Client.Mediators
{
    public class TicketStateMediator
    {
        Dictionary<int, TicketButton> tickets = new();

        public void UpdateState(int newState, int sender)
        {
            var ticket = tickets[sender];
            ticket?.UpdateState(newState);
        }
        public void AddTicket(TicketButton ticket)
        {
            tickets.Add(ticket.Id, ticket);
        }
        public void RemoveTicket(int id) 
        { 
            tickets.Remove(id);
        }
    }
}
