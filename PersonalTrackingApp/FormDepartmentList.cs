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
    public partial class FormDepartmentList : Form
    {
        public FormDepartmentList()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormDepartment open = new FormDepartment();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
            FillGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.departmentID == 0)
            {
                MessageBox.Show("Please choose a department from the table");
            }
            else
            {
                FormDepartment open = new FormDepartment();
                open.detail = detail;
                open.isUpdate = true;
                this.Hide();
                open.ShowDialog();
                FillGrid();
                this.Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void FillGrid()
        {
            list = DepartmentBLL.GetDepartments();
            dataGridViewDept.DataSource = list;
        }
        List<DEPARTMENT> list = new List<DEPARTMENT>();
        public bool isUpdate = false;
        public DEPARTMENT detail = new DEPARTMENT();
        private void FormDepartmentList_Load(object sender, EventArgs e)
        {
            FillGrid();
            dataGridViewDept.Columns[0].Visible = false;
            dataGridViewDept.Columns[1].HeaderText = "Department Name";
        }

        private void dataGridViewDept_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.departmentID = Convert.ToInt32(dataGridViewDept.Rows[e.RowIndex].Cells[0].Value);
            detail.departmentName = dataGridViewDept.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this department?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DepartmentBLL.DeleteDepartment(detail.departmentID);
                MessageBox.Show("Department was deleted");
                FillGrid();
            }
        }
    }
}
