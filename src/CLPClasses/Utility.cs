using System;
using System.Globalization;

namespace CLPClasses
{
    public static class Utility
    {
        public static DateTime ParseBDate(string b)
        {
            var bee = new DateTime();
            var splitArray = new char[] {'+', '-'};
            if (b.ToLower().Contains("datetime.now"))
            {
                b = b.ToLower().Replace("datetime.now", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                var timeDatePart = b.Split(splitArray);
                bee = DateTime.Parse(timeDatePart[0].Trim());
            }
            else if (b.ToLower().Contains("getdate()"))
            {
                b = b.ToLower().Replace("getdate()",
                    DateTime.Now.Date.ToString(CultureInfo.InvariantCulture).Replace("00:00:00", ""));
                var timeDatePart = b.Split(splitArray);
                bee = DateTime.Parse(timeDatePart[0].Trim());
            }
            else if (b.ToLower().Contains("today@ "))
            {
                b = b.ToLower().Replace("today@ ",
                    DateTime.Now.Date.ToString(CultureInfo.InvariantCulture).Replace("00:00:00", ""));
                var timeDatePart = b.Split(splitArray);
                bee = DateTime.Parse(timeDatePart[0].Trim());
            }
            else if (b.ToLower().Contains("today"))
            {
                b = b.ToLower().Replace("today",
                    DateTime.Now.Date.ToString(CultureInfo.InvariantCulture).Replace("00:00:00", ""));
                var timeDatePart = b.Split(splitArray);
                bee = DateTime.Parse(timeDatePart[0].Trim());
            }
            else
            {
                var timeDatePart = b.Split(splitArray);
                bee = DateTime.Parse(timeDatePart[0].Trim());
            }

            if (b.ToLower().Contains("+"))
            {
                var plusDays = b.Split('+');
                if (plusDays.Length == 2)
                    bee = bee.AddDays(Convert.ToDouble(plusDays[1].Trim()));
            }

            if (b.ToLower().Contains("-"))
            {
                var minusDays = b.Split('-');
                if (minusDays.Length == 2)
                    bee = bee.AddDays(Convert.ToDouble(0 - Convert.ToInt32(minusDays[1].Trim())));
            }

            return bee;
        }
    }
}