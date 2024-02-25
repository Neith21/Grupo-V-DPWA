using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace G5CarRental.Models
{
    public class CustomersModel
    {
        [Required] 
        public int CustomerID { get; set; }
        
        [Required]
        [DisplayName("Nombres")]
        public string CustomerFirstName { get; set; }

        [Required]
        [DisplayName("Apellidos")]
        public string CustomerLastName { get; set; }

        [Required]
        [DisplayName("Documento único de identidad")]
        public string UID { get; set; }

        [Required]
        [DisplayName("Dirección")]
        public string Address { get; set; }

        [Required]
        [DisplayName("Teléfono")]
        public string Phone { get; set; }

        [Required]
        [DisplayName("Email")]
        public string CustomerEmail { get; set; }

        [Required]
        [DisplayName("Licencia")]
        public string License { get; set; }
    }
}
