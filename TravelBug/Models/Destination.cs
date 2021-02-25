using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TravelBug.Models
{
    public class Destination
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "The Name is required.")]
        public string Name { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "The State is required.")]
        public string State { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "The Country is required.")]
        public string Country { get; set; }

        [DisplayName("Tourist Attractions")]
        [StringLength(500)]
        public string TouristAttraction { get; set; }
        public List<Package> Packages { get; set; }
    }
}
