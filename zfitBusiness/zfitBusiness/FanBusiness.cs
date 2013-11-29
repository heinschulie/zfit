using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   FanBusiness class.
    /// </summary>
    public class FanBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="FanCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanCollection">A <see cref="FanCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, FanCollection aFanCollection)
        {
            if (aFanCollection == null)
            {
                throw new ArgumentNullException("Load Fan Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Fan", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.List, "Fan");
            //}

            FanData.Load(aFanCollection);
        }

        #endregion

        #region Load by ID

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="Fan"/> object specified by a FanID.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFan">A <see cref="Fan"/> object.</param>
        /// <param name="aFanID">A FanID <see cref="string"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFan</c> argument is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">If <c>aFanID</c> argument is <c>null</c>, empty or whitespace.</exception>
        public static void LoadByID (FanKey aFanKey, Fan aFan)
        {
            if (aFan == null)
            {
                throw new ArgumentNullException("LoadByID Fan Business");
            }
            if (String.IsNullOrWhiteSpace(aFan.FanUserID))
            {
                throw new ArgumentNullException("Empty ID in LoadByID Fan Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Fan", AccessMode.Read))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Read, "Fan");
            //}

            FanData.LoadById(aFan); 
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Fan"/> object, with keys in <c>aFan</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFan">A <see cref="Fan"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFan</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, Fan aFan)
        {
            if (aFan == null)
            {
                throw new ArgumentNullException("Load Fan Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Fanatic", AccessMode.Read))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Read, "Fan");
            //}

            FanData.Load(aFan);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Fan"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>Fan Key</i>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFan">A <see cref="Fan"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFan</c> argument is <c>null</c>.</exception>
        public static void Insert(FanKey aFanKey, Fan aFan)
        {
            if (aFan == null)
            {
                throw new ArgumentNullException("Insert Fan Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Fanatic", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Create, "Fan");
            }

            FanData.Insert(aFan);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Fan"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFan">A <see cref="Fan"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFan</c> argument is <c>null</c>.</exception>
        public static void Update(FanKey aFanKey, Fan aFan)
        {
            if (aFan == null)
            {
                throw new ArgumentNullException("Update Fan Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Fanatic", AccessMode.Update))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Update, "Fan");
            //}

            FanData.Update(aFan);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Fan"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFan">A <see cref="Fan"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFan</c> argument is <c>null</c>.</exception>
        public static void Delete(FanKey aFanKey, Fan aFan)
        {
            if (aFan == null)
            {
                throw new ArgumentNullException("Delete Fan Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Fanatic", AccessMode.Delete))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Delete, "Fan");
            //}

            FanData.Delete(aFan);
        }

        #endregion
    }
}