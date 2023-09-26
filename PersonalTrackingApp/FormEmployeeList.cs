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
    public partial class FormEmployeeList : Form
    {
        public FormEmployeeList()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormEmployee open = new FormEmployee();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormEmployee open = new FormEmployee();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }        
                
        EmployeeDTO dto = new EmployeeDTO();
        private bool comboFull = false;
        private void FormEmployeeList_Load(object sender, EventArgs e)
        {
            dto = EmployeeBLL.GetAll();
            dataGridView1.DataSource = dto.Employees;

            dataGridView1.Columns[0].Visible = false; 
            dataGridView1.Columns[1].HeaderText = "User No";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Name";
            dataGridView1.Columns[4].HeaderText = "Surname";
            dataGridView1.Columns[5].HeaderText = "Department";
            dataGridView1.Columns[6].HeaderText = "Position";
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].HeaderText = "Salary";
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            //comboFull = false;

            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.DisplayMember = "Department name";
            cmbDepartment.ValueMember = "DepartmentID";
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "Position name";
            cmbPosition.ValueMember = "PositionID";
            cmbPosition.SelectedIndex = -1;
            comboFull = true;
        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPosition.DataSource = dto.Positions.Where(x => x.departmentID ==  Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
        }
    }
}
