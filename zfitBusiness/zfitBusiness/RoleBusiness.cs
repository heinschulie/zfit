using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   RoleBusiness class.
    /// </summary>
    public class RoleBusiness
    {
        #region Role Business For Fan

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="RoleCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aRoleCollection">A <see cref="RoleCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRoleCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, RoleCollection aRoleCollection)
        {
            if (aRoleCollection == null)
            {
                throw new ArgumentNullException("Load Role Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Role", AccessMode.List))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.List, "Role");
            }

            RoleData.Load(aRoleCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Role"/> object, with keys in <c>aRole</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aRole">A <see cref="Role"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aRole</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, Role aRole)
        {
            if (aRole == null)
            {
                throw new ArgumentNullException("Load Role Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Role", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Read, "Role");
            }

            RoleData.Load(aRole);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Role"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>Role Key</i>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aRole">A <see cref="Role"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRole</c> argument is <c>null</c>.</exception>
        public static void Insert(FanKey aFanKey, Role aRole)
        {
            if (aRole == null)
            {
                throw new ArgumentNullException("Insert Role Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Role", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Create, "Role");
            }

            RoleData.Insert(aRole);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Role"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aRole">A <see cref="Role"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRole</c> argument is <c>null</c>.</exception>
        public static void Update(FanKey aFanKey, Role aRole)
        {
            if (aRole == null)
            {
                throw new ArgumentNullException("Update Role Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Role", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Update, "Role");
            }

            RoleData.Update(aRole);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Role"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aRole">A <see cref="Role"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRole</c> argument is <c>null</c>.</exception>
        public static void Delete(FanKey aFanKey, Role aRole)
        {
            if (aRole == null)
            {
                throw new ArgumentNullException("Delete Role Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Role", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Delete, "Role");
            }

            RoleData.Delete(aRole);
        }

        #endregion

        #endregion

        #region Role Business For User

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="RoleCollection"/>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aRoleCollection">A <see cref="RoleCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRoleCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, RoleCollection aRoleCollection)
        {
            if (aRoleCollection == null)
            {
                throw new ArgumentNullException("Load Role Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Role", AccessMode.List))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.List, "Role");
            }

            RoleData.Load(aRoleCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Role"/> object, with keys in <c>aRole</c>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aRole">A <see cref="Role"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aRole</c> is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, Role aRole)
        {
            if (aRole == null)
            {
                throw new ArgumentNullException("Load Role Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Role", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Read, "Role");
            }

            RoleData.Load(aRole);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Role"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>Role Key</i>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aRole">A <see cref="Role"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRole</c> argument is <c>null</c>.</exception>
        public static void Insert(UserKey aUserKey, Role aRole)
        {
            if (aRole == null)
            {
                throw new ArgumentNullException("Insert Role Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Role", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Create, "Role");
            }

            RoleData.Insert(aRole);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Role"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aRole">A <see cref="Role"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRole</c> argument is <c>null</c>.</exception>
        public static void Update(UserKey aUserKey, Role aRole)
        {
            if (aRole == null)
            {
                throw new ArgumentNullException("Update Role Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Role", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Update, "Role");
            }

            RoleData.Update(aRole);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Role"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aRole">A <see cref="Role"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRole</c> argument is <c>null</c>.</exception>
        public static void Delete(UserKey aUserKey, Role aRole)
        {
            if (aRole == null)
            {
                throw new ArgumentNullException("Delete Role Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Role", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Delete, "Role");
            }

            RoleData.Delete(aRole);
        }

        #endregion

        #endregion
    }
}