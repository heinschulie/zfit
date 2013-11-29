using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    public class CellBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="CellCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aCellCollection">A <see cref="CellCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aCellCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, CellCollection aCellCollection)
        {
            if (aCellCollection == null)
            {
                throw new ArgumentNullException("Load Cell Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Cell", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.CellnKey), AccessMode.List, "Cell");
            //}

            CellData.Load(aCellCollection);
        }

        #endregion


        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Cell"/> object, with keys in <c>aCell</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aCell">A <see cref="Cell"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aCell</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, Cell aCell)
        {
            if (aCell == null)
            {
                throw new ArgumentNullException("Load Cell Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Cell", AccessMode.Read))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.CellnKey), AccessMode.Read, "Cell");
            //}

            CellData.Load(aCell);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Cell"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>Cell Key</i>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aCell">A <see cref="Cell"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aCell</c> argument is <c>null</c>.</exception>
        public static void Insert(FanKey aFanKey, Cell aCell)
        {
            if (aCell == null)
            {
                throw new ArgumentNullException("Insert Cell Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Cell", AccessMode.Create))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Create, "Cell");
            //}

            CellData.Insert(aCell);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Cell"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aCell">A <see cref="Cell"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aCell</c> argument is <c>null</c>.</exception>
        public static void Update(FanKey aFanKey, Cell aCell)
        {
            if (aCell == null)
            {
                throw new ArgumentNullException("Update Cell Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Cell", AccessMode.Update))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.CellnKey), AccessMode.Update, "Cell");
            //}

            CellData.Update(aCell);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Cell"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aCell">A <see cref="Cell"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aCell</c> argument is <c>null</c>.</exception>
        public static void Delete(FanKey aFanKey, Cell aCell)
        {
            if (aCell == null)
            {
                throw new ArgumentNullException("Delete Cell Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Cell", AccessMode.Delete))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.CellnKey), AccessMode.Delete, "Cell");
            //}

            CellData.Delete(aCell);
        }

        #endregion
    }
}
