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
        private void btnNew_Click(object sender, EventArgs e)
        {
            FormPosition open = new FormPosition();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
            FillGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormPosition open = new FormPosition();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }

        private void FormPositionList_Load(object sender, EventArgs e)
        {
            FillGrid();
            dataGridView1.Columns[0].HeaderText = "Department Name";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Position Name";
            dataGridView1.Columns[3].Visible = false;
        }
    }
}
