using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESEMKATravel
{
    class Helper
    {
        public static void message(string mes)
        {
           MessageBox.Show(mes,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public static int capacity,idSchedule;
    }
}
