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

        #region Cell Web methods 

        #region Load Cell

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
        #endregion

        #region Add Cell

        [WebMethod(EnableSession = false)]
        public static webObject addCell(Cell aCell)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            FanKey vFanKey = ServerSession.GetObject<FanKey>(HttpContext.Current.Session);

            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            ServerSession.PutObject<FanKey>(HttpContext.Current.Session, vFanKey); // Review this element of pattern 
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                FanServiceConsumer.AddCell(vFanToken, aCell);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Cell Added";
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
                vWebObject.aTransactionStatus.Message = "Addition of Cell unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #region Edit Cell

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

        #endregion

        #region Delete Cell

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

        #endregion

        #endregion

        #region Fed Web methods

        #region Load Fed

        [WebMethod(EnableSession = false)]
        public static webObject loadFed(Fed aFed)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            FanKey vFanKey = ServerSession.GetObject<FanKey>(HttpContext.Current.Session);

            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            ServerSession.PutObject<FanKey>(HttpContext.Current.Session, vFanKey); // Review this element of pattern 
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                FanServiceConsumer.GetFed(vFanToken, aFed);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Fed Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFed;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of Fed unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #region Add Fed

        [WebMethod(EnableSession = false)]
        public static webObject addFed(Fed aFed)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            FanKey vFanKey = ServerSession.GetObject<FanKey>(HttpContext.Current.Session);

            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            ServerSession.PutObject<FanKey>(HttpContext.Current.Session, vFanKey); // Review this element of pattern 
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                FanServiceConsumer.AddFed(vFanToken, aFed);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Fed Added";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFed;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Addition of Fed unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #region Edit Fed

        [WebMethod(EnableSession = false)]
        public static webObject editFed(Fed aFed)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            FanKey vFanKey = ServerSession.GetObject<FanKey>(HttpContext.Current.Session);

            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            ServerSession.PutObject<FanKey>(HttpContext.Current.Session, vFanKey); // Review this element of pattern 
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                FanServiceConsumer.EditFed(vFanToken, aFed);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Fed Edited";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFed;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Edit of Fed unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #region Delete Fed

        [WebMethod(EnableSession = false)]
        public static webObject deleteFed(Fed aFed)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            FanKey vFanKey = ServerSession.GetObject<FanKey>(HttpContext.Current.Session);

            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            ServerSession.PutObject<FanKey>(HttpContext.Current.Session, vFanKey); // Review this element of pattern 
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            try
            {
                FanServiceConsumer.DeleteFed(vFanToken, aFed);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Fed Deleted";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFed;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Deletion of Fed unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #endregion
    }
}