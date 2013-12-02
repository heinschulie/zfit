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

        #region Session and Method Success/Exception Calls
    
        #endregion

        #region Cell Web methods

        #region Load Cell

        [WebMethod(EnableSession = false)]
        public static webObject loadCell(Cell aCell)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
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
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
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
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
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
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
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
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session); 
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
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
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
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
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
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
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

        #region CellFan Web methods 
        
        #region Load CellFanCollection

        [WebMethod(EnableSession = false)]
        public static webObject loadCellFanCollection(CellFanCollection aCellFanCollection)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);           
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.GetCellFanCollection(vFanToken, aCellFanCollection);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "CellFanCollection Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aCellFanCollection;
            }
            catch (TransactionStatusException tx)
            {
                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of CellFanCollection unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #region Edit CellFanCollection

        [WebMethod(EnableSession = false)]
        public static webObject editCellFanCollection(CellFanCollection aCellFanCollection)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);           
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);
            
            // ********** TEMPORARY REMEDY UNTIL I SORT OUT DATETIME ISSUE 
            foreach (CellFan vCF in aCellFanCollection.CellFanList)
            {
                vCF.CellFanDateJoined = DateTime.Now; 
            }

            try
            {
                FanServiceConsumer.SaveCellFan(vFanToken, aCellFanCollection);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "CellFanCollection Edited";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aCellFanCollection;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Edit of CellFanCollection unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #endregion 
        
        #region CellFed Web methods

        #region Load CellFedCollection

        [WebMethod(EnableSession = false)]
        public static webObject loadCellFedCollection(CellFedCollection aCellFedCollection)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.GetCellFedCollection(vFanToken, aCellFedCollection);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "CellFedCollection Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aCellFedCollection;
            }
            catch (TransactionStatusException tx)
            {
                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of CellFedCollection unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #region Edit CellFedCollection

        [WebMethod(EnableSession = false)]
        public static webObject editCellFedCollection(CellFedCollection aCellFedCollection)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);           
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session); 
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            // ********** TEMPORARY REMEDY UNTIL I SORT OUT DATETIME ISSUE 
            foreach (CellFed vCF in aCellFedCollection.CellFedList)
            {
                vCF.CellFedDateJoined = DateTime.Now;
            }

            try
            {
                FanServiceConsumer.SaveCellFed(vFanToken, aCellFedCollection);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "CellFedCollection Edited";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aCellFedCollection;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Edit of CellFedCollection unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #endregion 
        
        #region FanFed Web methods

        #region Load FanFedCollection

        [WebMethod(EnableSession = false)]
        public static webObject loadFanFedCollection(FanFedCollection aFanFedCollection)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.GetFanFedCollection(vFanToken, aFanFedCollection);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "FanFedCollection Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFanFedCollection;
            }
            catch (TransactionStatusException tx)
            {
                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of FanFedCollection unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #region Edit FanFedCollection

        [WebMethod(EnableSession = false)]
        public static webObject editFanFedCollection(FanFedCollection aFanFedCollection)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            ServerSession.ClearSessionBusiness(HttpContext.Current.Session);
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            // ********** TEMPORARY REMEDY UNTIL I SORT OUT DATETIME ISSUE 
            foreach (FanFed vCF in aFanFedCollection.FanFedList)
            {
                vCF.FanFedDateJoined = DateTime.Now;
            }

            try
            {
                FanServiceConsumer.SaveFanFed(vFanToken, aFanFedCollection);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "FanFedCollection Edited";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFanFedCollection;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Edit of FanFedCollection unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #endregion 
    }
}