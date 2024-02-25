using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace G5CarRental.Models
{
    public class VehiclesModel
    {
        [Required]
        public int VehicleID { get; set; }

        [Required]
        [DisplayName("Marca")]
        public string Brand { get; set; }

        [Required]
        [DisplayName("Modelo")]
        public string Model { get; set; }
        
        [Required]
        [DisplayName("Año")]
        public int Year { get; set; }
        
        [Required]
        [DisplayName("Tipo")]
        public string Type { get; set; }
        
        [Required]
        [DisplayName("Disponibilidad")]
        public string Availability { get; set; }
    }
}
