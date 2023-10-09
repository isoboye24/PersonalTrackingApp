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

namespace PersonalTrackingApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            if (!UserStatic.isAdmin)
            {
                EmployeeDTO dto = EmployeeBLL.GetAll();
                EmployeeDetailsDTO detail = dto.Employees.First(x =>x.EmployeeID == UserStatic.EmployeeID);
                FormEmployee open = new FormEmployee();
                open.detail = detail;
                open.isUpdate = true;
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
            }
            else
            {
                FormEmployeeList2 open = new FormEmployeeList2();
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
            }
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            FormTaskList open = new FormTaskList();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            FormSalaryList open = new FormSalaryList();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            FormPermissionList open = new FormPermissionList();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            FormDepartmentList open = new FormDepartmentList();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            FormPositionList open = new FormPositionList();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormLogin open = new FormLogin();
            this.Hide();
            open.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (!UserStatic.isAdmin)
            {
                btnDepartment.Visible = false;
                btnPosition.Visible = false;
                btnLogout.Location = new Point(12, 169);
                btnExit.Location = new Point(160, 169);
            }
        }
    }
}
