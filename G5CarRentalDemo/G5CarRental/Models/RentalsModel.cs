using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace G5CarRental.Models
{
    public class RentalsModel
    {
        [Required]
        public int RentID { get; set; }
        
        [Required]
        public int CustomerID { get; set; }

        [Required]
        public int VehicleID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [DisplayName("Fecha de inicio")]
        public DateTime StartDate { get; set; }
        
        [DisplayName("Fecha de fin")]
        public DateTime EndDate { get; set; }

        [DisplayName("Monto pagado")]
        public double AmountPaid { get; set; }

        //Atributos a mostrar
        [DisplayName("Nombre del cliente")]
        public string CustomerFirstName { get; set; }
        
        [DisplayName("Modelo de vehículo")]
        public string Model { get; set; }

        [DisplayName("Nombre del empleado")]
        public string EmployeeFirstName { get; set; }
    }
}
