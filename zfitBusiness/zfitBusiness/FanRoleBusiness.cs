using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   FanRoleBusiness class.
    /// </summary>
    public class FanRoleBusiness
    {
        #region FanRole Business for Fan

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="FanRoleCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanRoleCollection">A <see cref="FanRoleCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanRoleCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, FanRoleCollection aFanRoleCollection)
        {
            if (aFanRoleCollection == null)
            {
                throw new ArgumentNullException("Load FanRole Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanRole", AccessMode.List))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.List, "FanRole");
            }

            FanRoleData.Load(aFanRoleCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="FanRole"/> object, with keys in <c>aFanRole</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanRole">A <see cref="FanRole"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanRole</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, FanRole aFanRole)
        {
            if (aFanRole == null)
            {
                throw new ArgumentNullException("Load FanRole Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanRole", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Read, "FanRole");
            }

            FanRoleData.Load(aFanRole);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="FanRole"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>FanRole Key</i>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanRole">A <see cref="FanRole"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanRole</c> argument is <c>null</c>.</exception>
        public static void Insert(FanKey aFanKey, FanRole aFanRole)
        {
            if (aFanRole == null)
            {
                throw new ArgumentNullException("Insert FanRole Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanRole", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Create, "FanRole");
            }

            FanRoleData.Insert(aFanRole);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="FanRole"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanRole">A <see cref="FanRole"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanRole</c> argument is <c>null</c>.</exception>
        public static void Update(FanKey aFanKey, FanRole aFanRole)
        {
            if (aFanRole == null)
            {
                throw new ArgumentNullException("Update FanRole Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanRole", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Update, "FanRole");
            }

            FanRoleData.Update(aFanRole);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="FanRole"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanRole">A <see cref="FanRole"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanRole</c> argument is <c>null</c>.</exception>
        public static void Delete(FanKey aFanKey, FanRole aFanRole)
        {
            if (aFanRole == null)
            {
                throw new ArgumentNullException("Delete FanRole Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanRole", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Delete, "FanRole");
            }

            FanRoleData.Delete(aFanRole);
        }

        #endregion

        #endregion

        #region FanRole Business for User

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="FanRoleCollection"/>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aFanRoleCollection">A <see cref="FanRoleCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanRoleCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, FanRoleCollection aFanRoleCollection)
        {
            if (aFanRoleCollection == null)
            {
                throw new ArgumentNullException("Load FanRole Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "FanRole", AccessMode.List))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.List, "FanRole");
            }

            FanRoleData.Load(aFanRoleCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="FanRole"/> object, with keys in <c>aFanRole</c>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aFanRole">A <see cref="FanRole"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanRole</c> is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, FanRole aFanRole)
        {
            if (aFanRole == null)
            {
                throw new ArgumentNullException("Load FanRole Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "FanRole", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Read, "FanRole");
            }

            FanRoleData.Load(aFanRole);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="FanRole"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>FanRole Key</i>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aFanRole">A <see cref="FanRole"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanRole</c> argument is <c>null</c>.</exception>
        public static void Insert(UserKey aUserKey, FanRole aFanRole)
        {
            if (aFanRole == null)
            {
                throw new ArgumentNullException("Insert FanRole Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "FanRole", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Create, "FanRole");
            }

            FanRoleData.Insert(aFanRole);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="FanRole"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aFanRole">A <see cref="FanRole"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanRole</c> argument is <c>null</c>.</exception>
        public static void Update(UserKey aUserKey, FanRole aFanRole)
        {
            if (aFanRole == null)
            {
                throw new ArgumentNullException("Update FanRole Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "FanRole", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Update, "FanRole");
            }

            FanRoleData.Update(aFanRole);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="FanRole"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aFanRole">A <see cref="FanRole"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanRole</c> argument is <c>null</c>.</exception>
        public static void Delete(UserKey aUserKey, FanRole aFanRole)
        {
            if (aFanRole == null)
            {
                throw new ArgumentNullException("Delete FanRole Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "FanRole", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Delete, "FanRole");
            }

            FanRoleData.Delete(aFanRole);
        }

        #endregion

        #endregion
    }
}