using DAL;
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
    public class PositionBLL
    {
        public static void AddPosition(POSITION position)
        {
            PositionDAO.AddPosition(position);
        }

        public static void DeletePosition(int positionID)
        {
            PositionDAO.DeletePosition(positionID);
        }

        public static List<PositionDTO> GetPositions()
        {
            return PositionDAO.GetPositions();
        }

        public static void UpdatePostion(POSITION position, bool control)
        {
            PositionDAO.UpdatePosition(position);
            if (control)
            {
                EmployeeDAO.UpdateEmployee(position);
            }
        }
    }
}
