using DAL.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessObject
{
    public class TaskDAO : EmployeeContent
    {
        public static void AddTask(TASK task)
        {
            try
            {
                db.TASKs.InsertOnSubmit(task);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<TaskDetailDTO> GetTasks()
        {
            List<TaskDetailDTO> taskList = new List<TaskDetailDTO>();
            var list = (from t in db.TASKs
                        join s in db.TASKSTATEs on t.taskState equals s.stateID
                        join e in db.EMPLOYEEs on t.employeeID equals e.employeeID
                        join p in db.POSITIONs on e.positionID equals p.positionID
                        join d in db.DEPARTMENTs on e.departmentID equals d.departmentID
                        select new
                        {
                            taskID = t.taskID,
                            title = t.taskTitle,
                            content = t.taskContent,                            
                            startDate = t.taskStartDate,
                            deliveryDate = t.tastDeliveryDate,
                            taskStateID = t.taskState,
                            taskStateName = s.stateName,
                            employeeID = t.employeeID,
                            userNo = e.userNo,
                            name = e.name,
                            surname = e.surname,
                            positionID = e.positionID,
                            positionName = p.positionName,
                            departmentID = e.departmentID,
                            deparmentName = d.departmentName
                        }).OrderBy(x => x.startDate).ToList();

            foreach (var item in list)
            {
                TaskDetailDTO dto = new TaskDetailDTO();
                dto.TaskID = item.taskID;
                dto.Title = item.title;
                dto.Content = item.content;
                dto.TaskStartDate = item.startDate;
                dto.TaskDeliveryDate = item.deliveryDate;
                dto.TaskStateID = item.taskStateID;
                dto.TaskStateName = item.taskStateName;
                dto.EmployeeID = item.employeeID;
                dto.UserNo = item.userNo;
                dto.Name = item.name;
                dto.Surname = item.surname;
                dto.PositionID = item.positionID;
                dto.PositionName = item.positionName;
                dto.DepartmentID = item.departmentID;
                dto.DepartmentName = item.deparmentName;
                taskList.Add(dto);
            }

            return taskList;
        }

        public static List<TASKSTATE> GetTasksState()
        {
            return db.TASKSTATEs.ToList();
        }

        public static void UpdateTask(TASK task)
        {
            try
            {
                TASK ts = db.TASKs.First(x => x.taskID == task.taskID);
                ts.taskTitle = task.taskTitle;
                ts.taskContent = task.taskContent;
                ts.taskState = task.taskState;
                ts.employeeID = task.employeeID;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
