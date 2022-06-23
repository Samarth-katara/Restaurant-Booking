using Restaurant_Booking_App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Booking_App.Models;

namespace Restaurant_Booking_App.Controllers
{
    [ApiController]
    [Route("api/[controller}")]
    public class BookingController : Controller
    {
        private readonly BookingDbContext bookingDbContext;
        public BookingController(BookingDbContext bookingDbContext)
        {

            this.bookingDbContext = bookingDbContext;

        }



        //get all booking
        [HttpGet]
        public async Task<IActionResult> GetAllBooking()
        {
            var card = await bookingDbContext.cards.ToListAsync();
            return Ok(card);
        }

        //get a single booking
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCard")]
        public async Task<IActionResult> GetBooking([FromRoute] Guid id)
        {
            var card = await bookingDbContext.cards.FirstOrDefaultAsync(x => x.Id == id);
            if (card != null)
            {
                return Ok(card);
            }
            return NotFound("Booking Not found");
        }
        //Add Booking
        [HttpPost]

        public async Task<IActionResult> AddBooking([FromBody] Card card)

        {
            card.Id = Guid.NewGuid();

            await bookingDbContext.cards.AddAsync(card);
            await bookingDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(AddBooking), card);


        }

        //update Booking
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateBooking([FromRoute] Guid id, [FromBody] Card card)
        {
            var existingcard = await bookingDbContext.cards.FirstOrDefaultAsync(x => x.Id == id);
            if (existingcard != null)
            {

                existingcard.Name = card.Name;
                existingcard.Email = card.Email;
                existingcard.MobileNumber = card.MobileNumber;
                existingcard.NumberofGuest = card.NumberofGuest;
                await bookingDbContext.SaveChangesAsync();
                return Ok(existingcard);

            }
            return NotFound("Booking Not Found");

        }
        // Delete Booking
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] Guid id)
        {
            var existingcard = await bookingDbContext.cards.FirstOrDefaultAsync(x => x.Id == id);
            if (existingcard != null)
            {

                bookingDbContext.Remove(existingcard);
                await bookingDbContext.SaveChangesAsync();
                return Ok(existingcard);

            }
            return NotFound("Booking Not Found");

        }
    }
}
