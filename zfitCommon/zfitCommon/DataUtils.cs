using System;
using System.Collections.Generic;
using System.Linq;

namespace Zephry
{
    /// <summary>
    ///   CastDBNull static class.
    /// </summary>
    /// <remarks>
    ///   namepspace Zephry.
    /// </remarks>
    public static class CastDBNull
    {
        #region Methods

        /// <summary>
        ///   Returns a default value if a specified object is <c>DBNull</c>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aObject">An object.</param>
        /// <param name="aValueIfNull">A value if null.</param>
        /// <returns></returns>
        public static T To<T>(object aObject, T aValueIfNull)
        {
            return (aObject != DBNull.Value) ? (T)aObject : aValueIfNull;
        }

        #endregion
    }

    /// <summary>
    ///   CastCSNull static class.
    /// </summary>
    /// <remarks>
    ///   namepspace Zephry.
    /// </remarks>
    public static class CastCSNull
    {
        #region Methods

        /// <summary>
        ///   Returns a default value if  a specified object is <c>null</c>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aObject">An object.</param>
        /// <param name="aValueIfNull">A value if null.</param>
        /// <returns></returns>
        public static T To<T>(object aObject, T aValueIfNull)
        {
            return (aObject != null) ? (T)aObject : aValueIfNull;
        }

        #endregion
    }
}
