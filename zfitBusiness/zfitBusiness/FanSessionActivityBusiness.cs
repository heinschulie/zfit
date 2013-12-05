using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    public class FanSessionActivityBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="FanSessionActivityCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanSessionActivityCollection">A <see cref="FanSessionActivityCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanSessionActivityCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, FanSessionActivityCollection aFanSessionActivityCollection)
        {
            if (aFanSessionActivityCollection == null)
            {
                throw new ArgumentNullException("Load FanSessionActivity Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanSessionActivity", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.List, "FanSessionActivity");
            //}

            FanSessionActivityData.Load(aFanSessionActivityCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="FanSessionActivity"/> object, with keys in <c>aFanSessionActivity</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanSessionActivity">A <see cref="FanSessionActivity"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanSessionActivity</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, FanSessionActivity aFanSessionActivity)
        {
            if (aFanSessionActivity == null)
            {
                throw new ArgumentNullException("Load FanSessionActivity Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanSessionActivity", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Read, "FanSessionActivity");
            }

            FanSessionActivityData.Load(aFanSessionActivity);
        }

        #endregion

        #region Save

        /// <summary>
        /// Save a <see cref="FanSessionActivity" /> list passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey" /> object.</param>
        /// <param name="aFanSessionActivityCollection">A cell fan collection.</param>
        /// <exception cref="Zephry.ZpAccessException">Access Denied; FanSessionActivity</exception>
        /// <exception cref="ArgumentNullException">If <c>aFanSessionActivity</c> argument is <c>null</c>.</exception>
        public static void Save(FanKey aFanKey, FanSessionActivityCollection aFanSessionActivityCollection)
        {
            if (aFanSessionActivityCollection == null)
            {
                throw new ArgumentNullException("Update FanSessionActivityCollection Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanSessionActivity", AccessMode.Update))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Update, "FanSessionActivity");
            //}

            FanSessionActivityData.Save(aFanSessionActivityCollection);
        }

        #endregion
    }
}
