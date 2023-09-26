using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.DataTransferObject
{
    public class EmployeeDTO
    {
        public List<DEPARTMENT> Departments { get; set; }
        public List<PositionDTO> Positions { get; set; }
        public List<EmployeeDetailsDTO> Employees { get; set; }
    }
}
