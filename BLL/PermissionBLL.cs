using DAL;
using DAL.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DataAccessObject;

namespace BLL
{
    public class PermissionBLL
    {
        public static void AddPermission(PERMISSION permission)
        {
            PermissionDAO.AddPermission(permission);
        }
    }
}
