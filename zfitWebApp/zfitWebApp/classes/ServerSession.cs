using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.SessionState;
using Zephry;

namespace zfit
{
    public class ServerSession
    {

        #region Constants for "global" session objects

        public const string sessionFan = "Fan";
        public const string sessionFanToken = "FanToken";

        public const string sessionUser = "User";
        public const string sessionPublicToken = "PublicToken";
        public const string sessionUserToken = "UserToken";
        public const string sessionSiteType = "SiteType";
        public const string sessionTransactionStatus = "TransactionStatus";
        public const string sessionChangeAction = "ChangeAction";
        public const string sessionPreviousUrl = "PreviousUrl"; 
        #endregion

        #region Logon User
        /// <summary>
        /// Logon to Ruci via a call to UserServiceConsumer, save the connected User and UserToken to HttpSessionState.
        /// </summary>
        /// <param name="aHttpSessionState">An HttpSessionState from the calling page.</param>
        /// <param name="aUser">A Ruci.User.</param>
        public static void Logon(HttpSessionState aHttpSessionState, User aUser)
        {
            //
            // Create a UserToken, populate with logon and Settings values
            //
            UserToken vUserToken = new UserToken()
            {
                UserID = aUser.UsrID,
                Password = aUser.UsrPassword,
                Url = "http://localhost/zfitsoap/zfitService.asmx"
            };
            //
            // Get a User by ID
            //
            UserServiceConsumer.GetUserByID(vUserToken, aUser);
            // Fully populate the UserToken and save it to Session
            vUserToken.Context = ConnectionContext.Browse;
            vUserToken.Version = "web";
            aHttpSessionState[sessionUserToken] = vUserToken;
            //
            // Save the User to the Session
            //
            aHttpSessionState[sessionUser] = aUser;
        }
        #endregion

        #region Logon Fan
        /// <summary>
        /// Logon to zfit via a call to FanServiceConsumer, save the connected Fan and FanToken to HttpSessionState.
        /// </summary>
        /// <param name="aHttpSessionState">An HttpSessionState from the calling page.</param>
        /// <param name="aFan">A zfit.Fan.</param>
        public static void Logon(HttpSessionState aHttpSessionState, Fan aFan)
        {
            //
            // Create a FanToken, populate with logon and Settings values
            //
            FanToken vFanToken = new FanToken()
            {
                FanID = aFan.FanID,
                Password = aFan.FanPassword,
                Url = "http://localhost/zfitsoap/zfitService.asmx"
            };
            //
            // Get a Fan by ID
            //
            FanServiceConsumer.GetFanByID(vFanToken, aFan);
            // Fully populate the FanToken and save it to Session
            vFanToken.Context = ConnectionContext.Browse;
            vFanToken.Version = "web";
            aHttpSessionState[sessionFanToken] = vFanToken;
            //
            // Save the Fan to the Session
            //
            aHttpSessionState[sessionFan] = aFan;
        }
        #endregion

        #region ClearSessionBusiness
        /// <summary>
        /// Clears all Session items that are not global.
        /// </summary>
        /// <param name="aHttpSessionState">State of a HTTP session.</param>
        public static void ClearSessionBusiness(HttpSessionState aHttpSessionState)
        {
            for (int i = aHttpSessionState.Keys.Count - 1; i > -1; i--)
            {
                if ((aHttpSessionState.Keys[i] != sessionFan) &&
                    (aHttpSessionState.Keys[i] != sessionFanToken) &&
                    (aHttpSessionState.Keys[i] != sessionUser) &&
                    (aHttpSessionState.Keys[i] != sessionUserToken) &&
                    (aHttpSessionState.Keys[i] != sessionPublicToken) &&
                    (aHttpSessionState.Keys[i] != sessionSiteType) &&
                    (aHttpSessionState.Keys[i] != sessionTransactionStatus) &&
                    (aHttpSessionState.Keys[i] != sessionChangeAction) &&
                    (aHttpSessionState.Keys[i] != sessionPreviousUrl))
                {
                    aHttpSessionState.Remove(aHttpSessionState.Keys[i]);
                }
            }
        }
        #endregion

        //#region GetPublicToken
        ///// <summary>
        ///// Gets the PublicToken.
        ///// </summary>
        ///// <param name="aHttpSessionState">State of a HTTP session.</param>
        ///// <returns>
        ///// PublicToken
        ///// </returns>
        //public static PublicToken GetPublicToken(HttpSessionState aHttpSessionState)
        //{

        //    PublicToken vPublicToken = aHttpSessionState[sessionPublicToken] as PublicToken;
        //    if (vPublicToken == null)
        //    {
        //        vPublicToken = new PublicToken();
        //        aHttpSessionState[sessionPublicToken] = vPublicToken;
        //    }
        //    return vPublicToken;
        //}
        //#endregion

        #region GetFanToken
        /// <summary>
        /// Gets the fan token.
        /// </summary>
        /// <param name="aState">An HttpSessionState.</param>
        /// <returns>FanToken</returns>
        public static FanToken GetFanToken(HttpSessionState aHttpSessionState)
        {
            return aHttpSessionState[sessionFanToken] as FanToken;
        }
        #endregion

        #region GetFan
        /// <summary>
        /// Gets the fan.
        /// </summary>
        /// <param name="aState">An HttpSessionState.</param>
        /// <returns>Fan</returns>
        public static Fan GetUser(HttpSessionState aHttpSessionState)
        {
            return aHttpSessionState[sessionFan] as Fan;
        }
        #endregion

