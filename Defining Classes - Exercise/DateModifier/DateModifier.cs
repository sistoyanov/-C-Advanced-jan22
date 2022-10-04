using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;

namespace DateModifier
{
    public static class DateModifier
    {
        public static string StarDate { get; set; }
        public static string EndDate { get; set; }

        public static int CalculateDifference(string startDateString, string endDateStirng)
        {
            DateTime startDate = DateTime.Parse(startDateString);
            DateTime endDate = DateTime.Parse(endDateStirng);

            TimeSpan timeSpan = endDate - startDate;
      
            return Math.Abs(timeSpan.Days);
        }
    }
}
