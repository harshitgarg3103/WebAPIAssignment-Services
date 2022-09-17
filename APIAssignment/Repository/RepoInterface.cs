using System.Collections.Generic;
using APIAssignment.Models;
namespace APIAssignment.Repository
{
    public interface RepoInterface
    {
        public void AddBooking(Book user);
        public Book GetBookingDetailsFromId(int id);

        public Book GetBookingDetailsFromName(string name);

        public void UpdateBookingDate(int id, string updatedDate);

        public void UpdateBookingUserName(int id, string updateName);
        public void DeleteBooking(int id);

        public List<Book> DisplayBookings();





    }
}
