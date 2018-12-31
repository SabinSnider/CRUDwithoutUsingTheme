using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;

namespace CRUDwithoutScaff.Models
{
    [Table("tblEmployee")]
    public class Employee 
    {
        
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }
}