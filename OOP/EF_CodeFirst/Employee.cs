using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        //[ForeignKey("CarRefId")]
        //public ICollection<Car> Cars { get; set; }
    }

    public class Car
    {
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public int CarID { get; set; }
        public string CarName { get; set; }
        public string CarType { get; set; }

        //public int CarRefId { get; set; }
    }
}
