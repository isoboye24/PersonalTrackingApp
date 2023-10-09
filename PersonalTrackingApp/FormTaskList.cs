using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DAL.DataTransferObject;

namespace PersonalTrackingApp
{
    public partial class FormTaskList : Form
    {
        public FormTaskList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormTask open = new FormTask();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
            FillAllData();
            ClearFilters();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.TaskID == 0)
            {
                MessageBox.Show("Please select a task from the table");
            }
            else
            {
                FormTask open = new FormTask();
                open.isUpdate = true;
                open.detail = detail;
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
                FillAllData();
                ClearFilters();
            }
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }
        TaskDTO taskdto = new TaskDTO();
        private bool comboFull = false;
        void FillAllData()
        {
            taskdto = TaskBLL.GetAll();
            if (!UserStatic.isAdmin)
            {
                taskdto.Tasks = taskdto.Tasks.Where(x => x.EmployeeID == UserStatic.EmployeeID).ToList();
            }
            dataGridView1.DataSource = taskdto.Tasks;

            comboFull = false;
            cmbDepartment.DataSource = taskdto.Departments;
            cmbDepartment.DisplayMember = "Departmentname";
            cmbDepartment.ValueMember = "DepartmentID";
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.DataSource = taskdto.Positions;
            cmbPosition.DisplayMember = "Positionname";
            cmbPosition.ValueMember = "PositionID";
            comboFull = true;
            cmbPosition.SelectedIndex = -1;
            cmbTaskState.DataSource = taskdto.TasksState;
            cmbTaskState.DisplayMember = "StateName";
            cmbTaskState.ValueMember = "StateID";
            cmbTaskState.SelectedIndex = -1;
        }
        private void FormTaskList_Load(object sender, EventArgs e)
        {            
            FillAllData();
            dataGridView1.Columns[0].HeaderText = "Task Title";
            dataGridView1.Columns[1].HeaderText = "User No";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Surname";
            dataGridView1.Columns[4].HeaderText = "Start Date";
            dataGridView1.Columns[5].HeaderText = "Delivery Date";
            dataGridView1.Columns[6].HeaderText = "Task State";
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            if (!UserStatic.isAdmin)
            {
                btnNew.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                panelAdmin.Hide();
                btnApprove.Location = new Point(216, 14);                
                btnClose.Location = new Point(355, 14);
                btnApprove.Text = "Delivery";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<TaskDetailDTO> list = taskdto.Tasks;
            if (txtUserNo.Text.Trim() != "")
            {
                list = list.Where(x => x.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();
            }
            if (txtName.Text.Trim() != "")
            {
                list = list.Where(x => x.Name.Contains(txtName.Text)).ToList();
            }
            if (txtSurname.Text.Trim() != "")
            {
                list = list.Where(x => x.Surname.Contains(txtSurname.Text)).ToList();
            }
            if (cmbDepartment.SelectedIndex != -1)
            {
                list = list.Where(x => x.DepartmentID == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            }
            if (cmbPosition.SelectedIndex != -1)
            {
                list = list.Where(x => x.PositionID == Convert.ToInt32(cmbPosition.SelectedValue)).ToList();
            }
            if (cmbPosition.SelectedIndex != -1)
            {
                list = list.Where(x => x.PositionID == Convert.ToInt32(cmbPosition.SelectedValue)).ToList();
            }
            if (rbStartDate.Checked)
            {
                list = list.Where(x => x.TaskStartDate > Convert.ToDateTime(dateTimePickerStart.Value) && 
                x.TaskStartDate < Convert.ToDateTime(dateTimePickerFinish.Value)).ToList();
            }
            if (rbDeliveryDate.Checked)
            {
                list = list.Where(x => x.TaskDeliveryDate > Convert.ToDateTime(dateTimePickerFinish.Value) &&
                x.TaskDeliveryDate < Convert.ToDateTime(dateTimePickerFinish.Value)).ToList();
            }
            dataGridView1.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void ClearFilters()
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            cmbPosition.DataSource = taskdto.Positions;
            //cmbTaskState.DataSource = taskdto.TasksState;
            comboFull = true;
            cmbTaskState.SelectedIndex = -1;
            rbDeliveryDate.Checked = false;
            rbStartDate.Checked = false;
            dataGridView1.DataSource = taskdto.Tasks;
        }
        TaskDetailDTO detail = new TaskDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.Title = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.UserNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detail.Name = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.Surname = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.TaskStartDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.TaskDeliveryDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            detail.TaskID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            detail.EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            detail.Content = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            detail.TaskStateID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[14].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this task?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                TaskBLL.DeleteTask(detail.TaskID);
                MessageBox.Show("Task was deleted");
                FillAllData();
                ClearFilters();
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (UserStatic.isAdmin && detail.TaskStateID==TaskStates.OnEmployee && detail.EmployeeID != UserStatic.EmployeeID)
            {
                MessageBox.Show("Before approve a task employee have to deliver task");
            }
            else if (UserStatic.isAdmin && detail.TaskStateID == TaskStates.Approved)
            {
                MessageBox.Show("This task is already approved");
            }
            else if (!UserStatic.isAdmin && detail.TaskStateID == TaskStates.Delivered)
            {
                MessageBox.Show("This task is already delivered");
            }
            else if (!UserStatic.isAdmin && detail.TaskStateID == TaskStates.Approved)
            {
                MessageBox.Show("This task is already approved");
            }
            else
            {
                TaskBLL.ApproveTask(detail.TaskID, UserStatic.isAdmin);
                MessageBox.Show("Task was approved");
                FillAllData();
                ClearFilters();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.ExcelExport(dataGridView1);
        }
    }
}
