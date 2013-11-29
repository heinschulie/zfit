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
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Fan vFan = new Fan();
            vFan.FanUserID = "heinvh@zephry.co.za";
            vFan.FanPassword = "theboss";
            ServerSession.Logon(HttpContext.Current.Session, vFan);
            FanKey vFanKey = new FanKey();
            vFanKey.FannKey = vFan.FannKey;
            ServerSession.PutObject<FanKey>(HttpContext.Current.Session, vFanKey);
        }

        [WebMethod(EnableSession = false)]
        public static webObject loadFan(Fan aFan)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            FanKey vFanKey = ServerSession.GetObject<FanKey>(HttpContext.Current.Session);
            aFan.FannKey = vFanKey.FannKey;
            aFan.FanUserID = vFanToken.FanID;
            aFan.FanPassword = vFanToken.Password;            

            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            ServerSession.PutObject<FanKey>(HttpContext.Current.Session, vFanKey); // Review this element of pattern 
            webObject vWebObject = new webObject(); 
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                FanServiceConsumer.GetFan(vFanToken, aFan); 
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Fan Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFan; 
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of Fan unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        [WebMethod(EnableSession = false)]
        public static webObject editFan(Fan aFan)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            FanKey vFanKey = ServerSession.GetObject<FanKey>(HttpContext.Current.Session);
            aFan.FannKey = vFanKey.FannKey;

            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            ServerSession.PutObject<FanKey>(HttpContext.Current.Session, vFanKey); // Review this element of pattern 
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                FanServiceConsumer.EditFan(vFanToken, aFan);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Fan Edited";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFan;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Edit of Fan unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }


        [WebMethod(EnableSession = false)]
        public static webObject deleteFan(Fan aFan)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            FanKey vFanKey = ServerSession.GetObject<FanKey>(HttpContext.Current.Session);
            aFan.FannKey = vFanKey.FannKey;

            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            ServerSession.PutObject<FanKey>(HttpContext.Current.Session, vFanKey); // Review this element of pattern 
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                FanServiceConsumer.DeleteFan(vFanToken, aFan);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Fan Deleted";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFan;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Deletion of Fan unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
    }
}