using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace G5CarRental.Models
{
	public class EmployeeModel
	{
		[Required]
		public int EmployeeID { get; set; }

		[DisplayName("Nombres")]
		public string EmployeeFirstName { get; set; }

		[DisplayName("Apellidos")]
		public string EmployeeLastName { get; set; }

		[DisplayName("Posición")]
		public string Position { get; set; }

		[DisplayName("Salario")]
		public double Salary { get; set; }

		[DisplayName("Email")]
		public string EmployeeEmail { get; set; }

		[DisplayName("Fecha de contratación")]
		public DateTime HireDate { get; set; }
	}
}
