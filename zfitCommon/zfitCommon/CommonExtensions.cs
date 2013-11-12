using System;
using System.Collections.Generic;
using System.Linq;

namespace Zephry
{
    /// <summary>
    /// CommonExtensions static class. Zephry's standard extension set, applied mainly to sealed classes and primitive types
    /// </summary>
    /// <remarks>
    /// namespace Zephry.
    /// </remarks>
    public static class CommonExtensions
    {
        #region SortFormatFull

        /// <summary>
        /// Returns the string representation of a DateTime in "yyyy-MM-dd hh:mm:ss" format
        /// </summary>
        /// <param name="aDateTime"></param>
        /// <returns>Formatted DateTime</returns>
        public static string SortFormatFull(this DateTime aDateTime)
        {
            return aDateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        #endregion

        #region SortFormatStartOfday

        /// <summary>
        /// Appends zero time to the truncated value of a date
        /// </summary>
        /// <param name="aDateTime">A date time.</param>
        /// <returns>A string representation of DateTime in "yyyy-MM-dd 00:00:00" format</returns>
        public static string SortFormatStartOfDay(this DateTime aDateTime)
        {
            return SortFormatFull(aDateTime.Date);
        }

        #endregion

        #region SortFormatEndOfDay

        /// <summary>
        /// Appends full time to the truncated value of a date
        /// </summary>
        /// <param name="aDateTime">A date time.</param>
        /// <returns>A string representation of DateTime in "yyyy-MM-dd 23:59:59" format</returns>
        public static string SortFormatEndOfDay(this DateTime aDateTime)
        {
            return SortFormatFull(aDateTime.Date.Add(new TimeSpan(23, 59, 59)));
        }

        #endregion

        #region SortFormatDate

        /// <summary>
        /// Returns the string representation of a DateTime in "yyyy-MM-dd" format
        /// </summary>
        /// <param name="aDateTime"></param>
        /// <returns></returns>
        public static string SortFormatDate(this DateTime aDateTime)
        {
            return aDateTime.ToString("yyyy-MM-dd");
        }

        #endregion

        #region CalendarPeriod

        /// <summary>
        /// Returns the integer representation of a DateTime in yyyyMM format (the Calendar Period)
        /// </summary>
        /// <param name="aDateTime"></param>
        /// <returns></returns>
        public static int CalendarPeriod(this DateTime aDateTime)
        {
            return (aDateTime.Year * 100) + (aDateTime.Month);
        }
        #endregion

        #region AddPeriod
        /// <summary>
        /// Returns an input integer in Period format (yyyyMM) + 1 month
        /// </summary>
        /// <param name="aPeriod">A period.</param>
        /// <returns>Incremented Period</returns>
        public static int AddPeriod(this int aPeriod)
        {
            int vYear = aPeriod / 100;
            int vMonth = aPeriod % 100;
            if (vMonth < 1 || vMonth > 12)
            {
                throw new Exception(String.Format("Integer \"{0}\" is not a valid Year/Month period in the format yyyyMM for AddMonth operations", vMonth));
            }
            vMonth++;
            if (vMonth > 12)
            {
                vYear++;
                vMonth = 1;
            }
            return (vYear * 100) + vMonth;
        }
        #endregion
        
        public static DateTime WeekStart(this DateTime aDateTime)
        {
            DateTime vDateTime = aDateTime.Subtract(TimeSpan.FromDays((int)aDateTime.DayOfWeek));
            return new DateTime(vDateTime.Year, vDateTime.Month, vDateTime.Day, 0, 0, 0, 0);
        }

        public static DateTime Weekend(this DateTime aDateTime)
        {
            DateTime vDateTime = WeekStart(aDateTime).AddDays(6);
            return new DateTime(vDateTime.Year, vDateTime.Month, vDateTime.Day, 23, 59, 59, 999);
        }

        public static DateTime MonthStart(this DateTime aDateTime)
        {
            return new DateTime(aDateTime.Year, aDateTime.Month, 1, 0, 0, 0, 0);
        }

        public static DateTime MonthEnd(this DateTime aDateTime)
        {
            return new DateTime(aDateTime.Year, aDateTime.Month, 1, 23, 59, 59, 999).AddMonths(1).AddDays(-1);
        }

        public static DateTime PlusDays(this DateTime aDateTime, int aDays)
        {
            return new DateTime(aDateTime.Year, aDateTime.Month, aDateTime.Day, 23, 59, 59, 999).AddDays(aDays);
        }
    }
}
