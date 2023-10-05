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

        public static List<EMPLOYEE> GetEmployee(string text, int v)
        {
            List<EMPLOYEE> list = db.EMPLOYEEs.Where(x => x.userNo == v && x.password == text).ToList();
            return list;
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
                            Name = e.name,
                            Surname = e.surname,
                            ImagePath = e.imagePath,
                            DepartmentID = e.departmentID,
                            DepartmentName = d.departmentName,
                            PositionID = e.positionID,
                            PositionName = p.positionName,
                            Salary = e.salary,
                            Birthday = e.birthday,
                            Address = e.address,
                            Password = e.password,
                            IsAdmin = e.isAdmin
                        }).OrderBy(x =>x.UserNo).ToList();
            foreach(var item in list)
            {
                EmployeeDetailsDTO dto = new EmployeeDetailsDTO();
                dto.EmployeeID = item.EmployeeID;
                dto.UserNo = item.UserNo;
                dto.Name = item.Name;
                dto.Surname = item.Surname;
                dto.ImagePath = item.ImagePath;
                dto.DepartmentID = item.DepartmentID;
                dto.DepartmentName = item.DepartmentName;
                dto.PositionID = item.PositionID;
                dto.PositionName = item.PositionName;
                dto.Salary = item.Salary;
                dto.Birthday = item.Birthday;
                dto.Address = item.Address;
                dto.Password = item.Password;
                dto.IsAdmin = item.IsAdmin;
                employeesList.Add(dto);
            }
            return employeesList;
        }        

        public static List<EMPLOYEE> GetUsers(int v)
        {
            return db.EMPLOYEEs.Where(x => x.userNo == v).ToList();
        }

        public static void UpdateEmployee(EMPLOYEE employee)
        {
            try
            {
                EMPLOYEE emp = db.EMPLOYEEs.First(x => x.employeeID == employee.employeeID);
                emp.userNo = employee.userNo;
                emp.name = employee.name;
                emp.surname = employee.surname;
                emp.password = employee.password;
                emp.isAdmin = employee.isAdmin;
                emp.birthday = employee.birthday;
                emp.address = employee.address;
                emp.departmentID = employee.departmentID;
                emp.positionID = employee.positionID;
                emp.salary = employee.salary;
                emp.imagePath = employee.imagePath;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateSalary(int employeeID, int amount)
        {
            try
            {
                EMPLOYEE employee = db.EMPLOYEEs.First(x => x.employeeID == employeeID);
                employee.salary = amount;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}