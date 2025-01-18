namespace MTBS.Domain.Entities
{
    public class BookingTicket
    {
        public Guid TicketId { get; set; }
        public Guid BookingId { get; set; }
        public double Price { get; set; }

        public Ticket? Ticket { get; set; }
        public Booking? Booking { get; set; }
    }
}
