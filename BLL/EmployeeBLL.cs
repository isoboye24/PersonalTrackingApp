﻿using DAL.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataAccessObject;
using DAL;

namespace BLL
{
    public class EmployeeBLL
    {
        public static void AddEmployee(EMPLOYEE employee)
        {
            EmployeeDAO.AddEmployee(employee);
        }

        public static void DeleteEmployee(int employeeID)
        {
            EmployeeDAO.DeleteEmployee(employeeID);
        }

        public static EmployeeDTO GetAll()
        {
            EmployeeDTO dto = new EmployeeDTO();
            dto.Departments = DepartmentDAO.GetDepartments();
            dto.Positions = PositionDAO.GetPositions();            
            dto.Employees = EmployeeDAO.GetEmployees();            
            return dto;
        }

        public static List<EMPLOYEE> GetEmployee(string text, int v)
        {
            return EmployeeDAO.GetEmployee(text, v);
        }

        public static bool IsUnique(int v)
        {
            List<EMPLOYEE> list = EmployeeDAO.GetUsers(v);
            if (list.Count > 0)
            {
                return false;
            }
            else 
            { 
                return true; 
            }
        }

        public static void UpdateEmpoyee(EMPLOYEE employee)
        {
            EmployeeDAO.UpdateEmployee(employee);
        }
    }
}
