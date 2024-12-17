using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeesApplication.Models
{
    public class Deportment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepotmentId {  get; set; }

        [Required]
        public string DeportmentName { get; set; }
        List<Employee> Employees { get; set; }
    }
}