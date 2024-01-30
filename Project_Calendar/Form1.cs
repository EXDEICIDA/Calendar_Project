using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;



namespace Project_Calendar
{
    public partial class CalendarForm : Form
    {
        DateTime currentDT = DateTime.Now;
        int currentMonth;
        int currentYear;
        int month, year;
        
        public CalendarForm()
        {
            InitializeComponent();
            currentMonth = currentDT.Month;
            currentYear = currentDT.Year;
        }

        private void CalendarForm_Load(object sender, EventArgs e) // Changed event name to match Form_Load signature
        {
            DisplayDays(); // Corrected method name to PascalCase
        }

        private void DisplayDays() // Corrected method name to PascalCase
        {
            // Use stored values of currentMonth and currentYear instead of DateTime.Now
            month = currentMonth;
            year = currentYear;

            String monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthName + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d") + 1);

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                dayContainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDays userControlDays = new UserControlDays();
                userControlDays.SetDay(i); // Set the day number
                dayContainer.Controls.Add(userControlDays);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentMonth -= 1;
            if (currentMonth < 1)
            {
                currentMonth = 12;
                currentYear--;
            }

            UpdateCalendar();
        }

        private void LBDATE_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentMonth += 1;
            if (currentMonth > 12)
            {
                currentMonth = 1;
                currentYear++;
            }

            UpdateCalendar();
        }




        private void UpdateCalendar()
        {
            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(currentMonth);
            LBDATE.Text = monthName + " " + currentYear;

            DateTime startOfTheMonth = new DateTime(currentYear, currentMonth, 1);
            int daysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);
            int dayOfWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d") + 1);

            int currentDay = 1;

            foreach (Control control in dayContainer.Controls)
            {
                if (control is UserControlDays userControlDays)
                {
                    if (currentDay <= daysInMonth)
                    {
                        userControlDays.days(currentDay);
                        currentDay++;
                    }
                    else
                    {
                        // Hide or remove excess controls if any
                        control.Visible = false;
                    }
                }
            }

            // Remove any excess controls
            for (int i = dayContainer.Controls.Count - 1; i >= 0; i--)
            {
                if (!dayContainer.Controls[i].Visible)
                {
                    dayContainer.Controls.RemoveAt(i);
                }
            }

            // Add new controls for remaining days
            for (int i = currentDay; i <= daysInMonth; i++)
            {
                UserControlDays userControlDays = new UserControlDays();
                userControlDays.days(i);
                dayContainer.Controls.Add(userControlDays);
            }
        }

    }
}
