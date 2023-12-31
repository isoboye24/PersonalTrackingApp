﻿using DAL.DataTransferObject;
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
using DAL.DataTransferObject;
using DAL;

namespace PersonalTrackingApp
{
    public partial class FormSalaryList : Form
    {
        public FormSalaryList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormSalary open = new FormSalary();
            this.Close();
            open.ShowDialog();
            this.Visible = true;
            FillAllData();
            ClearFillters();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.SalaryID == 0)
            {
                MessageBox.Show("Please select a salary from the table");
            }
            else
            {
                FormSalary open = new FormSalary();
                open.isUpdate = true;
                open.detail = detail;
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
                FillAllData();
                ClearFillters();
            }            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        SalaryDTO dto = new SalaryDTO();
        private bool comboFull = false;
        SalaryDetailDTO detail = new SalaryDetailDTO();
        public bool isUpdate = false;

        void FillAllData()
        {
            dto = SalaryBLL.GetAll();
            if (!UserStatic.isAdmin)
            {
                dto.Salaries = dto.Salaries.Where(x => x.EmployeeID == UserStatic.EmployeeID).ToList();
            }
            dataGridView1.DataSource = dto.Salaries;

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
            cmbMonth.DataSource = dto.Months;
            cmbMonth.DisplayMember = "monthName";
            cmbMonth.ValueMember = "monthID";
            cmbMonth.SelectedIndex = -1;
        }
        private void FormSalaryList_Load(object sender, EventArgs e)
        {
            FillAllData();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "User No";
            dataGridView1.Columns[3].HeaderText = "Name";
            dataGridView1.Columns[4].HeaderText = "Surname";
            dataGridView1.Columns[5].HeaderText = "Salary";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].HeaderText = "Year";
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].HeaderText = "Month";
            if (!UserStatic.isAdmin)
            {
                btnUpdate.Hide();
                btnDelete.Hide();
                btnNew.Location = new Point(293, 14);
                btnClose.Location = new Point(420, 14);
                panelAdmin.Hide();
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                cmbPosition.DataSource = dto.Positions.Where(x => x.departmentID == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<SalaryDetailDTO> list = dto.Salaries;
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
            if (txtYear.Text.Trim() != "")
            {
                list = list.Where(x => x.SalaryYear == Convert.ToInt32(txtYear.Text)).ToList();
            }
            if (cmbMonth.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonth.SelectedValue)).ToList();
            }
            if (txtSalary.Text.Trim() != "")
            {
                if (rbMore.Checked)
                {
                    list = list.Where(x => x.SalaryAmount > Convert.ToInt32(txtSalary.Text)).ToList();
                }
                else if (rbLess.Checked)
                {
                    list = list.Where(x => x.SalaryAmount < Convert.ToInt32(txtSalary.Text)).ToList();
                }
                else
                {
                    list = list.Where(x => x.SalaryAmount == Convert.ToInt32(txtSalary.Text)).ToList();
                }
            }
            dataGridView1.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFillters();
        }
        void ClearFillters()
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();
            comboFull = false;
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.SelectedIndex = -1;
            comboFull = true;
            cmbMonth.SelectedIndex = -1;
            txtYear.Clear();
            txtSalary.Clear();
            rbLess.Checked = false;
            rbMore.Checked = false;
            rbEquals.Checked = false;
            dataGridView1.DataSource = dto.Salaries;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.UserNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            detail.SalaryID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detail.SalaryAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            detail.SalaryYear = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
            detail.OldSalary = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
            detail.MonthID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
            detail.Name = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.Surname = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You are sure you want to delete this salary?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SalaryBLL.DeleteSalary(detail.SalaryID);
                MessageBox.Show("Salary was deleted");
                FillAllData();
                ClearFillters();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.ExcelExport(dataGridView1);
        }
    }
}
