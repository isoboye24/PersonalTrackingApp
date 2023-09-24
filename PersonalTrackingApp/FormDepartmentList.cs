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
            FormDepartment open = new FormDepartment();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
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
        private void FormDepartmentList_Load(object sender, EventArgs e)
        {
            FillGrid();
            dataGridViewDept.Columns[0].Visible = false;
            dataGridViewDept.Columns[1].HeaderText = "Department Name";
        }
    }
}
