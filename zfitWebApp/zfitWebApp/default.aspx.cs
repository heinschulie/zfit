using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zephry;
using System.Web.Services;

namespace zfit
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        [WebMethod(EnableSession = false)]
        public static TransactionStatus userLogon(User aUser)
        {
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            TransactionStatus vTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                ServerSession.Logon(HttpContext.Current.Session, aUser);
                vTransactionStatus.TransactionResult = TransactionResult.OK;
                vTransactionStatus.Message = "Login succesful";
                vTransactionStatus.TargetUrl = "/userdashboard.aspx";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vTransactionStatus);
            }
            catch (TransactionStatusException tx)
            {

                vTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vTransactionStatus;
            }
            catch (Exception ex)
            {
                vTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vTransactionStatus.Message = "Login Unsuccesful - please check your username and password are correct" + ex.Message;
                vTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vTransactionStatus;
            }

            return vTransactionStatus;
        }

        [WebMethod(EnableSession = false)]
        public static TransactionStatus fanLogon(Fan aFan)
        {
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            TransactionStatus vTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                ServerSession.Logon(HttpContext.Current.Session, aFan);
                vTransactionStatus.TransactionResult = TransactionResult.OK;
                vTransactionStatus.Message = "Login succesful";
                vTransactionStatus.TargetUrl = "/fandashboard.aspx";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vTransactionStatus);
            }
            catch (TransactionStatusException tx)
            {
                
                vTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vTransactionStatus;
            }
            catch (Exception ex)
            {
                vTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vTransactionStatus.Message = "Login Unsuccesful - please check your username and password are correct" + ex.Message;
                vTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vTransactionStatus;
            }

            return vTransactionStatus;
        }

        [WebMethod(EnableSession = false)]
        public static TransactionStatus fanRegister(Fan aFan)
        {
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            TransactionStatus vTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                FanToken aFanToken = new FanToken();
                aFanToken.FanID = "Register";
                aFanToken.Password = "Register";
                aFanToken.Url = "http://localhost/zfitsoap/zfitService.asmx";
                aFan.FanName = "new";
                aFan.FanSurname = "fanatic";
                FanServiceConsumer.AddFan(aFanToken, aFan);
                vTransactionStatus.TransactionResult = TransactionResult.OK;
                vTransactionStatus.Message = "You have been succesfully registered!";
                vTransactionStatus.TargetUrl = "/fandashboard.aspx";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vTransactionStatus);
            }
            catch (TransactionStatusException tx)
            {
                vTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vTransactionStatus;
            }
            catch (Exception ex)
            {
                vTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vTransactionStatus.Message = ex.Message;
                vTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vTransactionStatus;
            }

            return vTransactionStatus;
        }
    }
}