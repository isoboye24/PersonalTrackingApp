using DAL.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessObject
{
    public class PositionDAO : EmployeeContent
    {
        public static void AddPosition(POSITION position)
        {
			try
			{
				db.POSITIONs.InsertOnSubmit(position);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

        public static void DeletePosition(int positionID)
        {
			try
			{
				POSITION ps = db.POSITIONs.First(x => x.positionID == positionID);
				db.POSITIONs.DeleteOnSubmit(ps);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

        public static List<PositionDTO> GetPositions()
        {
			try
			{
				var list = (from p in db.POSITIONs
							join d in db.DEPARTMENTs on p.departmentID equals d.departmentID 
							select new
							{
								positionID = p.positionID,
								positionName = p.positionName,
								departmentName = d.departmentName,
								departmentID = d.departmentID
							}).OrderBy(x => x.positionID).ToList();

				List<PositionDTO> positionList = new List<PositionDTO>();
				foreach (var item in list)
				{
					PositionDTO dto = new PositionDTO();
					dto.positionID = item.positionID;
					dto.positionName = item.positionName;
					dto.departmentID = item.departmentID;
					dto.DepartmentName = item.departmentName;
					positionList.Add(dto);
				}
				return positionList;
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

        public static void UpdatePosition(POSITION position)
        {
			try
			{
				POSITION ps = db.POSITIONs.First(x => x.positionID == position.positionID);
				ps.positionName = position.positionName;
				ps.departmentID = position.departmentID;
				db.SubmitChanges();
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }
    }
}
