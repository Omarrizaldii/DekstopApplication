using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESEMKATravel
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                Helper.message("Please enter email");
            }
            else if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                Helper.message("Please enter password");
            }
            else
            {
                employee emp = db.employees.Where(S => S.email == textBox1.Text && S.password == textBox2.Text).FirstOrDefault();
                if (emp != null)
                {
                    if (emp.deleted_at != null)
                    {
                        Helper.message("Your account has been deleted");
                    }
                    else
                    {
                        this.Hide();
                        new frmMain(emp).Show();
                    }
                }
                else
                {
                    Helper.message("Sorry your email or password is not valid, Please try again");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
