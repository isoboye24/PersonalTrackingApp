using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.DataTransferObject;
using BLL;

namespace PersonalTrackingApp
{
    public partial class FormPositionList : Form
    {
        public FormPositionList()
        {
            InitializeComponent();
        }
        void FillGrid()
        {
            positionList = PositionBLL.GetPositions();
            dataGridView1.DataSource = positionList;
        }
        List<PositionDTO> positionList = new List<PositionDTO>();
        PositionDTO detail = new PositionDTO();
        public bool isUpdate = false;
        private void btnNew_Click(object sender, EventArgs e)
        {
            FormPosition open = new FormPosition();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
            FillGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.positionID == 0)
            {
                MessageBox.Show("Please select a position from the table");
            }
            else
            {
                FormPosition open = new FormPosition();
                open.isUpdate = true;
                open.detail = detail;
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
                FillGrid();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void FormPositionList_Load(object sender, EventArgs e)
        {
            FillGrid();
            dataGridView1.Columns[0].HeaderText = "Department Name";
            dataGridView1.Columns[2].HeaderText = "Position ID";
            dataGridView1.Columns[1].HeaderText = "Old Department ID";            
            dataGridView1.Columns[3].HeaderText = "Position Name";
            dataGridView1.Columns[4].HeaderText = "Department ID";
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.positionID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            detail.positionName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.departmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.OldDepartmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
        }

       
    }
}
