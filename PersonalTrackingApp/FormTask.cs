using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DAL.DataTransferObject;
using BLL;

namespace PersonalTrackingApp
{
    public partial class FormTask : Form
    {
        public FormTask()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        TaskDTO dto = new TaskDTO();
        bool comboFull = false;
        TASK task = new TASK();
        public bool isUpdate = false;
        public TaskDetailDTO detail = new TaskDetailDTO();
        private void btnSave_Click(object sender, EventArgs e)
        {            
            if (task.employeeID == 0)
            {
                MessageBox.Show("Please an employee on table");
            }
            else if (txtTitle.Text.Trim() == "")
            {
                MessageBox.Show("Please enter title");
            }
            else if (txtContent.Text.Trim() == "")
            {
                MessageBox.Show("Please enter task content");
            }
            else
            {                
                if (!isUpdate)
                {
                    task.taskTitle = txtTitle.Text;
                    task.taskContent = txtContent.Text;
                    task.taskStartDate = DateTime.Today;
                    task.taskState = 1;
                    TaskBLL.AddTask(task);
                    MessageBox.Show("Task added");
                    txtTitle.Clear();
                    txtContent.Clear();
                    task = new TASK();
                }
                else if(isUpdate)
                {
                    DialogResult result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        TASK update = new TASK();
                        update.taskID = detail.TaskID;
                        if (Convert.ToInt32(txtUserNo.Text) != detail.UserNo)
                        {
                            update.employeeID = task.employeeID;
                        }
                        else
                        {
                            update.employeeID = detail.EmployeeID;
                        }
                        update.taskTitle = txtTitle.Text;
                        update.taskContent = txtContent.Text;
                        update.taskState = Convert.ToInt32(cmbTaskState.SelectedValue);
                        TaskBLL.UpdateTask(update);
                        MessageBox.Show("Task was updated");
                        this.Close();
                    }
                }
            }
        }

        private void FormTask_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            cmbTaskState.Visible = false;
            dto = TaskBLL.GetAll();
            dataGridView1.DataSource = dto.Employees;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User No";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Surname";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;

            comboFull = false;
            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "DepartmentID";
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "PositionName";
            cmbPosition.ValueMember = "PositionID";
            cmbPosition.SelectedIndex = -1;
            comboFull = true;
            cmbTaskState.DataSource = dto.TasksState;
            cmbTaskState.DisplayMember = "stateName";
            cmbTaskState.ValueMember = "stateID";
            cmbTaskState.SelectedIndex = -1;

            if (isUpdate)
            {
                label4.Visible = true;
                cmbTaskState.Visible = true;
                txtName.Text = detail.Name;
                txtSurname.Text = detail.Surname;
                txtTitle.Text = detail.Title;
                txtContent.Text = detail.Content;
                txtUserNo.Text = detail.UserNo.ToString();
                cmbTaskState.DataSource = dto.TasksState;
                cmbTaskState.DisplayMember = "stateName";
                cmbTaskState.ValueMember = "stateID";
                cmbTaskState.SelectedValue = detail.TaskStateID;
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                cmbPosition.DataSource = dto.Positions.Where(x => x.departmentID == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
                List<EmployeeDetailsDTO> list = dto.Employees;
                dataGridView1.DataSource = list.Where(x =>x.DepartmentID == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            task.employeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            txtUserNo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {                
                List<EmployeeDetailsDTO> list = dto.Employees;
                dataGridView1.DataSource = list.Where(x => x.PositionID == Convert.ToInt32(cmbPosition.SelectedValue)).ToList();
            }
        }
    }
}
