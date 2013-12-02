using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    public class FanFedBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="FanFedCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanFedCollection">A <see cref="FanFedCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanFedCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, FanFedCollection aFanFedCollection)
        {
            if (aFanFedCollection == null)
            {
                throw new ArgumentNullException("Load FanFed Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanFed", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.List, "FanFed");
            //}

            FanFedData.Load(aFanFedCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="FanFed"/> object, with keys in <c>aFanFed</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanFed">A <see cref="FanFed"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanFed</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, FanFed aFanFed)
        {
            if (aFanFed == null)
            {
                throw new ArgumentNullException("Load FanFed Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanFed", AccessMode.Read))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Read, "FanFed");
            //}

            FanFedData.Load(aFanFed);
        }

        #endregion

        #region Save

        /// <summary>
        /// Save a <see cref="FanFed" /> list passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey" /> object.</param>
        /// <param name="aFanFedCollection">A fan fed collection.</param>
        /// <exception cref="Zephry.ZpAccessException">Access Denied; FanFed</exception>
        /// <exception cref="ArgumentNullException">If <c>aFanFed</c> argument is <c>null</c>.</exception>
        public static void Save(FanKey aFanKey, FanFedCollection aFanFedCollection)
        {
            if (aFanFedCollection == null)
            {
                throw new ArgumentNullException("Update FanFedCollection Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanFed", AccessMode.Update))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Update, "FanFed");
            //}

            FanFedData.Save(aFanFedCollection);
        }

        #endregion
    }
}
