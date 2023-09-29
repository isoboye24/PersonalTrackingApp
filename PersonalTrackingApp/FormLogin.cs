using BLL;
using DAL;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter user number and password");
            }
            else
            {
                List<EMPLOYEE> employeeList = EmployeeBLL.GetEmployee(txtPassword.Text, Convert.ToInt32(txtUserNo.Text));
                if (employeeList.Count == 0)
                {
                    MessageBox.Show("Please control your information");
                }
                else
                {
                    EMPLOYEE employee = new EMPLOYEE();
                    employee = employeeList.First();
                    UserStatic.EmployeeID = employee.employeeID;
                    UserStatic.UserNo = employee.userNo;
                    UserStatic.isAdmin = employee.isAdmin;
                    FormMain open = new FormMain();
                    this.Hide();
                    open.ShowDialog();
                }
            }
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
