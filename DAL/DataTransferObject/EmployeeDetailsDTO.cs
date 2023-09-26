using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataTransferObject
{
    public class EmployeeDetailsDTO
    {
        public int EmployeeID { get; set; }
        public int UserNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImagePath { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public int Salary { get; set; }
        public DateTime? Birthday { get; set; }        
        public string Address { get; set; }
        public string Password { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
