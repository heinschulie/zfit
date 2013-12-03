using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    public class ExerciseBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="ExerciseCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aExerciseCollection">A <see cref="ExerciseCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aExerciseCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, ExerciseCollection aExerciseCollection)
        {
            if (aExerciseCollection == null)
            {
                throw new ArgumentNullException("Load Exercise Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Exercise", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.ExercisenKey), AccessMode.List, "Exercise");
            //}

            ExerciseData.Load(aExerciseCollection);
        }

        #endregion


        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Exercise"/> object, with keys in <c>aExercise</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aExercise">A <see cref="Exercise"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aExercise</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, Exercise aExercise)
        {
            if (aExercise == null)
            {
                throw new ArgumentNullException("Load Exercise Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Exercise", AccessMode.Read))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.ExercisenKey), AccessMode.Read, "Exercise");
            //}

            ExerciseData.Load(aExercise);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Exercise"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>Exercise Key</i>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aExercise">A <see cref="Exercise"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aExercise</c> argument is <c>null</c>.</exception>
        public static void Insert(FanKey aFanKey, Exercise aExercise)
        {
            if (aExercise == null)
            {
                throw new ArgumentNullException("Insert Exercise Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Exercise", AccessMode.Create))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Create, "Exercise");
            //}

            ExerciseData.Insert(aExercise);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Exercise"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aExercise">A <see cref="Exercise"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aExercise</c> argument is <c>null</c>.</exception>
        public static void Update(FanKey aFanKey, Exercise aExercise)
        {
            if (aExercise == null)
            {
                throw new ArgumentNullException("Update Exercise Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Exercise", AccessMode.Update))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.ExercisenKey), AccessMode.Update, "Exercise");
            //}

            ExerciseData.Update(aExercise);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Exercise"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aExercise">A <see cref="Exercise"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aExercise</c> argument is <c>null</c>.</exception>
        public static void Delete(FanKey aFanKey, Exercise aExercise)
        {
            if (aExercise == null)
            {
                throw new ArgumentNullException("Delete Exercise Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Exercise", AccessMode.Delete))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.ExercisenKey), AccessMode.Delete, "Exercise");
            //}

            ExerciseData.Delete(aExercise);
        }

        #endregion
    }
}
