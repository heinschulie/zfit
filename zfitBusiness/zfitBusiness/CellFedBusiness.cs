using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    public class CellFedBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="CellFedCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aCellFedCollection">A <see cref="CellFedCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aCellFedCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, CellFedCollection aCellFedCollection)
        {
            if (aCellFedCollection == null)
            {
                throw new ArgumentNullException("Load CellFed Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "CellFed", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.List, "CellFed");
            //}

            CellFedData.Load(aCellFedCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="CellFed"/> object, with keys in <c>aCellFed</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aCellFed">A <see cref="CellFed"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aCellFed</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, CellFed aCellFed)
        {
            if (aCellFed == null)
            {
                throw new ArgumentNullException("Load CellFed Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "CellFed", AccessMode.Read))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Read, "CellFed");
            //}

            CellFedData.Load(aCellFed);
        }

        #endregion

        #region Save

        /// <summary>
        /// Save a <see cref="CellFed" /> list passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey" /> object.</param>
        /// <param name="aCellFedCollection">A cell fed collection.</param>
        /// <exception cref="Zephry.ZpAccessException">Access Denied; CellFed</exception>
        /// <exception cref="ArgumentNullException">If <c>aCellFed</c> argument is <c>null</c>.</exception>
        public static void Save(FanKey aFanKey, CellFedCollection aCellFedCollection)
        {
            if (aCellFedCollection == null)
            {
                throw new ArgumentNullException("Update CellFedCollection Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "CellFed", AccessMode.Update))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Update, "CellFed");
            //}

            CellFedData.Save(aCellFedCollection);
        }

        #endregion
    }
}
