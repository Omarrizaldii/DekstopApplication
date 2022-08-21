using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESEMKATravel
{
    public partial class frmMain : Form
    {
        employee emp;
        public frmMain(employee employee)
        {
            emp = db.employees.Where(S => S.email == employee.email && S.password == employee.password).FirstOrDefault();
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void frmMain_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            laDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            laWelcome.Text = $"Welcome, {emp.name}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to logout?","Information",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                this.Hide();
                new frmLogin().Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmViewSchedule().Show();
        }
    }
}
