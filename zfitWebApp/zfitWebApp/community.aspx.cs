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
    public partial class community : System.Web.UI.Page
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
        public static webObject loadCell(Cell aCell)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            FanKey vFanKey = ServerSession.GetObject<FanKey>(HttpContext.Current.Session);

            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            ServerSession.PutObject<FanKey>(HttpContext.Current.Session, vFanKey); // Review this element of pattern 
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                FanServiceConsumer.GetCell(vFanToken, aCell);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Cell Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aCell;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of Cell unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        [WebMethod(EnableSession = false)]
        public static webObject editCell(Cell aCell)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            FanKey vFanKey = ServerSession.GetObject<FanKey>(HttpContext.Current.Session);

            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            ServerSession.PutObject<FanKey>(HttpContext.Current.Session, vFanKey); // Review this element of pattern 
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                FanServiceConsumer.EditCell(vFanToken, aCell);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Cell Edited";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aCell;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Edit of Cell unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        [WebMethod(EnableSession = false)]
        public static webObject deleteCell(Cell aCell)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            FanKey vFanKey = ServerSession.GetObject<FanKey>(HttpContext.Current.Session);

            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            ServerSession.PutObject<FanKey>(HttpContext.Current.Session, vFanKey); // Review this element of pattern 
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                FanServiceConsumer.DeleteCell(vFanToken, aCell);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Cell Deleted";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aCell;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Deletion of Cell unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
    }
}