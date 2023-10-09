using BLL;
using DAL.DataTransferObject;
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
    public partial class FormEmployeeList2 : Form
    {
        public FormEmployeeList2()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormEmployee open = new FormEmployee();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
            FillAllData();
            ClearFilters();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.EmployeeID == 0)
            {
                MessageBox.Show("Please select an employee from the table");
            }
            else 
            {
                FormEmployee open = new FormEmployee();
                open.isUpdate = true;
                open.detail = detail;
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
                FillAllData();
                ClearFilters();
            }
            
        }

        EmployeeDTO dto = new EmployeeDTO();
        private bool comboFull = false;
        EmployeeDetailsDTO detail = new EmployeeDetailsDTO();
        bool isUpdate = false;
        private void btnSearch_Click(object sender, EventArgs e)
        {

            List<EmployeeDetailsDTO> list = dto.Employees;
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
            dataGridView1.DataSource = list;
        }

        void FillAllData()
        {
            dto = EmployeeBLL.GetAll();
            dataGridView1.DataSource = dto.Employees;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User No";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Surname";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Department";
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Position";
            dataGridView1.Columns[9].HeaderText = "Salary";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            comboFull = false;
            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.DisplayMember = "Departmentname";
            cmbDepartment.ValueMember = "DepartmentID";
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "Positionname";
            cmbPosition.ValueMember = "PositionID";
            cmbPosition.SelectedIndex = -1;
            comboFull = true;
        }
        private void FormEmployeeList2_Load(object sender, EventArgs e)
        {
            FillAllData();
        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }
        void ClearFilters()
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            cmbPosition.DataSource = dto.Positions;
            comboFull = false;
            dataGridView1.DataSource = dto.Employees;
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                cmbPosition.DataSource = dto.Positions.Where(x => x.departmentID == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.UserNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detail.Name = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.Surname = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.ImagePath = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            detail.DepartmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            detail.DepartmentName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            detail.PositionID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            detail.PositionName = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            detail.Salary = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
            detail.Birthday = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
            detail.Address = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            detail.Password = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            detail.IsAdmin = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[13].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                EmployeeBLL.DeleteEmployee(detail.EmployeeID);
                MessageBox.Show("Employee was deleted");
                FillAllData();
                ClearFilters();
            }
        }
    }
}
