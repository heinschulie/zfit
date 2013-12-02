using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    public class FriendBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="FriendCollection"/>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFriendCollection">A <see cref="FriendCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aFriendCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, FriendCollection aFriendCollection)
        {
            if (aFriendCollection == null)
            {
                throw new ArgumentNullException("Load Friend Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Friend", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.List, "Friend");
            //}

            FriendData.Load(aFriendCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Friend"/> object, with keys in <c>aFriend</c>.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey"/> object.</param>
        /// <param name="aFriend">A <see cref="Friend"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFriend</c> is <c>null</c>.</exception>
        public static void Load(FanKey aFanKey, Friend aFriend)
        {
            if (aFriend == null)
            {
                throw new ArgumentNullException("Load Friend Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Friend", AccessMode.Read))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Read, "Friend");
            //}

            FriendData.Load(aFriend);
        }

        #endregion

        #region Save

        /// <summary>
        /// Save a <see cref="Friend" /> list passed as an argument.
        /// </summary>
        /// <param name="aFanKey">A <see cref="FanKey" /> object.</param>
        /// <param name="aFriendCollection">A fan fed collection.</param>
        /// <exception cref="Zephry.ZpAccessException">Access Denied; Friend</exception>
        /// <exception cref="ArgumentNullException">If <c>aFriend</c> argument is <c>null</c>.</exception>
        public static void Save(FanKey aFanKey, FriendCollection aFriendCollection)
        {
            if (aFriendCollection == null)
            {
                throw new ArgumentNullException("Update FriendCollection Business");
            }

            //if (!FanFunctionAccessData.HasModeAccess(aFanKey, "Friend", AccessMode.Update))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aFanKey.FannKey), AccessMode.Update, "Friend");
            //}
           
            FriendCollection vExisting = new FriendCollection();
            vExisting.IsFiltered = true; 
            vExisting.FriendFilter.AssignFromSource(aFriendCollection.FriendFilter);
            FriendData.Load(vExisting);
            FriendCollection vFresh = new FriendCollection();
            vFresh.IsFiltered = true; 
            vFresh.FriendFilter.AssignFromSource(aFriendCollection.FriendFilter);

            foreach (Friend vFriend in aFriendCollection.FriendList)
            {             
                bool exists = false;
                bool bonafide = true;
                int instancenumber = 0;

                foreach (Friend aFriend in vExisting.FriendList)
                {                    
                    if (vFriend.Fan1Key == aFriend.Fan1Key && vFriend.Fan2Key == aFriend.Fan2Key)
                    {
                        exists = true;
                        instancenumber++; 
                        break; 
                    }
                    else if (vFriend.Fan1Key == aFriend.Fan2Key && vFriend.Fan2Key == aFriend.Fan1Key)
                    {
                        bonafide = false; 
                        break;
                    }
                }
                if ((exists || bonafide) && instancenumber < 2)
                    vFresh.FriendList.Add(vFriend);
            }

            FriendData.Save(vFresh);
        }

        #endregion
    }
}
