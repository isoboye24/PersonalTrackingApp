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
    public partial class FormPosition : Form
    {
        public FormPosition()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPosition.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the position name");
            }
            else if (cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a department");
            }
            else
            {
                if (!isUpdate)
                {
                    POSITION position = new POSITION();
                    position.positionName = txtPosition.Text;
                    position.departmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                    PositionBLL.AddPosition(position);
                    MessageBox.Show("Position added successfully");
                    txtPosition.Clear();
                    cmbDepartment.SelectedIndex = -1;
                }
                else
                {
                    POSITION position = new POSITION();
                    position.positionID = detail.positionID;
                    position.positionName = detail.positionName;
                    position.departmentID = detail.departmentID;
                    bool control = false;
                    if (Convert.ToInt32(cmbDepartment.SelectedValue) != detail.OldDepartmentID)
                    {
                        control = true;
                    }
                    PositionBLL.UpdatePostion(position, control);
                    MessageBox.Show("Position was updated");
                    this.Close();
                }
            }
        }

        List<DEPARTMENT> departmentList = new List<DEPARTMENT>();
        public PositionDTO detail = new PositionDTO();
        public bool isUpdate = false;
        private void FormPosition_Load(object sender, EventArgs e)
        {
            departmentList = DepartmentBLL.GetDepartments();
            cmbDepartment.DataSource = departmentList;
            cmbDepartment.DisplayMember = "departmentName";
            cmbDepartment.ValueMember = "departmentID";
            cmbDepartment.SelectedIndex = -1;
            if (isUpdate)
            {
                txtPosition.Text = detail.positionName;
                cmbDepartment.SelectedValue = detail.departmentID;
            }
        }
    }
}
