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
    public partial class frmViewScheduleDetail : Form
    {
        string button;
        public frmViewScheduleDetail()
        {
            InitializeComponent();
        }

        private void frmViewScheduleDetail_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            display();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void display()
        {
            button1.Enabled = false;
            if (Helper.capacity == 5)
            {
                btn6.Visible = false;
                btn7.Visible = false;
                btn8.Visible = false;
                btn9.Visible = false;
                btn10.Visible = false;
                btn11.Visible = false;
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            button = btn.Text;

        }
    }
}
