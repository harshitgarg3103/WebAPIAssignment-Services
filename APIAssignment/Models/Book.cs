namespace APIAssignment.Models
{
    public class Book
    {
        public int bookingId { get; set; }
        public string userName { get; set; }
        public int price { get; set; }
        public string bookingDate { get; set; }

        public string flightName { get; set; }

        public int flightId { get; set; }
    }
}
