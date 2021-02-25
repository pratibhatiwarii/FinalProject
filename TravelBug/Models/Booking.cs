using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TravelBug.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "The Start Date is required.")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "The End Date is required.")]
        public DateTime EndDate { get; set; }

        [DisplayName("Booking Status")]
        [StringLength(20)]
        public string BookingStatus { get; set; }
        public Traveler Traveler { get; set; }

        [DisplayName("Traveler")]
        public int TravelerId { get; set; }
        public Package Package { get; set; }

        [DisplayName("Package")]
        public int PackageId { get; set; }

        [DisplayName("Travel Coordinator")]
        public TravelCoordinator TravelerCoordinator { get; set; }

        [DisplayName("Travel Coordinator")]
        public int TravelerCoordinatorId { get; set; }
    }
}
