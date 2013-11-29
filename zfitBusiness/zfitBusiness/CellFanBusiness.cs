using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    public class CellFanBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="CellFanCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aCellFanCollection">A <see cref="CellFanCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aCellFanCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, CellFanCollection aCellFanCollection)
        {
            if (aCellFanCollection == null)
            {
                throw new ArgumentNullException("Load CellFan Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "CellFan", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.List, "CellFan");
            //}

            CellFanData.Load(aCellFanCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="CellFan"/> object, with keys in <c>aCellFan</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aCellFan">A <see cref="CellFan"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aCellFan</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, CellFan aCellFan)
        {
            if (aCellFan == null)
            {
                throw new ArgumentNullException("Load CellFan Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "CellFan", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Read, "CellFan");
            }

            CellFanData.Load(aCellFan);
        }

        #endregion

        #region Save

        /// <summary>
        /// Save a <see cref="CellFan" /> list passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey" /> object.</param>
        /// <param name="aCellFanCollection">A cell fan collection.</param>
        /// <exception cref="Zephry.ZpAccessException">Access Denied; CellFan</exception>
        /// <exception cref="ArgumentNullException">If <c>aCellFan</c> argument is <c>null</c>.</exception>
        public static void Save(FanKey aFanKey, CellFanCollection aCellFanCollection)
        {
            if (aCellFanCollection == null)
            {
                throw new ArgumentNullException("Update CellFanCollection Business");
            }

            if (!FanFunctionAccessData.HasModeAccess(aFanKey, "CellFan", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Update, "CellFan");
            }

            CellFanData.Save(aCellFanCollection);
        }

        #endregion
    }
}
