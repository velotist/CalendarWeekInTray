using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CalendarWeek
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalendarWeekContext());
        }
    }

    public class CalendarWeekContext : ApplicationContext
    {   
        private readonly NotifyIcon trayIcon;

        public CalendarWeekContext()
        {
            trayIcon = new NotifyIcon()
            {
                Text = "Calendar Week",
                Icon = new Icon("P:/temp/New_Logo_Spi_Square.ico"),
                ContextMenuStrip = new ContextMenuStrip() { Text = "Exit" },
                Visible = true,
            };

            trayIcon.MouseMove += new MouseEventHandler(NotifyIconMouseMove);
        }
        private void NotifyIconMouseMove(object sender, MouseEventArgs e)
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");
            Calendar cultureInfoCalendar = cultureInfo.Calendar;
            CalendarWeekRule calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
            DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            trayIcon.Text = "Time: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + "\n\nKW " + cultureInfoCalendar.GetWeekOfYear(DateTime.Now, calendarWeekRule, firstDayOfWeek);
        }

        private void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}