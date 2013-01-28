using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldiers
{
    public class date
    {
        public Int32 month = new Int32();
        public Int32 day = new Int32();
        public Int32 year = new Int32();

        public date()
        {
        }

        public date(Int32 m, Int32 d, Int32 y)
        {
            month = m;
            day = d;
            year = y;
        }

        public date(String timeblock)
        {
            month = Convert.ToInt32(timeblock.Substring(0, 2));
            day = Convert.ToInt32(timeblock.Substring(2, 2));
            year = Convert.ToInt32(timeblock.Substring(4, 4));
        }
        public override string ToString()
        {
            string monthString;
            string dayString;
            string yearString;

            switch (month)
            {
                case 1:
                    monthString = "January";
                    break;
                case 2:
                    monthString = "February";
                    break;
                case 3:
                    monthString = "March";
                    break;
                case 4:
                    monthString = "April";
                    break;
                case 5:
                    monthString = "May";
                    break;
                case 6:
                    monthString = "June";
                    break;
                case 7:
                    monthString = "July";
                    break;
                case 8:
                    monthString = "August";
                    break;
                case 9:
                    monthString = "September";
                    break;
                case 10:
                    monthString = "October";
                    break;
                case 11:
                    monthString = "November";
                    break;
                case 12:
                    monthString = "December";
                    break;
                default:
                    monthString = "";
                    break;
            }
            if (day != 0)
                dayString = day.ToString();
            else
                dayString = "";
            if (year != 0)
                yearString = year.ToString();
            else
                yearString = "";

            return yearString + " " + dayString + " " + monthString;
            
        }

        public string getTimeblock()
        {
            String timeblock = "";
            if (month < 10)
                timeblock += "0" + month;
            else
                timeblock += month;
            if (day < 10)
                timeblock += "0" + day;
            else
                timeblock += day;
            if (year == 0)
                timeblock += "0000";
            else
                timeblock += year;

            return timeblock;

        }

        public string BookString()
        {
            string monthString;
            string dayString;
            string yearString;

            switch (month)
            {
                case 1:
                    monthString = "January";
                    break;
                case 2:
                    monthString = "February";
                    break;
                case 3:
                    monthString = "March";
                    break;
                case 4:
                    monthString = "April";
                    break;
                case 5:
                    monthString = "May";
                    break;
                case 6:
                    monthString = "June";
                    break;
                case 7:
                    monthString = "July";
                    break;
                case 8:
                    monthString = "August";
                    break;
                case 9:
                    monthString = "September";
                    break;
                case 10:
                    monthString = "October";
                    break;
                case 11:
                    monthString = "November";
                    break;
                case 12:
                    monthString = "December";
                    break;
                default:
                    monthString = "";
                    break;
            }
            if (day != 0)
                dayString = day.ToString();
            else
                dayString = "";
            if (year != 0)
                yearString = year.ToString();
            else
                yearString = "";

            return monthString + " " + dayString + " " + yearString;

        }

        public bool isUndetermined()
        {
            return month == 0 && day == 0 && year == 0;
        }
    }
}
