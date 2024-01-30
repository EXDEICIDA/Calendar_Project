using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Calendar
{
    public partial class UserControlDays : UserControl
    {
        public int Day { get; set; }
        public bool IsCurrentDay { get; set; }
        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        public void days (int numday)
        {
            lbdays.Text = numday + "";
        } public void SetDay(int day)
        {
            // Display the day in the label
            lbdays.Text = day.ToString();
        }
    }
}
