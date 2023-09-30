using DAL;
using DAL.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DataAccessObject;
using DAL.DataTransferObject;

namespace BLL
{
    public class PermissionBLL
    {
        public static void AddPermission(PERMISSION permission)
        {
            PermissionDAO.AddPermission(permission);
        }

        public static PermissionDTO GetAll()
        {
            PermissionDTO dto = new PermissionDTO();
            dto.Departments = DepartmentDAO.GetDepartments();
            dto.Positions = PositionDAO.GetPositions();
            //dto.Employees = EmployeeDAO.GetEmployees();
            dto.PermissionStates = PermissionDAO.GetPermissionState();
            dto.Permissions = PermissionDAO.GetPermission();
            return dto;
        }
    }
}
