using DAL.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessObject
{
    public class PermissionDAO : EmployeeContent
    {
        public static void AddPermission(PERMISSION permission)
        {
			try
			{
				db.PERMISSIONs.InsertOnSubmit(permission);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

        public static List<PermissionDetailsDTO> GetPermission()
        {
            List<PermissionDetailsDTO> permissionList = new List<PermissionDetailsDTO>();
            var list = (from p in db.PERMISSIONs
                        join e in db.EMPLOYEEs on p.employeeID equals e.employeeID
                        join ps in db.PERMISSIONSTATEs on p.permissionState equals ps.permissionStateID
                        select new
                        {
                            userNo = e.userNo,
                            name = e.name,
                            surname = e.surname,
                            dayAmount = p.permissionDay,
                            employeeID = p.employeeID,
                            positionID = e.positionID,
                            departmentID = e.departmentID,
                            permissionID = p.permissionID,
                            permissionStateID = p.permissionState,
                            stateName = ps.permissionStateName,
                            explanation = p.permissionExplanation,
                            startDate = p.permissionStartDate,
                            endDate = p.permissionEndDate
                        }).OrderBy(x => x.startDate).ToList();
            foreach (var item in list)
            {
                PermissionDetailsDTO dto = new PermissionDetailsDTO();
                dto.UserNo = item.userNo;
                dto.Name = item.name;
                dto.Surname = item.surname;
                dto.PermissionDayAmount = item.dayAmount;
                dto.EmployeeID = item.employeeID;
                dto.PositionID = item.positionID;
                dto.DepartmentID = item.departmentID;
                dto.PermissionID = item.permissionID;
                dto.State = item.permissionStateID;
                dto.StateName = item.stateName;
                dto.Explanation = item.explanation;
                dto.StartDate = item.startDate;
                dto.EndDate = item.endDate;
                permissionList.Add(dto);
            }
            return permissionList;
        }

        public static List<PERMISSIONSTATE> GetPermissionState()
        {
            return db.PERMISSIONSTATEs.ToList();
        }

        public static void UpdatePermission(PERMISSION permission)
        {
            try
            {
                PERMISSION pr = db.PERMISSIONs.First(x => x.permissionID == permission.permissionID);
                pr.permissionStartDate = permission.permissionStartDate;
                pr.permissionEndDate = permission.permissionEndDate;
                pr.permissionExplanation = permission.permissionExplanation;
                pr.permissionDay = permission.permissionDay;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void UpdatePermission(int permissionID, int approve)
        {
            PERMISSION pr = db.PERMISSIONs.First(x =>x.permissionID == permissionID);
            pr.permissionState = approve; 
            db.SubmitChanges();
        }
    }
}
