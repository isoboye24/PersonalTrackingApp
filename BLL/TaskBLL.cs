using DAL.DataAccessObject;
using DAL.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataAccessObject;
using DAL;

namespace BLL
{
    public class TaskBLL
    {
        public static void AddTask(TASK task)
        {
            TaskDAO.AddTask(task);
        }

        public static TaskDTO GetAll()
        {
            TaskDTO taskdto = new TaskDTO();
            taskdto.Departments = DepartmentDAO.GetDepartments();
            taskdto.Positions = PositionDAO.GetPositions();
            taskdto.Employees = EmployeeDAO.GetEmployees();
            taskdto.TasksState = TaskDAO.GetTasksState();
            taskdto.Tasks = TaskDAO.GetTasks();
            return taskdto;
        }
    }
}
