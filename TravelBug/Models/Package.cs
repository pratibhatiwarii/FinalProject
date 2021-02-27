using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TravelBug.Models
{
    public class Package
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "The Name is required.")]
        public string Name { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "The Description is required.")]
        public string Description { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "The Type is required.")]
        public string Type { get; set; }

        [DisplayName("Flight Class")]
        [StringLength(20)]
        [Required(ErrorMessage = "The Flight Class is required.")]
        public string FlightClass { get; set; }

        [DisplayName("Hotel Rating")]
        [StringLength(20)]
        [Required(ErrorMessage = "The Hotel Rating is required.")]
        public string HotelRating { get; set; }

        [Range(1, 100)]
        [DisplayName("Minimum Duration")]
        public int Duration { get; set; }
        public Destination Destination { get; set; }

        [DisplayName("Destination Name")]
        public int DestinationId { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
