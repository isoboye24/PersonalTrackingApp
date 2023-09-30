using DAL;
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
    public partial class FormPermission : Form
    {
        public FormPermission()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        TimeSpan permissionDay;
        private void FormPermission_Load(object sender, EventArgs e)
        {
            txtUserNo.Text = UserStatic.UserNo.ToString();
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            permissionDay = dateTimePickerFinish.Value.Date - dateTimePickerStart.Value.Date;
            txtDayAmount.Text = permissionDay.TotalDays.ToString();
        }

        private void dateTimePickerFinish_ValueChanged(object sender, EventArgs e)
        {
            permissionDay = dateTimePickerFinish.Value.Date - dateTimePickerStart.Value.Date;
            txtDayAmount.Text = permissionDay.TotalDays.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDayAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please enter amount of days");
            }
            else if (Convert.ToInt32(txtDayAmount.Text) <= 0)
            {
                MessageBox.Show("End date must be greater than the start date");
            }
            if (txtExplanation.Text.Trim() == "")
            {
                MessageBox.Show("Please enter explanation");
            }
            else
            {
                PERMISSION permission = new PERMISSION();
                permission.employeeID = UserStatic.EmployeeID;
                permission.permissionState = 1;
                permission.permissionStartDate = dateTimePickerStart.Value.Date;
                permission.permissionEndDate = dateTimePickerFinish.Value.Date;
                permission.permissionDay = Convert.ToInt32(txtDayAmount.Text);
                permission.permissionExplanation = txtExplanation.Text;
                PermissionBLL.AddPermission(permission);
                MessageBox.Show("Permission was added");
                permission = new PERMISSION();
                dateTimePickerStart.Value = DateTime.Today;
                dateTimePickerFinish.Value = DateTime.Today;
                txtDayAmount.Clear();
                txtExplanation.Clear();
            }
        }
    }
}
