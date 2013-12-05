using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    public class FanSessionBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="FanSessionCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanSessionCollection">A <see cref="FanSessionCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanSessionCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, FanSessionCollection aFanSessionCollection)
        {
            if (aFanSessionCollection == null)
            {
                throw new ArgumentNullException("Load FanSession Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanSession", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.List, "FanSession");
            //}

            FanSessionData.Load(aFanSessionCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="FanSession"/> object, with keys in <c>aFanSession</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanSession">A <see cref="FanSession"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanSession</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, FanSession aFanSession)
        {
            if (aFanSession == null)
            {
                throw new ArgumentNullException("Load FanSession Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanSession", AccessMode.Read))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Read, "FanSession");
            //}

            FanSessionData.Load(aFanSession);
        }

        #endregion

        #region Save

        /// <summary>
        /// Save a <see cref="FanSession" /> list passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey" /> object.</param>
        /// <param name="aFanSessionCollection">A cell fan collection.</param>
        /// <exception cref="Zephry.ZpAccessException">Access Denied; FanSession</exception>
        /// <exception cref="ArgumentNullException">If <c>aFanSession</c> argument is <c>null</c>.</exception>
        public static void Save(FanKey aFanKey, FanSessionCollection aFanSessionCollection)
        {
            if (aFanSessionCollection == null)
            {
                throw new ArgumentNullException("Update FanSessionCollection Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanSession", AccessMode.Update))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Update, "FanSession");
            //}

            //Set Dates of new fanworkouts
            DateTime x;
            foreach (FanSession aFw in aFanSessionCollection.FanSessionList)
            {
                if (!(DateTime.TryParse(aFw.FanSessionDateDone, out x)))
                {
                    aFw.FanSessionDateDone = DateTime.Now.ToLongDateString(); ;
                }
            }
            FanSessionData.Save(aFanSessionCollection);
        }

        #endregion


        #region Insert

        /// <summary>
        ///   Insert a <see cref="FanSession"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>FanSession Key</i>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanSession">A <see cref="FanSession"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanSession</c> argument is <c>null</c>.</exception>
        public static void Insert(FanKey aFanKey, FanSession aFanSession)
        {
            if (aFanSession == null)
            {
                throw new ArgumentNullException("Insert FanSession Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanSession", AccessMode.Create))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Create, "FanSession");
            //}
            aFanSession.FanSessionDateDone = DateTime.Now.ToLongDateString();
            FanSessionData.Insert(aFanSession);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="FanSession"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanSession">A <see cref="FanSession"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanSession</c> argument is <c>null</c>.</exception>
        public static void Update(FanKey aFanKey, FanSession aFanSession)
        {
            if (aFanSession == null)
            {
                throw new ArgumentNullException("Update FanSession Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanSession", AccessMode.Update))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FanSessionnKey), AccessMode.Update, "FanSession");
            //}

            FanSessionData.Update(aFanSession);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="FanSession"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanSession">A <see cref="FanSession"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanSession</c> argument is <c>null</c>.</exception>
        public static void Delete(FanKey aFanKey, FanSession aFanSession)
        {
            if (aFanSession == null)
            {
                throw new ArgumentNullException("Delete FanSession Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanSession", AccessMode.Delete))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FanSessionnKey), AccessMode.Delete, "FanSession");
            //}

            FanSessionData.Delete(aFanSession);
        }

        #endregion
    }
}
