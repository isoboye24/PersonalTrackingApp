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
    public partial class FormSalary : Form
    {
        public FormSalary()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        SalaryDTO dto = new SalaryDTO();
        private bool comboFull = false;
        SALARY salary = new SALARY();
        public SalaryDetailDTO detail = new SalaryDetailDTO();
        public bool isUpdate = false;
        int OldSalary = 0;
        private void FormSalary_Load(object sender, EventArgs e)
        {
            dto = SalaryBLL.GetAll();
            if (!isUpdate)
            {
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
                if (dto.Departments.Count > 0)
                {
                    comboFull = true;
                }
            }
            cmbMonth.DataSource = dto.Months;
            cmbMonth.DisplayMember = "monthName";
            cmbMonth.ValueMember = "monthID";
            cmbMonth.SelectedIndex = -1;
            if (isUpdate)
            {
                panel1.Hide();
                txtName.Text = detail.Name;
                txtSalary.Text = detail.SalaryAmount.ToString();
                txtSurname.Text = detail.Surname;
                txtUserNo.Text = detail.UserNo.ToString();
                txtYear.Text = detail.SalaryYear.ToString();
                cmbMonth.SelectedValue = detail.MonthID;
            }            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtYear.Text.Trim() == "")
            {
                MessageBox.Show("Please enter year");
            }
            else if (txtSalary.Text.Trim() == "")
            {
                MessageBox.Show("Please enter salary");
            }
            else if (cmbMonth.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose month");
            }
            else if (txtUserNo.Text.Trim() == "")
            {
                MessageBox.Show("Please choose month");
            }
            else
            {
                bool control = false;
                if (!isUpdate)
                {
                    if (salary.employeeID == 0)
                    {
                        MessageBox.Show("Please select salary from the table");
                    }
                    else
                    {
                        salary.amount = Convert.ToInt32(txtSalary.Text);
                        salary.year = Convert.ToInt32(txtYear.Text);
                        salary.month = Convert.ToInt32(cmbMonth.SelectedValue);
                        if (salary.amount > OldSalary)
                        {
                            control = true;
                        }
                        SalaryBLL.AddSalary(salary, control);
                        MessageBox.Show("Salary is added");
                        salary = new SALARY();
                        cmbMonth.SelectedIndex = -1;
                        //txtSalary.Clear();
                    }                    
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure?", "title", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        SALARY updateSalary = new SALARY();
                        updateSalary.salaryID = detail.SalaryID;
                        updateSalary.employeeID = detail.EmployeeID;
                        updateSalary.month = Convert.ToInt32(cmbMonth.SelectedValue);
                        updateSalary.year = Convert.ToInt32(txtYear.Text);
                        updateSalary.amount = Convert.ToInt32(txtSalary.Text);
                       
                        if (updateSalary.amount > detail.OldSalary)
                        {
                            control = true;
                        }
                        SalaryBLL.UpdateSalary(updateSalary, control);
                        MessageBox.Show("Salary is updated");
                        this.Close();
                    }
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            salary.employeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            //OldSalary = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
            txtUserNo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtYear.Text = DateTime.Today.Year.ToString();
            txtSalary.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }
    }
}
