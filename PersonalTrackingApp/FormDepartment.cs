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

namespace PersonalTrackingApp
{
    public partial class FormDepartment : Form
    {
        public FormDepartment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDepartment.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the name field");
            }
            else
            {
                DEPARTMENT department = new DEPARTMENT();
                if (!isUpdate)
                {                
                    department.departmentName = txtDepartment.Text;
                    DepartmentBLL.AddDepartment(department);
                    MessageBox.Show("Department was added successfully");
                    txtDepartment.Clear();               
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        department.departmentID = detail.departmentID;
                        department.departmentName = txtDepartment.Text;
                        DepartmentBLL.UpdateDepartment(department);
                        MessageBox.Show("Department has been updated");
                        this.Close();
                    }                    
                }            
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool isUpdate = false;
        public DEPARTMENT detail = new DEPARTMENT();

        private void FormDepartment_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                txtDepartment.Text = detail.departmentName;
            }
        }
    }
}
