using System.ComponentModel.DataAnnotations;

namespace Restaurant_Booking_App.Models

{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public int NumberofGuest { get; set; }


    }
}
