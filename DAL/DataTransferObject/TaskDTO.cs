using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataTransferObject
{
    public class TaskDTO
    {
        public List<DEPARTMENT> Departments { set; get; }
        public List<PositionDTO> Positions { set; get; }
        public List<EmployeeDetailsDTO> Employees { set; get; }
        public List<TASKSTATE> TasksState { set; get; }
        public List<TaskDetailDTO> Tasks { get; set; }
    }
}
