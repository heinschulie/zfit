using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    public class WorkoutBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="WorkoutCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aWorkoutCollection">A <see cref="WorkoutCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkoutCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, WorkoutCollection aWorkoutCollection)
        {
            if (aWorkoutCollection == null)
            {
                throw new ArgumentNullException("Load Workout Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Workout", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.WorkoutnKey), AccessMode.List, "Workout");
            //}

            WorkoutData.Load(aWorkoutCollection);
        }

        #endregion


        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Workout"/> object, with keys in <c>aWorkout</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aWorkout">A <see cref="Workout"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkout</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, Workout aWorkout)
        {
            if (aWorkout == null)
            {
                throw new ArgumentNullException("Load Workout Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Workout", AccessMode.Read))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.WorkoutnKey), AccessMode.Read, "Workout");
            //}

            WorkoutData.Load(aWorkout);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Workout"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>Workout Key</i>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aWorkout">A <see cref="Workout"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkout</c> argument is <c>null</c>.</exception>
        public static void Insert(FanKey aFanKey, Workout aWorkout)
        {
            if (aWorkout == null)
            {
                throw new ArgumentNullException("Insert Workout Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Workout", AccessMode.Create))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Create, "Workout");
            //}

            WorkoutData.Insert(aWorkout);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Workout"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aWorkout">A <see cref="Workout"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkout</c> argument is <c>null</c>.</exception>
        public static void Update(FanKey aFanKey, Workout aWorkout)
        {
            if (aWorkout == null)
            {
                throw new ArgumentNullException("Update Workout Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Workout", AccessMode.Update))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.WorkoutnKey), AccessMode.Update, "Workout");
            //}

            WorkoutData.Update(aWorkout);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Workout"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aWorkout">A <see cref="Workout"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkout</c> argument is <c>null</c>.</exception>
        public static void Delete(FanKey aFanKey, Workout aWorkout)
        {
            if (aWorkout == null)
            {
                throw new ArgumentNullException("Delete Workout Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Workout", AccessMode.Delete))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.WorkoutnKey), AccessMode.Delete, "Workout");
            //}

            WorkoutData.Delete(aWorkout);
        }

        #endregion
    }
}
