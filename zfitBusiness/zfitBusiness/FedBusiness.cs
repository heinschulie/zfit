using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zfit
{
    public class FedBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="FedCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFedCollection">A <see cref="FedCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFedCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, FedCollection aFedCollection)
        {
            if (aFedCollection == null)
            {
                throw new ArgumentNullException("Load Fed Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Fed", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FednKey), AccessMode.List, "Fed");
            //}

            FedData.Load(aFedCollection);
        }

        #endregion


        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Fed"/> object, with keys in <c>aFed</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFed">A <see cref="Fed"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFed</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, Fed aFed)
        {
            if (aFed == null)
            {
                throw new ArgumentNullException("Load Fed Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Fed", AccessMode.Read))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FednKey), AccessMode.Read, "Fed");
            //}

            FedData.Load(aFed);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Fed"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>Fed Key</i>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFed">A <see cref="Fed"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFed</c> argument is <c>null</c>.</exception>
        public static void Insert(FanKey aFanKey, Fed aFed)
        {
            if (aFed == null)
            {
                throw new ArgumentNullException("Insert Fed Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Fed", AccessMode.Create))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Create, "Fed");
            //}

            FedData.Insert(aFed);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Fed"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFed">A <see cref="Fed"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFed</c> argument is <c>null</c>.</exception>
        public static void Update(FanKey aFanKey, Fed aFed)
        {
            if (aFed == null)
            {
                throw new ArgumentNullException("Update Fed Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Fed", AccessMode.Update))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FednKey), AccessMode.Update, "Fed");
            //}

            FedData.Update(aFed);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Fed"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFed">A <see cref="Fed"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFed</c> argument is <c>null</c>.</exception>
        public static void Delete(FanKey aFanKey, Fed aFed)
        {
            if (aFed == null)
            {
                throw new ArgumentNullException("Delete Fed Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Fed", AccessMode.Delete))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FednKey), AccessMode.Delete, "Fed");
            //}

            FedData.Delete(aFed);
        }

        #endregion
    }
}
