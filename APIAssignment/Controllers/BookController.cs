using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIAssignment.Models;
using APIAssignment.Repository;
using APIAssignment.Repositories;

namespace APIAssignment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly RepoClass r;
        public BookController()
        {
            this.r = new RepoClass();   
        }
        [HttpPost, Route("AddBooking/{user}")]
        public IActionResult CreateBook(Book user)
        {
            try
            {
                r.AddBooking(user);
                return StatusCode(200,user);
            }
            catch (Exception ex)
            {

                return StatusCode(200, ex.Message);
            }
        }
        [HttpGet, Route("GetBookings")]
        public IActionResult GetAllBookings()
        {
            try
            {
                return StatusCode(200, r.DisplayBookings());
            }
            catch (Exception ex)
            {

                return StatusCode(200, ex.Message);
            }
        }
        
        [HttpGet, Route("GetBookingsById/{bookingId}")]
        public IActionResult GetBookingsById(int id)
        {
            try
            {
                return StatusCode(200, r.GetBookingDetailsFromId(id));
            }
            catch (Exception ex)
            {

                return StatusCode(200, ex.Message);
            }
        }
        [HttpGet, Route("GetBookingsByName/{name}")]
        public IActionResult GetBookingsByName(string name)
        {
            try
            {
                return StatusCode(200, r.GetBookingDetailsFromName(name));
            }
            catch (Exception ex)
            {

                return StatusCode(200, ex.Message);
            }
        }
        [HttpPost, Route("UpdateBookingDate")]
        public IActionResult UpdateBookingDetails(int id, string updatedDate)
        {
            try
            {
                r.UpdateBookingDate(id, updatedDate);
                return StatusCode(200,"Done Updating");
            }
            catch (Exception ex)
            {

                return StatusCode(200, ex.Message);
            }
        }
        [HttpPost, Route("UpdateBookingName")]
        public IActionResult UpdateBookingName(int id, string name)
        {
            try
            {
                r.UpdateBookingUserName(id, name);
                return StatusCode(200, "Done Updating");
            }
            catch (Exception ex)
            {

                return StatusCode(200, ex.Message);
            }
        }
        
        [HttpDelete, Route("DeleteBooking/{id}")]
        public IActionResult DeleteBooking(int id)
        {
            try
            {
                r.DeleteBooking(id);
                return StatusCode(200, "Done deleting");
            }
            catch (Exception ex)
            {

                return StatusCode(200, ex.Message);
            }
        }
    }
}
