using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TravelBug.Models
{
    public class Traveler
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [StringLength(20)]
        [Required(ErrorMessage = "The First Name is required.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(20)]
        [Required(ErrorMessage = "The Last Name is required.")]
        public string LastName { get; set; }

        [StringLength(20)]
        public string Gender { get; set; }

        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "The Date of Birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Email ID")]
        [StringLength(100)]
        [Required(ErrorMessage = "The Email ID is required.")]
        public string EmailID { get; set; }

        [DisplayName("Phone No.")]
        [StringLength(10)]
        [Phone]
        [Required(ErrorMessage = "The Phone No. is required.")]
        public string PhoneNumber { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
