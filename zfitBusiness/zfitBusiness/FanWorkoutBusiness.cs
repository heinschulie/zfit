using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    public class FanWorkoutBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="FanWorkoutCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanWorkoutCollection">A <see cref="FanWorkoutCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanWorkoutCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, FanWorkoutCollection aFanWorkoutCollection)
        {
            if (aFanWorkoutCollection == null)
            {
                throw new ArgumentNullException("Load FanWorkout Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanWorkout", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.List, "FanWorkout");
            //}

            FanWorkoutData.Load(aFanWorkoutCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="FanWorkout"/> object, with keys in <c>aFanWorkout</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFanWorkout">A <see cref="FanWorkout"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanWorkout</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, FanWorkout aFanWorkout)
        {
            if (aFanWorkout == null)
            {
                throw new ArgumentNullException("Load FanWorkout Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanWorkout", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Read, "FanWorkout");
            }

            FanWorkoutData.Load(aFanWorkout);
        }

        #endregion

        #region Save

        /// <summary>
        /// Save a <see cref="FanWorkout" /> list passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey" /> object.</param>
        /// <param name="aFanWorkoutCollection">A cell fan collection.</param>
        /// <exception cref="Zephry.ZpAccessException">Access Denied; FanWorkout</exception>
        /// <exception cref="ArgumentNullException">If <c>aFanWorkout</c> argument is <c>null</c>.</exception>
        public static void Save(FanKey aFanKey, FanWorkoutCollection aFanWorkoutCollection)
        {
            if (aFanWorkoutCollection == null)
            {
                throw new ArgumentNullException("Update FanWorkoutCollection Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "FanWorkout", AccessMode.Update))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Update, "FanWorkout");
            //}

            //Set Dates of new fanworkouts
            DateTime x;
            foreach (FanWorkout aFw in aFanWorkoutCollection.FanWorkoutList)
            {
                if (!(DateTime.TryParse(aFw.FanWorkoutDateCreated, out x)))
                {
                    aFw.FanWorkoutDateCreated = DateTime.Now.ToLongDateString(); ;
                }
            }

            FanWorkoutData.Save(aFanWorkoutCollection);
        }

        #endregion
    }
}
