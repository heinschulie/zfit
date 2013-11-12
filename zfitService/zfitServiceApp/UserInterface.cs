using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Zephry;

namespace zfit
{
    public class UserInterface
    {
        #region Invoke

        /// <summary>
        ///   Delegates the method.
        /// </summary>
        /// <param name="aXmlCredentials">The XMLCredentials <see cref="string"/>.</param>
        /// <param name="aXmlArgument">The XMLArgument <see cref="string"/>.</param>
        /// <returns>
        ///   Concatenated XML <see cref="string"/>.
        /// </returns>
        public static string Invoke(string aXmlCredentials, string aXmlArgument)
        {
            try
            {
                UserToken vUserToken = new UserToken();
                // Deserialize the 1st argument (aXmlCredentials) from an XML string into a UserToken
                vUserToken = XmlUtils.Deserialize<UserToken>(aXmlCredentials);
                // Deserialize the data access file into a Session
                Connection.Instance = FileUtils.Deserialize<Connection>(HttpContext.Current.Server.MapPath("~/bin/zfit.connection.dat"));
                // Invoke the method named in UserToken.Instance.Method, passing a UserKey as the 1st argument and the 2nd argument (aXmlArgument) unchanged
                object[] vArgArray = new object[] { InitializeSession(vUserToken), aXmlArgument };
                var vMethodInfo = typeof(UserImplementation).GetMethod(vUserToken.Method);
                if (vMethodInfo == null)
                {
                    throw new Exception(string.Format("Webservice Method not found: \"{0}\".", vUserToken.Method));
                }
                //
                // This is where the method passed in UserToken is actually invoked
                //
                string vXml = (string)vMethodInfo.Invoke(null, vArgArray);
                //
                //
                //
                return XmlUtils.Concatenate(TransactionSuccess(), vXml, "xml");
            }
            catch (ZpAccessException ax)
            {
                return XmlUtils.Concatenate(TransactionAccessException(ax), null, "xml");
            }
            catch (Exception ex)
            {
                return XmlUtils.Concatenate(TransactionException(ex), null, "xml");
            }
        }

        #endregion

        #region InitializeSession

        /// <summary>
        /// Initializes the session with the Session token file located 
        /// </summary>
        /// <returns></returns>
        private static UserKey InitializeSession(UserToken aUserToken)
        {
            var vUserKey = new UserKey();

            //The following body of code is commented out as this is a public system. Once PublicInterface is built 
            //we will return to a regular broadcast. 

            var vUser = new User() { UsrID = aUserToken.UserID };
            UserBusiness.LoadByID(vUserKey, vUser);
            if (String.Compare(vUser.UsrPassword, aUserToken.Password, false) != 0)
            {
                throw new Exception("User Authentication Exception");
            }
            vUserKey.UsrKey = vUser.UsrKey;

            return vUserKey;
        }

        #endregion

        #region TransactionSuccess

        // Build Success Status document
        private static string TransactionSuccess()
        {
            var vTransactionStatus = new TransactionStatus
            {
                TransactionResult = TransactionResult.OK,
                Message = "Success",
                SourceAssembly = SourceAssembly.Services
            };
            return XmlUtils.Serialize<TransactionStatus>(vTransactionStatus, true);
        }

        #endregion

        #region TransactionAccessException
        // Build Access Exception Status document
        private static string TransactionAccessException(ZpAccessException aAccessException)
        {
            var vTransactionStatus = new TransactionStatus
            {
                TransactionResult = TransactionResult.AccessException,
                Message = aAccessException.Message,
                SourceAssembly = SourceAssembly.Business
            };
            return XmlUtils.Serialize<TransactionStatus>(vTransactionStatus, true);
        }
        #endregion

        #region TransactionException
        // Return a TransactionStatus 
        private static string TransactionException(Exception aException)
        {
            var vTransactionStatus = new TransactionStatus();
            try
            {
                StringBuilder vMessageStack = new StringBuilder();
                int vMessageCount = 0;
                vMessageStack.AppendFormat("{0} - {1}", ++vMessageCount, aException.Message).AppendLine();
                var vException = aException.InnerException;
                while (vException != null)
                {
                    vMessageStack.AppendFormat("{0} - {1}", ++vMessageCount, vException.Message).AppendLine();
                    vException = vException.InnerException;
                }

                vTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vTransactionStatus.Message = vMessageStack.ToString();
                vTransactionStatus.SourceAssembly = SourceAssembly.Services;
                if (vException != null)
                {
                    vTransactionStatus.InnerMessage = vException.StackTrace;
                }
                return XmlUtils.Serialize<TransactionStatus>(vTransactionStatus, true);
            }
            catch (Exception ex)
            {
                string vMessage = string.Format("TransactionException Handler blew with message \"{0}\", original exception was \"{1}\"", ex.Message, aException.Message);
                vTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vTransactionStatus.Message = vMessage;
                vTransactionStatus.SourceAssembly = SourceAssembly.Services;
                vTransactionStatus.InnerMessage = String.Empty;
                return XmlUtils.Serialize<TransactionStatus>(vTransactionStatus, true);
            }
        }
        #endregion

    }
}