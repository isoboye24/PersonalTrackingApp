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
        public static void AddSalary(SALARY salary, bool control)
        {
            SalaryDAO.AddSalary(salary);
            if (control)
            {
                EmployeeDAO.UpdateSalary(salary.employeeID, salary.amount);
            }
        }

        public static SalaryDTO GetAll()
        {
            SalaryDTO dto = new SalaryDTO();
            dto.Departments = DepartmentDAO.GetDepartments();
            dto.Positions = PositionDAO.GetPositions();
            dto.Employees = EmployeeDAO.GetEmployees();
            dto.Months = SalaryDAO.GetMonths();
            dto.Salaries = SalaryDAO.GetSalaries();
            return dto;
        }

        public static void UpdateSalary(SALARY updateSalary, bool control)
        {
            SalaryDAO.UpdateSalary(updateSalary);
            if (control)
            {
                EmployeeDAO.UpdateSalary(updateSalary.employeeID, updateSalary.amount);
            }
        }
    }
}