        #region GetUserToken
        /// <summary>
        /// Gets the user token.
        /// </summary>
        /// <param name="aState">An HttpSessionState.</param>
        /// <returns>UserToken</returns>
        public static UserToken GetUserToken(HttpSessionState aHttpSessionState)
        {
            return aHttpSessionState[sessionUserToken] as UserToken;
        }
        #endregion

        //#region GetUser
        ///// <summary>
        ///// Gets the user.
        ///// </summary>
        ///// <param name="aState">An HttpSessionState.</param>
        ///// <returns>User</returns>
        //public static User GetUser(HttpSessionState aHttpSessionState)
        //{
        //    return aHttpSessionState[sessionUser] as User;
        //}
        //#endregion

        #region SetTransactionStatusWithCommonException

        public static void SetTransactionStatusWithCommonException(HttpSessionState aSession, Exception ex)
        {
            TransactionStatus vTransactionStatus = ServerSession.GetTransactionStatus(aSession);
            vTransactionStatus.TransactionResult = TransactionResult.GeneralException;
            vTransactionStatus.Message = ex.Message;
            vTransactionStatus.InnerMessage = ex.StackTrace;
            ServerSession.SetTransactionStatus(aSession, vTransactionStatus);
        }

        #endregion

        #region GetTransactionStatus
        /// <summary>
        /// Gets the transaction status.
        /// </summary>
        /// <param name="aState">An HttpSessionState.</param>
        /// <returns>TransactionStatus</returns>
        public static TransactionStatus GetTransactionStatus(HttpSessionState aHttpSessionState)
        {
            TransactionStatus vTransactionStatus = aHttpSessionState[sessionTransactionStatus] as TransactionStatus;
            if (vTransactionStatus == null)
            {
                vTransactionStatus = new TransactionStatus();
                aHttpSessionState[sessionTransactionStatus] = vTransactionStatus;
            }
            return vTransactionStatus;
        }
        #endregion

        #region SetTransactionStatus
        /// <summary>
        /// Sets the TransactionStatus.
        /// </summary>
        /// <param name="aHttpSessionState">An HttpSessionState.</param>
        /// <param name="aTransactionStatus">A TransactionStatus.</param>
        public static void SetTransactionStatus(HttpSessionState aHttpSessionState, TransactionStatus aTransactionStatus)
        {
            aHttpSessionState[sessionTransactionStatus] = aTransactionStatus;
        }
        #endregion

        #region GetChangeAction
        /// <summary>
        /// Gets the current ChangeAction
        /// </summary>
        /// <param name="aState">An HttpSessionState.</param>
        /// <returns>A ChangeAction</returns>
        public static ChangeAction GetChangeAction(HttpSessionState aHttpSessionState)
        {
            if (aHttpSessionState[sessionChangeAction] == null)
            {
                return ChangeAction.Browse;
            }
            else
            {
                return (ChangeAction)aHttpSessionState[sessionChangeAction];
            }
        }
        #endregion

        #region SetChangeAction
        /// <summary>
        /// Sets the change action.
        /// </summary>
        /// <param name="aHttpSessionState">An HttpSessionState.</param>
        /// <param name="aChangeAction">A ChangeAction.</param>
        public static void SetChangeAction(HttpSessionState aHttpSessionState, ChangeAction aChangeAction)
        {
            aHttpSessionState[sessionChangeAction] = aChangeAction;
        }
        #endregion

        #region PutObject of <T>
        /// <summary>
        /// Puts the object of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aHttpSessionState">An HttpSessionState.</param>
        /// <param name="aObject">A object of Type T.</param>
        public static void PutObject<T>(HttpSessionState aHttpSessionState, T aObject)
        {
            aHttpSessionState[typeof(T).ToString()] = aObject;
        }
        #endregion

        #region GetObject of <T>
        /// <summary>
        /// Gets the object of type T
        /// </summary>
        /// <typeparam name="T">The Type T to Return</typeparam>
        /// <param name="aState">An HttpSessionState.</param>
        /// <returns>T</returns>
        public static T GetObject<T>(HttpSessionState aHttpSessionState)
        {
            return (T)aHttpSessionState[typeof(T).ToString()];
        }

        /// <summary>
        /// Gets the object of type T as string
        /// </summary>
        /// <string name="T">The Type T to Return</string>
        /// <param name="aState">An HttpSessionState.</param>
        /// <returns>T</returns>
        public static object GetObject(HttpSessionState aHttpSessionState, string aTypeName)
        {           
            return aHttpSessionState[aTypeName];
        }
        #endregion

        #region RemoveObject of <T>
        /// <summary>
        /// Removes the object of type T
        /// </summary>
        /// <typeparam name="T">The Type T to remove</typeparam>
        /// <param name="aState">An HttpSessionState.</param>
        public static void RemoveObject<T>(HttpSessionState aHttpSessionState)
        {
            aHttpSessionState.Remove(typeof(T).ToString());
        }
        #endregion

        #region GetPreviousUrl of Current Page

        public static string GetPreviousUrl(HttpSessionState aHttpSessionState)
        {
            return aHttpSessionState[sessionPreviousUrl] as string; 
        }
        #endregion

        #region SetCurrentUrl of Current Page

        public static void SetCurrentUrl(HttpSessionState aHttpSessionState, string aCurrentUrl)
        {
            aHttpSessionState[sessionPreviousUrl] = aCurrentUrl; 
        }
        #endregion       
    }
}