using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Zephry
{
    /// <summary>
    /// A static utility class with commonly used data, exchange, string, date and math methods
    /// </summary>
    public static class CommonUtils
    {
        #region Decimal ConvertByBase

        /// <summary>
        /// Returns a Target Exchange value based on the Exchange Rates of Source and Target values as related to a Base value
        /// </summary>
        /// <param name="aVolume">The number of Target values to use in the calculation</param>
        /// <param name="aValue">The Source value</param>
        /// <param name="aSourceIsOneBase">The Exchange rate of a Source value to a Base value (where Base value = 1)</param>
        /// <param name="aTargetIsOneBase">The Exchange rate of a Target value to a Base value (where Base value = 1)</param>
        /// <returns></returns>
        public static decimal ConvertByBase(int aVolume, decimal aValue, double aSourceIsOneBase, double aTargetIsOneBase)
        {
            double vWork = aVolume * (double)aValue * (aTargetIsOneBase / aSourceIsOneBase);
            return Convert.ToDecimal(Math.Round(vWork, 2));
        }

        #endregion

        #region <T> DbValueTo

        /// <summary>
        /// Return a C# object of type T from a DB object, or a default C# object of type T if the DB object is DBNull
        /// </summary>
        /// <typeparam name="T">The C# Type to test and return.</typeparam>
        /// <param name="aObject">A DB object to convert.</param>
        /// <param name="aValueIfNull">A C# object of type T if aObject is DBNull.</param>
        /// <returns>A C# object of type T.</returns>
        public static T DbValueTo<T>(object aObject, T aValueIfNull)
        {
            return (aObject != DBNull.Value) ? (T)aObject : aValueIfNull;
        }

        #endregion

        #region <T> CsValueTo

        /// <summary>
        /// Return a DB object of type T from a C# object, or a default DB object of type T if the C# object is null
        /// </summary>
        /// <typeparam name="T">The DB Type to test and return.</typeparam>
        /// <param name="aObject">A C# object to convert.</param>
        /// <param name="aValueIfNull">A DB object of type T if aObject is null.</param>
        /// <returns>A DB object of type T.</returns>
        public static T CsValueTo<T>(object aObject, T aValueIfNull)
        {
            return (aObject != null) ? (T)aObject : aValueIfNull;
        }

        #endregion

        #region String DateClause
        /// <summary>
        /// Returns an SQL Date clause given an operator and two dates.
        /// Probably belongs in common.
        /// </summary>
        /// <param name="aDateOperator">A date operator.</param>
        /// <param name="aDate1">A date1.</param>
        /// <param name="aDate2">A date2.</param>
        /// <returns></returns>
        public static string DateClause(DateOperator aDateOperator, DateTime aDate1, DateTime aDate2)
        {
            string vWork = null;
            switch (aDateOperator)
            {
                case DateOperator.LessThan:
                    vWork = String.Format("< '{0}'", aDate1.SortFormatStartOfDay());
                    break;
                case DateOperator.LessEqual:
                    vWork = String.Format("<= '{0}'", aDate1.SortFormatEndOfDay());
                    break;
                case DateOperator.GreaterThan:
                    vWork = String.Format("> '{0}'", aDate1.SortFormatEndOfDay());
                    break;
                case DateOperator.GreaterEqual:
                    vWork = String.Format(">= '{0}'", aDate1.SortFormatStartOfDay());
                    break;
                case DateOperator.Equal:
                    vWork = String.Format("between '{0}' and '{1}'", aDate1.SortFormatStartOfDay(), aDate1.SortFormatEndOfDay());
                    break;
                case DateOperator.Between:
                    vWork = String.Format("between '{0}' and '{1}'", aDate1.SortFormatStartOfDay(), aDate2.SortFormatEndOfDay());
                    break;
                default:
                    vWork = String.Format("between '{0}' and '{1}'", aDate1.SortFormatStartOfDay(), aDate1.SortFormatEndOfDay());
                    break;
            }
            return vWork;
        }
        #endregion

        #region Enum from String
        /// <summary>
        /// Parses a string value to an Enumerated ordinal of type T
        /// </summary>
        /// <typeparam name="T">The enum type</typeparam>
        /// <param name="value">The string value.</param>
        /// <returns></returns>
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        #endregion

        #region TransactionScope GetTransactionScope with Options
        /// <summary>
        /// Return a TransactionScope with the IsolationLevel option of aIsolationLevel
        /// </summary>
        /// <param name="aIsolationLevel">An isolation level.</param>
        /// <returns>a TransactionScope</returns>
        public static TransactionScope GetTransactionScope(IsolationLevel aIsolationLevel)
        {
            var transactionOptions = new TransactionOptions() { IsolationLevel = aIsolationLevel, Timeout = TransactionManager.MaximumTimeout };
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }
        #endregion
    }
}