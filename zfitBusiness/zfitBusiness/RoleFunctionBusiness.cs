using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   RoleFunctionBusiness class.
    /// </summary>
    public class RoleFunctionBusiness
    {
        #region RoleFunction Business For Fan

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="RoleFunctionCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aRoleFunctionCollection">A <see cref="RoleFunctionCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRoleFunctionCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, RoleFunctionCollection aRoleFunctionCollection)
        {
            if (aRoleFunctionCollection == null)
            {
                throw new ArgumentNullException("Load RoleFunction Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "RoleFunction", AccessMode.List))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.List, "RoleFunction");
            }

            RoleFunctionData.Load(aRoleFunctionCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="RoleFunction"/> object, with keys in <c>aRoleFunction</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aRoleFunction">A <see cref="RoleFunction"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aRoleFunction</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, RoleFunction aRoleFunction)
        {
            if (aRoleFunction == null)
            {
                throw new ArgumentNullException("Load RoleFunction Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "RoleFunction", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Read, "RoleFunction");
            }

            RoleFunctionData.Load(aRoleFunction);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="RoleFunction"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>RoleFunction Key</i>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aRoleFunction">A <see cref="RoleFunction"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRoleFunction</c> argument is <c>null</c>.</exception>
        public static void Insert(FanKey aFanKey, RoleFunction aRoleFunction)
        {
            if (aRoleFunction == null)
            {
                throw new ArgumentNullException("Insert RoleFunction Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "RoleFunction", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Create, "RoleFunction");
            }

            RoleFunctionData.Insert(aRoleFunction);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="RoleFunction"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aRoleFunction">A <see cref="RoleFunction"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRoleFunction</c> argument is <c>null</c>.</exception>
        public static void Update(FanKey aFanKey, RoleFunction aRoleFunction)
        {
            if (aRoleFunction == null)
            {
                throw new ArgumentNullException("Update RoleFunction Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "RoleFunction", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Update, "RoleFunction");
            }

            RoleFunctionData.Update(aRoleFunction);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="RoleFunction"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aRoleFunction">A <see cref="RoleFunction"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRoleFunction</c> argument is <c>null</c>.</exception>
        public static void Delete(FanKey aFanKey, RoleFunction aRoleFunction)
        {
            if (aRoleFunction == null)
            {
                throw new ArgumentNullException("Delete RoleFunction Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "RoleFunction", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Delete, "RoleFunction");
            }

            RoleFunctionData.Delete(aRoleFunction);
        }

        #endregion

        #endregion

        #region RoleFunction Business For User


        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="RoleFunctionCollection"/>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aRoleFunctionCollection">A <see cref="RoleFunctionCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRoleFunctionCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, RoleFunctionCollection aRoleFunctionCollection)
        {
            if (aRoleFunctionCollection == null)
            {
                throw new ArgumentNullException("Load RoleFunction Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "RoleFunction", AccessMode.List))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.List, "RoleFunction");
            }

            RoleFunctionData.Load(aRoleFunctionCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="RoleFunction"/> object, with keys in <c>aRoleFunction</c>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aRoleFunction">A <see cref="RoleFunction"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aRoleFunction</c> is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, RoleFunction aRoleFunction)
        {
            if (aRoleFunction == null)
            {
                throw new ArgumentNullException("Load RoleFunction Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "RoleFunction", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Read, "RoleFunction");
            }

            RoleFunctionData.Load(aRoleFunction);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="RoleFunction"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>RoleFunction Key</i>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aRoleFunction">A <see cref="RoleFunction"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRoleFunction</c> argument is <c>null</c>.</exception>
        public static void Insert(UserKey aUserKey, RoleFunction aRoleFunction)
        {
            if (aRoleFunction == null)
            {
                throw new ArgumentNullException("Insert RoleFunction Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "RoleFunction", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Create, "RoleFunction");
            }

            RoleFunctionData.Insert(aRoleFunction);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="RoleFunction"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aRoleFunction">A <see cref="RoleFunction"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRoleFunction</c> argument is <c>null</c>.</exception>
        public static void Update(UserKey aUserKey, RoleFunction aRoleFunction)
        {
            if (aRoleFunction == null)
            {
                throw new ArgumentNullException("Update RoleFunction Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "RoleFunction", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Update, "RoleFunction");
            }

            RoleFunctionData.Update(aRoleFunction);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="RoleFunction"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aRoleFunction">A <see cref="RoleFunction"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aRoleFunction</c> argument is <c>null</c>.</exception>
        public static void Delete(UserKey aUserKey, RoleFunction aRoleFunction)
        {
            if (aRoleFunction == null)
            {
                throw new ArgumentNullException("Delete RoleFunction Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "RoleFunction", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Delete, "RoleFunction");
            }

            RoleFunctionData.Delete(aRoleFunction);
        }

        #endregion

        #endregion
    }
}