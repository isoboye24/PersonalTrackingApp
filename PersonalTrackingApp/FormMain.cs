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
            FormEmployeeList open = new FormEmployeeList();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
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
    }
}
