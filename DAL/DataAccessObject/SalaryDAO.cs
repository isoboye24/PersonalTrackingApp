using DAL.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessObject
{
    public class SalaryDAO : EmployeeContent
    {
        public static void AddSalary(SALARY salary)
        {            
            try
            {
                db.SALARies.InsertOnSubmit(salary);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteSalary(int salaryID)
        {
            try
            {
                SALARY sl = db.SALARies.First(x => x.salaryID == salaryID);
                db.SALARies.DeleteOnSubmit(sl);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<MONTH> GetMonths()
        {
			return db.MONTHs.ToList();
        }

        public static List<SalaryDetailDTO> GetSalaries()
        {
            List<SalaryDetailDTO> salaryList = new List<SalaryDetailDTO>();
            var list = (from s in db.SALARies
                        join e in db.EMPLOYEEs on s.employeeID equals e.employeeID
                        join m in db.MONTHs on s.month equals m.monthID
                        select new
                        {
                            salaryID = s.salaryID,
                            employeeID = s.employeeID,
                            userNo = e.userNo,
                            name = e.name,
                            surname = e.surname,
                            salaryAmount = s.amount,
                            year = s.year,
                            monthID = s.month,
                            monthName = m.monthName,
                            departmentID = e.departmentID,
                            positionID = e.positionID
                        }).OrderBy(x => x.year).ToList();

            foreach (var item in list)
            {
                SalaryDetailDTO dto = new SalaryDetailDTO();
                dto.SalaryID = item.salaryID;
                dto.EmployeeID = item.employeeID;
                dto.UserNo = item.userNo;
                dto.Name = item.name;
                dto.Surname = item.surname;
                dto.SalaryAmount = item.salaryAmount;
                dto.SalaryYear = item.year;
                dto.MonthID = item.monthID;
                dto.MonthName = item.monthName;
                dto.DepartmentID = item.departmentID;
                dto.PositionID = item.positionID;
                salaryList.Add(dto);
            }
            return salaryList;
        }

        public static void UpdateSalary(SALARY updateSalary)
        {
            try
            {
                SALARY sa = db.SALARies.First(x => x.salaryID == updateSalary.salaryID);
                sa.year = updateSalary.year;
                sa.amount = updateSalary.amount;
                sa.month = updateSalary.month;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }        
    }
}
