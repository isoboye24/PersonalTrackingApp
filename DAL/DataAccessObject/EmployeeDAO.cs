using DAL.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessObject
{
    public class EmployeeDAO : EmployeeContent
    {
        public static void AddEmployee(EMPLOYEE employee)
        {
			try
			{
				db.EMPLOYEEs.InsertOnSubmit(employee);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

        public static List<EmployeeDetailsDTO> GetEmployees()
        {
            List<EmployeeDetailsDTO> employeesList = new List<EmployeeDetailsDTO>();
            var list = (from e in db.EMPLOYEEs
                        join d in db.DEPARTMENTs on e.departmentID equals d.departmentID
                        join p in db.POSITIONs on e.positionID equals p.positionID
                        select new
                        {
                            EmployeeID = e.employeeID,
                            UserNo = e.userNo,
                            Password = e.password,
                            Name = e.name,
                            Surname = e.surname,
                            DepartmentName = d.departmentName,
                            DepartmentID = e.departmentID,
                            PositionID = e.positionID,
                            PositionName = p.positionName,
                            IsAdmin = e.isAdmin,
                            Salary = e.salary,
                            ImagePath = e.imagePath,
                            Birthday = e.birthday,
                            Address = e.address
                        }).OrderBy(x =>x.UserNo).ToList();
            foreach(var item in list)
            {
                EmployeeDetailsDTO dto = new EmployeeDetailsDTO();
                dto.UserNo = item.UserNo;
                dto.Password = item.Password;
                dto.Name = item.Name;
                dto.Surname = item.Surname;
                dto.EmployeeID = item.EmployeeID;
                dto.DepartmentID = item.DepartmentID;
                dto.PositionID = item.PositionID;
                dto.DepartmentName = item.DepartmentName;
                dto.PositionName = item.PositionName;
                dto.IsAdmin = item.IsAdmin;
                dto.Salary = item.Salary;
                dto.Birthday = item.Birthday;
                dto.Address = item.Address;
                employeesList.Add(dto);
            }
            return employeesList;
        }        

        public static List<EMPLOYEE> GetUsers(int v)
        {
            return db.EMPLOYEEs.Where(x => x.userNo == v).ToList();
        }
    }
}
