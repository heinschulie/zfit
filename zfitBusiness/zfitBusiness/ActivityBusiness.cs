using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    public class ActivityBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="ActivityCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aActivityCollection">A <see cref="ActivityCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aActivityCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, ActivityCollection aActivityCollection)
        {
            if (aActivityCollection == null)
            {
                throw new ArgumentNullException("Load Activity Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Activity", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.ActivitynKey), AccessMode.List, "Activity");
            //}

            ActivityData.Load(aActivityCollection);
        }

        #endregion


        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Activity"/> object, with keys in <c>aActivity</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aActivity">A <see cref="Activity"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aActivity</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, Activity aActivity)
        {
            if (aActivity == null)
            {
                throw new ArgumentNullException("Load Activity Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Activity", AccessMode.Read))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.ActivitynKey), AccessMode.Read, "Activity");
            //}

            ActivityData.Load(aActivity);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Activity"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>Activity Key</i>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aActivity">A <see cref="Activity"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aActivity</c> argument is <c>null</c>.</exception>
        public static void Insert(FanKey aFanKey, Activity aActivity)
        {
            if (aActivity == null)
            {
                throw new ArgumentNullException("Insert Activity Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Activity", AccessMode.Create))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Create, "Activity");
            //}

            ActivityData.Insert(aActivity);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Activity"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aActivity">A <see cref="Activity"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aActivity</c> argument is <c>null</c>.</exception>
        public static void Update(FanKey aFanKey, Activity aActivity)
        {
            if (aActivity == null)
            {
                throw new ArgumentNullException("Update Activity Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Activity", AccessMode.Update))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.ActivitynKey), AccessMode.Update, "Activity");
            //}

            ActivityData.Update(aActivity);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Activity"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aActivity">A <see cref="Activity"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aActivity</c> argument is <c>null</c>.</exception>
        public static void Delete(FanKey aFanKey, Activity aActivity)
        {
            if (aActivity == null)
            {
                throw new ArgumentNullException("Delete Activity Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Activity", AccessMode.Delete))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.ActivitynKey), AccessMode.Delete, "Activity");
            //}

            ActivityData.Delete(aActivity);
        }

        #endregion
    }
}
