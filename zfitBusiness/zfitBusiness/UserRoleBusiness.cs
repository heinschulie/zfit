using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   UserRoleBusiness class.
    /// </summary>
    public class UserRoleBusiness
    {
        #region UserRole Business For User

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="UserRoleCollection"/>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aUserRoleCollection">A <see cref="UserRoleCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aUserRoleCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, UserRoleCollection aUserRoleCollection)
        {
            if (aUserRoleCollection == null)
            {
                throw new ArgumentNullException("Load UserRole Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "UserRole", AccessMode.List))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.List, "UserRole");
            }

            UserRoleData.Load(aUserRoleCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="UserRole"/> object, with keys in <c>aUserRole</c>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aUserRole">A <see cref="UserRole"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aUserRole</c> is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, UserRole aUserRole)
        {
            if (aUserRole == null)
            {
                throw new ArgumentNullException("Load UserRole Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "UserRole", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Read, "UserRole");
            }

            UserRoleData.Load(aUserRole);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="UserRole"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>UserRole Key</i>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aUserRole">A <see cref="UserRole"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aUserRole</c> argument is <c>null</c>.</exception>
        public static void Insert(UserKey aUserKey, UserRole aUserRole)
        {
            if (aUserRole == null)
            {
                throw new ArgumentNullException("Insert UserRole Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "UserRole", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Create, "UserRole");
            }

            UserRoleData.Insert(aUserRole);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="UserRole"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aUserRole">A <see cref="UserRole"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aUserRole</c> argument is <c>null</c>.</exception>
        public static void Update(UserKey aUserKey, UserRole aUserRole)
        {
            if (aUserRole == null)
            {
                throw new ArgumentNullException("Update UserRole Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "UserRole", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Update, "UserRole");
            }

            UserRoleData.Update(aUserRole);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="UserRole"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aUserRole">A <see cref="UserRole"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aUserRole</c> argument is <c>null</c>.</exception>
        public static void Delete(UserKey aUserKey, UserRole aUserRole)
        {
            if (aUserRole == null)
            {
                throw new ArgumentNullException("Delete UserRole Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "UserRole", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Delete, "UserRole");
            }

            UserRoleData.Delete(aUserRole);
        }

        #endregion

        #endregion   
    }
}