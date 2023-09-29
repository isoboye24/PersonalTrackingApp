using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataTransferObject
{
    public class SalaryDTO
    {
        public List<SalaryDetailDTO> Salaries { get; set; }
        public List<DEPARTMENT> Departments { get; set; }
        public List<PositionDTO> Positions { get; set; }
        public List<EmployeeDetailsDTO> Employees { get; set; }
        public List<MONTH> Months { get; set; }
    }
}
