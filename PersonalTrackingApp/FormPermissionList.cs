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

namespace PersonalTrackingApp
{
    public partial class FormPermissionList : Form
    {
        public FormPermissionList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormPermission open = new FormPermission();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
            FillData();
            ClearFilters();
        }

        private void txtDayAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.PermissionID == 0)
            {
                MessageBox.Show("Please select a permission from the table");
            }
            else if (detail.State == PermissionStates.Approve || detail.State == PermissionStates.Disapprove)
            {
                MessageBox.Show("You cannot update any approved or disapproved permission");
            }
            else
            {
                FormPermission open = new FormPermission();
                open.isUpdate = true;
                open.detail = detail;
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
                FillData();
                ClearFilters();
            }
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        PermissionDTO dto = new PermissionDTO();
        private bool comboFull = false;

        void FillData()
        {
            dto = PermissionBLL.GetAll();
            if (!UserStatic.isAdmin)
            {
                dto.Permissions = dto.Permissions.Where(x =>x.EmployeeID==UserStatic.EmployeeID).ToList();
            }
            dataGridView1.DataSource = dto.Permissions;

            comboFull = false;
            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.DisplayMember = "Departmentname";
            cmbDepartment.ValueMember = "DepartmentID";
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "Positionname";
            cmbPosition.ValueMember = "PositionID";
            cmbPosition.SelectedIndex = -1;
            comboFull = true;
            cmbState.DataSource = dto.PermissionStates;
            cmbState.DisplayMember = "permissionStateName";
            cmbState.ValueMember = "permissionStateID";
            cmbState.SelectedIndex = -1;
        }
        private void FormPermissionList_Load(object sender, EventArgs e)
        {
            FillData();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User No";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Surname";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].HeaderText = "State Date";
            dataGridView1.Columns[10].HeaderText = "End Date";
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].HeaderText = "State";
            dataGridView1.Columns[13].HeaderText = "Day Amount";
            dataGridView1.Columns[14].Visible = false;
            if (!UserStatic.isAdmin)
            {
                panel3.Visible = false;
                btnApprove.Hide();
                btnDisapprove.Hide();
                btnDelete.Hide();
                btnNew.Location = new Point(232, 30);
                btnUpdate.Location = new Point(343, 30);
                btnClose.Location = new Point(448, 30);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<PermissionDetailsDTO> list = dto.Permissions;
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
            if (rbStartDate.Checked )
            {
                list = list.Where(x => x.StartDate < Convert.ToDateTime(dateTimePickerFinish.Value) && 
                x.StartDate > Convert.ToDateTime(dateTimePickerStart.Value)).ToList();
            }
            if (rbEndDate.Checked)
            {
                list = list.Where(x => x.EndDate < Convert.ToDateTime(dateTimePickerFinish.Value) &&
                x.EndDate > Convert.ToDateTime(dateTimePickerStart.Value)).ToList();
            }
            if (cmbState.SelectedIndex != -1)
            {
                list = list.Where(x => x.State == Convert.ToInt32(cmbState.SelectedValue)).ToList();
            }
            if (txtDayAmount.Text.Trim() != "")
            {
                list = list.Where(x => x.PermissionDayAmount == Convert.ToInt32(txtDayAmount.Text)).ToList();
            }
            dataGridView1.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }
        void ClearFilters()
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtDayAmount.Clear();
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            cmbState.SelectedIndex = -1;
            cmbPosition.DataSource = dto.Positions;
            cmbState.DataSource = dto.PermissionStates;
            //dateTimePickerFinish = DateTime.Today;
            //dateTimePickerStart = DateTime.Today;
            comboFull = false;
            dataGridView1.DataSource = dto.Permissions;
        }

        PermissionDetailsDTO detail = new PermissionDetailsDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.PermissionID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            detail.UserNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detail.State = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
            detail.StartDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
            detail.EndDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
            detail.Explanation = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();            
            detail.PermissionDayAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[13].Value);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            PermissionBLL.UpdatePermission(detail.PermissionID, PermissionStates.Approve);
            MessageBox.Show("Approved");
            FillData();
            ClearFilters();
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            PermissionBLL.UpdatePermission(detail.PermissionID, PermissionStates.Disapprove);
            MessageBox.Show("Disapproved");
            FillData();
            ClearFilters();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this permission?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (detail.State == PermissionStates.Approve || detail.State == PermissionStates.Disapprove)
                {
                    MessageBox.Show("You cannot delete approved or disapproved permission");
                }
                else
                {
                    PermissionBLL.DeletePermission(detail.PermissionID);
                    MessageBox.Show("Permission was deleted");
                    FillData();
                    ClearFilters();
                }
            }
        }
    }
}
