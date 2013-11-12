using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   FunctionBusiness class.
    /// </summary>
    public class FunctionBusiness
    {
        #region Function Business For Fan

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="FunctionCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFunctionCollection">A <see cref="FunctionCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFunctionCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, FunctionCollection aFunctionCollection)
        {
            if (aFunctionCollection == null)
            {
                throw new ArgumentNullException("Load Function Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Function", AccessMode.List))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.List, "Function");
            }

            FunctionData.Load(aFunctionCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Function"/> object, with keys in <c>aFunction</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFunction">A <see cref="Function"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFunction</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, Function aFunction)
        {
            if (aFunction == null)
            {
                throw new ArgumentNullException("Load Function Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Function", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Read, "Function");
            }

            FunctionData.Load(aFunction);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Function"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>Function Key</i>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFunction">A <see cref="Function"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFunction</c> argument is <c>null</c>.</exception>
        public static void Insert(FanKey aFanKey, Function aFunction)
        {
            if (aFunction == null)
            {
                throw new ArgumentNullException("Insert Function Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Function", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Create, "Function");
            }

            FunctionData.Insert(aFunction);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Function"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFunction">A <see cref="Function"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFunction</c> argument is <c>null</c>.</exception>
        public static void Update(FanKey aFanKey, Function aFunction)
        {
            if (aFunction == null)
            {
                throw new ArgumentNullException("Update Function Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Function", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Update, "Function");
            }

            FunctionData.Update(aFunction);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Function"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFunction">A <see cref="Function"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFunction</c> argument is <c>null</c>.</exception>
        public static void Delete(FanKey aFanKey, Function aFunction)
        {
            if (aFunction == null)
            {
                throw new ArgumentNullException("Delete Function Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Function", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Delete, "Function");
            }

            FunctionData.Delete(aFunction);
        }

        #endregion

        #endregion

        #region Function Business For User

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="FunctionCollection"/>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aFunctionCollection">A <see cref="FunctionCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFunctionCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, FunctionCollection aFunctionCollection)
        {
            if (aFunctionCollection == null)
            {
                throw new ArgumentNullException("Load Function Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Function", AccessMode.List))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.List, "Function");
            }

            FunctionData.Load(aFunctionCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Function"/> object, with keys in <c>aFunction</c>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aFunction">A <see cref="Function"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFunction</c> is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, Function aFunction)
        {
            if (aFunction == null)
            {
                throw new ArgumentNullException("Load Function Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Function", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Read, "Function");
            }

            FunctionData.Load(aFunction);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Function"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>Function Key</i>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aFunction">A <see cref="Function"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFunction</c> argument is <c>null</c>.</exception>
        public static void Insert(UserKey aUserKey, Function aFunction)
        {
            if (aFunction == null)
            {
                throw new ArgumentNullException("Insert Function Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Function", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Create, "Function");
            }

            FunctionData.Insert(aFunction);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Function"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aFunction">A <see cref="Function"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFunction</c> argument is <c>null</c>.</exception>
        public static void Update(UserKey aUserKey, Function aFunction)
        {
            if (aFunction == null)
            {
                throw new ArgumentNullException("Update Function Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Function", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Update, "Function");
            }

            FunctionData.Update(aFunction);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Function"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aFunction">A <see cref="Function"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFunction</c> argument is <c>null</c>.</exception>
        public static void Delete(UserKey aUserKey, Function aFunction)
        {
            if (aFunction == null)
            {
                throw new ArgumentNullException("Delete Function Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Function", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Delete, "Function");
            }

            FunctionData.Delete(aFunction);
        }

        #endregion

        #endregion
    }
}