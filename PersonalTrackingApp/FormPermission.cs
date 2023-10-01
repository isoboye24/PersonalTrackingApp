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
using DAL.DataTransferObject;

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
        public bool isUpdate = false;
        public PermissionDetailsDTO detail = new PermissionDetailsDTO();
        private void FormPermission_Load(object sender, EventArgs e)
        {
            txtUserNo.Text = UserStatic.UserNo.ToString();
            if (isUpdate)
            {
                dateTimePickerStart.Value = (DateTime)detail.StartDate;
                dateTimePickerFinish.Value = (DateTime)detail.EndDate;
                txtDayAmount.Text = detail.PermissionDayAmount.ToString();
                txtUserNo.Text = detail.UserNo.ToString();
                txtExplanation.Text = detail.Explanation;
            }
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
                if (!isUpdate)
                {
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
                else if(isUpdate)
                {
                    DialogResult result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        permission.permissionID = detail.PermissionID;
                        permission.permissionExplanation = txtExplanation.Text;
                        permission.permissionStartDate = dateTimePickerStart.Value;
                        permission.permissionEndDate = dateTimePickerFinish.Value;
                        permission.permissionDay = Convert.ToInt32(txtDayAmount.Text);
                        PermissionBLL.UpdatePermission(permission);
                        MessageBox.Show("Permission was updated");
                        this.Close();
                    }
                }
            }
        }
    }
}
