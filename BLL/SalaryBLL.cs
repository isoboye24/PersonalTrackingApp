using DAL.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataAccessObject;
using DAL;

namespace BLL
{
    public class SalaryBLL
    {
        public static void AddSalary(SALARY salary)
        {
            SalaryDAO.AddSalary(salary);
        }

        public static SalaryDTO GetAll()
        {
            SalaryDTO dto = new SalaryDTO();
            dto.Departments = DepartmentDAO.GetDepartments();
            dto.Positions = PositionDAO.GetPositions();
            dto.Employees = EmployeeDAO.GetEmployees();
            dto.Months = SalaryDAO.GetMonths();
            
            return dto;
        }
    }
}
