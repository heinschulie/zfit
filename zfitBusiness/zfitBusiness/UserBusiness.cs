using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   UserBusiness class.
    /// </summary>
    public class UserBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="UserCollection"/>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aUserCollection">A <see cref="UserCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aUserCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, UserCollection aUserCollection)
        {
            if (aUserCollection == null)
            {
                throw new ArgumentNullException("Load User Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "User", AccessMode.List))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.List, "User");
            }

            UserData.Load(aUserCollection);
        }

        #endregion

        #region Load by ID

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="User"/> object specified by a UserID.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aUser">A <see cref="User"/> object.</param>
        /// <param name="aUserID">A UserID <see cref="string"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aUser</c> argument is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">If <c>aUserID</c> argument is <c>null</c>, empty or whitespace.</exception>
        public static void LoadByID (UserKey aUserKey, User aUser)
        {
            if (aUser == null)
            {
                throw new ArgumentNullException("LoadByID User Business");
            }
            if (String.IsNullOrWhiteSpace(aUser.UsrID))
            {
                throw new ArgumentNullException("Empty ID in LoadByID User Business");
            }

            //if (!UserFunctionAccessData.HasModeAccess(aUserKey, "User", AccessMode.Read))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Read, "User");
            //}

            UserData.LoadById(aUser); 
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="User"/> object, with keys in <c>aUser</c>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aUser">A <see cref="User"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aUser</c> is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, User aUser)
        {
            if (aUser == null)
            {
                throw new ArgumentNullException("Load User Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "User", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Read, "User");
            }

            UserData.Load(aUser);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="User"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>User Key</i>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aUser">A <see cref="User"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aUser</c> argument is <c>null</c>.</exception>
        public static void Insert(UserKey aUserKey, User aUser)
        {
            if (aUser == null)
            {
                throw new ArgumentNullException("Insert User Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "User", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Create, "User");
            }

            UserData.Insert(aUser);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="User"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aUser">A <see cref="User"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aUser</c> argument is <c>null</c>.</exception>
        public static void Update(UserKey aUserKey, User aUser)
        {
            if (aUser == null)
            {
                throw new ArgumentNullException("Update User Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "User", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Update, "User");
            }

            UserData.Update(aUser);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="User"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aUser">A <see cref="User"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aUser</c> argument is <c>null</c>.</exception>
        public static void Delete(UserKey aUserKey, User aUser)
        {
            if (aUser == null)
            {
                throw new ArgumentNullException("Delete User Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "User", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Delete, "User");
            }

            UserData.Delete(aUser);
        }

        #endregion
    }
}