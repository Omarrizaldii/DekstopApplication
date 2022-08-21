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
    public partial class frmViewSchedule : Form
    {
        public frmViewSchedule()
        {
            InitializeComponent();
        }
        int departure, arrival;
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void frmViewSchedule_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            DisplayData();
            cbArrival.Text = "Dipatiukur";
            cbDeparture.Text = "Binus";
        }

        private void DisplayData()
        {
            
            cbDeparture.DataSource = db.pools.Select(s => s.name);
            cbArrival.DataSource = db.pools.Select(s => s.name);
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        private void cbDeparture_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDeparture.SelectedItem != null)
            {
            List<pool> pools = db.pools.Select(s => s).ToList();
            departure = pools[cbDeparture.SelectedIndex].id;

            }
        }

        private void cbArrival_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbArrival.SelectedItem != null)
            {
                List<pool> pools = db.pools.Select(s => s).ToList();
                arrival = pools[cbArrival.SelectedIndex].id;
            }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }
        int _capacity;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (e.RowIndex >-1)
                {
                    DataGridViewRow r = dataGridView1.Rows[e.RowIndex];
                    Helper.idSchedule = int.Parse(r.Cells[2].Value.ToString());
                    Helper.capacity = int.Parse(r.Cells[7].Value.ToString());
                    new frmViewScheduleDetail().ShowDialog();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = from a in db.schedules
                                       join b in db.pools
                                       on a.departure_pool_id equals b.id
                                       where a.arrival_pool_id == arrival
                                       where a.departure_pool_id == departure
                                       where a.departure_time.Day == dateTimePicker1.Value.Day
                                       select new
                                       {
                                           a.id,
                                           DeparturePool = b.city,
                                           DepartureTime = a.departure_time,
                                           ArrivalPool = a.pool.city,
                                           ArrivalTime = a.arrival_time,
                                           AvailableSeat = a.capacity,
                                           Price = a.price
                                       };
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[0].DisplayIndex = 7;
            dataGridView1.Columns[1].DisplayIndex = 7;
        }
    }
}
