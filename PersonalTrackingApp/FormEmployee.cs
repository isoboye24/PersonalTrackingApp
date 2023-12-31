﻿using System;
using System.IO;
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
using System.Net;

namespace PersonalTrackingApp
{
    public partial class FormEmployee : Form
    {
        public FormEmployee()
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
        EmployeeDTO dto = new EmployeeDTO();
        public EmployeeDetailsDTO detail = new EmployeeDetailsDTO();
        public bool isUpdate = false;
        string imagePath = "";
        private void FormEmployee_Load(object sender, EventArgs e)
        {
            dto = EmployeeBLL.GetAll();
            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.DisplayMember = "departmentName";
            cmbDepartment.ValueMember = "departmentID";
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "positionName";
            cmbPosition.ValueMember = "positionID";
            cmbPosition.SelectedIndex = -1;
            comboFull = true;
            if (isUpdate)
            {
                txtUserNo.Text = detail.UserNo.ToString();
                txtSalary.Text = detail.Salary.ToString();
                txtName.Text = detail.Name;
                txtSurname.Text = detail.Surname;
                txtPassword.Text = detail.Password;
                txtAddress.Text = detail.Address;
                rbIsAdmin.Checked = Convert.ToBoolean(detail.IsAdmin);
                dateTimePickerBirthday.Value = Convert.ToDateTime(detail.Birthday);
                cmbDepartment.SelectedValue = detail.DepartmentID;
                cmbPosition.SelectedValue = detail.PositionID;
                imagePath = Application.StartupPath + "\\images\\" + detail.ImagePath;
                pictureBox1.ImageLocation = imagePath;
                if (!UserStatic.isAdmin)
                {
                    cmbDepartment.Enabled = false;
                    cmbPosition.Enabled = false;
                    txtUserNo.Enabled = false;
                    txtSalary.Enabled = false;
                    rbIsAdmin.Hide();
                    btnCheck.Hide();
                }
            }
        }
        bool comboFull = false;
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                // The employee's position must match with his department
                int departID = Convert.ToInt32(cmbDepartment.SelectedValue);
                cmbPosition.DataSource = dto.Positions.Where(x => x.departmentID == departID).ToList();
            }
        }
        OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(OpenFileDialog1.FileName);
                txtImagePath.Text = OpenFileDialog1.FileName;
                string unique = Guid.NewGuid().ToString();
                fileName += unique + OpenFileDialog1.SafeFileName;
            }
        }
        string fileName = "";
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter User number");
            }            
            else if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter password");
            }
            else if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter name");
            }
            else if (txtSurname.Text.Trim() == "")
            {
                MessageBox.Show("Please enter surname");
            }
            else if (txtSalary.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Salary");
            }
            else if (cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a department");
            }
            else if (cmbPosition.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a position");
            }
            else
            {
                if (!isUpdate)
                {
                    if (!isUnique)
                    {
                        MessageBox.Show("This user number is used by another employee. Please, change");
                    }
                    EMPLOYEE employee = new EMPLOYEE();
                    employee.userNo = Convert.ToInt32(txtUserNo.Text);
                    employee.password = txtPassword.Text;
                    employee.isAdmin = rbIsAdmin.Checked;
                    employee.name = txtName.Text;
                    employee.surname = txtSurname.Text;
                    employee.salary = Convert.ToInt32(txtSalary.Text);
                    employee.departmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                    employee.positionID = Convert.ToInt32(cmbPosition.SelectedValue);
                    employee.address = txtAddress.Text;
                    employee.birthday = dateTimePickerBirthday.Value;
                    employee.imagePath = fileName;
                    EmployeeBLL.AddEmployee(employee);
                    try
                    {
                        File.Copy(txtImagePath.Text, @"images\\" + fileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot find the path to this picture");
                    }
                    MessageBox.Show("Employee was added");

                    txtUserNo.Clear();
                    txtPassword.Clear();
                    rbIsAdmin.Checked = false;
                    txtName.Clear();
                    txtSurname.Clear();
                    txtSalary.Clear();
                    txtAddress.Clear();
                    txtImagePath.Clear();
                    pictureBox1.Image = null;
                    comboFull = false;
                    cmbDepartment.SelectedIndex = -1;
                    cmbPosition.SelectedIndex = -1;
                    cmbPosition.DataSource = dto.Positions;
                    dateTimePickerBirthday.Value = DateTime.Today;
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        EMPLOYEE employee = new EMPLOYEE();
                        if (txtImagePath.Text != imagePath)
                        {
                            if (File.Exists(@"images\\"+detail.ImagePath))
                            {
                                File.Delete(@"images\\" + detail.ImagePath);
                            }
                            File.Copy(txtImagePath.Text, @"images\\" + fileName);
                            employee.imagePath = fileName;
                        }
                        else
                        {
                            employee.imagePath = detail.ImagePath;
                            employee.employeeID = detail.EmployeeID;
                            employee.userNo = detail.UserNo;
                            employee.name = detail.Name;
                            employee.surname = detail.Surname;
                            employee.isAdmin = detail.IsAdmin;
                            employee.password = detail.Password;
                            employee.address = detail.Address;
                            employee.birthday = dateTimePickerBirthday.Value;
                            employee.departmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                            employee.positionID = Convert.ToInt32(cmbPosition.SelectedValue);
                            employee.salary = Convert.ToInt32(txtSalary.Text);
                            EmployeeBLL.UpdateEmpoyee(employee);
                            MessageBox.Show("Employee was updated");
                            this.Close();
                        }
                    }
                }
            }
        }
        bool isUnique = false;
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter User number");
            }
            else
            {
                isUnique = EmployeeBLL.IsUnique(Convert.ToInt32(txtUserNo.Text));
                if (!isUnique)
                {
                    MessageBox.Show("This user number is used by another employee. Please, change");
                }
                else
                {
                    MessageBox.Show("This user number is usable");
                }
            }
        }
    }
}
