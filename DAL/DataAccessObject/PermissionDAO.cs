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
    }
}
