using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataTransferObject
{
    public class SalaryDetailDTO
    {
        public int SalaryID { get; set; }
        public int EmployeeID { get; set; }
        public int UserNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SalaryAmount { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public string OldSalary { get; set; }
        public DateTime? SalaryYear { get; set; }
        public int MonthID { get; set; }
        public DateTime? MonthName { get; set; }
    }
}
