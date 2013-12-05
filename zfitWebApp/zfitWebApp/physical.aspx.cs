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
    public partial class physical : System.Web.UI.Page
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

        #region Exercise Web methods

        #region Load ExerciseCollection

        [WebMethod(EnableSession = false)]
        public static webObject loadExerciseCollection(Exercise aExercise)
        {
            ExerciseCollection vExerciseCollection = new ExerciseCollection();
            vExerciseCollection.ExerciseFilter.ExcFilter.AssignFromSource(aExercise);

            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);          
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.GetExerciseCollection(vFanToken, vExerciseCollection);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "ExerciseCollection Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = vExerciseCollection;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of ExerciseCollection unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #region Load Exercise

        [WebMethod(EnableSession = false)]
        public static webObject loadExercise(Exercise aExercise)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);          
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.GetExercise(vFanToken, aExercise);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Exercise Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aExercise;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of Exercise unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #region Add Exercise

        [WebMethod(EnableSession = false)]
        public static webObject addExercise(Exercise aExercise)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);        
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.AddExercise(vFanToken, aExercise);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Exercise Added";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aExercise;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Addition of Exercise unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #region Edit Exercise

        [WebMethod(EnableSession = false)]
        public static webObject editExercise(Exercise aExercise)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);            
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.EditExercise(vFanToken, aExercise);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Exercise Edited";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aExercise;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Edit of Exercise unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #region Delete Exercise

        [WebMethod(EnableSession = false)]
        public static webObject deleteExercise(Exercise aExercise)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);          
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.DeleteExercise(vFanToken, aExercise);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Exercise Deleted";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aExercise;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Deletion of Exercise unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #endregion

        #region Workout Web methods

        #region Load WorkoutCollection

        [WebMethod(EnableSession = false)]
        public static webObject loadWorkoutCollection(Workout aWorkout)
        {
            WorkoutCollection vWorkoutCollection = new WorkoutCollection();
            vWorkoutCollection.WorkoutFilter.WrtFilter.AssignFromSource(aWorkout); 

            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);           
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.GetWorkoutCollection(vFanToken, vWorkoutCollection);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "WorkoutCollection Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = vWorkoutCollection;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of WorkoutCollection unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #region Load Workout

        [WebMethod(EnableSession = false)]
        public static webObject loadWorkout(Workout aWorkout)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);         
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.GetWorkout(vFanToken, aWorkout);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Workout Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aWorkout;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of Workout unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #region Add Workout

        [WebMethod(EnableSession = false)]
        public static webObject addWorkout(Workout aWorkout)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            FanKey vFanKey = ServerSession.GetObject<FanKey>(HttpContext.Current.Session);
            aWorkout.WrtOwnerKey = vFanKey.FannKey; 
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.AddWorkout(vFanToken, aWorkout);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Workout Added";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aWorkout;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Addition of Workout unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #region Edit Workout

        [WebMethod(EnableSession = false)]
        public static webObject editWorkout(Workout aWorkout)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);           
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.EditWorkout(vFanToken, aWorkout);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Workout Edited";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aWorkout;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Edit of Workout unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #region Delete Workout

        [WebMethod(EnableSession = false)]
        public static webObject deleteWorkout(Workout aWorkout)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);           
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.DeleteWorkout(vFanToken, aWorkout);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Workout Deleted";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aWorkout;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Deletion of Workout unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #endregion

        #region Activity Web methods

        #region Load ActivityCollection

        [WebMethod(EnableSession = false)]
        public static webObject loadActivityCollection(Activity aActivity)
        {
            ActivityCollection vActivityCollection = new ActivityCollection();
            vActivityCollection.ActivityFilter.ActFilter.AssignFromSource(aActivity);

            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);           
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.GetActivityCollection(vFanToken, vActivityCollection);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "ActivityCollection Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = vActivityCollection;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of ActivityCollection unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #region Load Activity

        [WebMethod(EnableSession = false)]
        public static webObject loadActivity(Activity aActivity)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);            
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.GetActivity(vFanToken, aActivity);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Activity Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aActivity;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of Activity unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #region Add Activity

        [WebMethod(EnableSession = false)]
        public static webObject addActivity(Activity aActivity)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            FanKey vFanKey = ServerSession.GetObject<FanKey>(HttpContext.Current.Session);
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.AddActivity(vFanToken, aActivity);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Activity Added";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aActivity;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Addition of Activity unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #region Edit Activity

        [WebMethod(EnableSession = false)]
        public static webObject editActivity(Activity aActivity)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);           
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.EditActivity(vFanToken, aActivity);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Activity Edited";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aActivity;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Edit of Activity unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #region Delete Activity

        [WebMethod(EnableSession = false)]
        public static webObject deleteActivity(Activity aActivity)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);           
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.DeleteActivity(vFanToken, aActivity);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "Activity Deleted";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aActivity;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Deletion of Activity unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #endregion

        #region FanWorkout Web methods

        #region Load FanWorkoutCollection

        [WebMethod(EnableSession = false)]
        public static webObject loadFanWorkoutCollection(FanWorkoutCollection aFanWorkoutCollection)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.GetFanWorkoutCollection(vFanToken, aFanWorkoutCollection);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "FanWorkoutCollection Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFanWorkoutCollection;
            }
            catch (TransactionStatusException tx)
            {
                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of FanWorkoutCollection unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #region Edit FanWorkoutCollection

        [WebMethod(EnableSession = false)]
        public static webObject editFanWorkoutCollection(FanWorkoutCollection aFanWorkoutCollection)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.SaveFanWorkout(vFanToken, aFanWorkoutCollection);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "FanWorkoutCollection Edited";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFanWorkoutCollection;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Edit of FanWorkoutCollection unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #endregion 
        
        //Check with Leon about when to employ which crud methods... Or just think about it carefully yourself. Meanwhile just do it all.  

        #region FanSession Web methods

        #region Load FanSessionCollection

        [WebMethod(EnableSession = false)]
        public static webObject loadFanSessionCollection(FanSessionCollection aFanSessionCollection)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            FanKey vFanKey = ServerSession.GetObject<FanKey>(HttpContext.Current.Session);
            aFanSessionCollection.FanSessionFilter.FssFilter.FanKey = vFanKey.FannKey; 
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.GetFanSessionCollection(vFanToken, aFanSessionCollection);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "FanSessionCollection Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFanSessionCollection;
            }
            catch (TransactionStatusException tx)
            {
                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of FanSessionCollection unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #region Edit FanSessionCollection

        [WebMethod(EnableSession = false)]
        public static webObject editFanSessionCollection(FanSessionCollection aFanSessionCollection)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);           
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.SaveFanSession(vFanToken, aFanSessionCollection);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "FanSessionCollection Edited";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFanSessionCollection;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Edit of FanSessionCollection unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #region Load FanSession

        [WebMethod(EnableSession = false)]
        public static webObject loadFanSession(FanSession aFanSession)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);            
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.GetFanSession(vFanToken, aFanSession);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "FanSession Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFanSession;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of FanSession unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #region Add FanSession

        [WebMethod(EnableSession = false)]
        public static webObject addFanSession(FanSession aFanSession)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            FanKey vFanKey = ServerSession.GetObject<FanKey>(HttpContext.Current.Session);
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.AddFanSession(vFanToken, aFanSession);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "FanSession Added";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFanSession;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Addition of FanSession unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #region Edit FanSession

        [WebMethod(EnableSession = false)]
        public static webObject editFanSession(FanSession aFanSession)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);          
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.EditFanSession(vFanToken, aFanSession);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "FanSession Edited";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFanSession;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Edit of FanSession unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #region Delete FanSession

        [WebMethod(EnableSession = false)]
        public static webObject deleteFanSession(FanSession aFanSession)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);          
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.DeleteFanSession(vFanToken, aFanSession);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "FanSession Deleted";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFanSession;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Deletion of FanSession unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }

        #endregion

        #endregion  
        
        #region FanSessionActivity Web methods

        #region Load FanSessionActivityCollection

        [WebMethod(EnableSession = false)]
        public static webObject loadFanSessionActivityCollection(FanSessionActivityCollection aFanSessionActivityCollection)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.GetFanSessionActivityCollection(vFanToken, aFanSessionActivityCollection);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "FanSessionActivityCollection Loaded";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFanSessionActivityCollection;
            }
            catch (TransactionStatusException tx)
            {
                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Load of FanSessionActivityCollection unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #region Edit FanSessionActivityCollection

        [WebMethod(EnableSession = false)]
        public static webObject editFanSessionActivityCollection(FanSessionActivityCollection aFanSessionActivityCollection)
        {
            FanToken vFanToken = ServerSession.GetFanToken(HttpContext.Current.Session);
            webObject vWebObject = new webObject();
            vWebObject.aTransactionStatus = ServerSession.GetTransactionStatus(HttpContext.Current.Session);

            try
            {
                FanServiceConsumer.SaveFanSessionActivity(vFanToken, aFanSessionActivityCollection);
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.OK;
                vWebObject.aTransactionStatus.Message = "FanSessionActivityCollection Edited";
                ServerSession.SetTransactionStatus(HttpContext.Current.Session, vWebObject.aTransactionStatus);
                vWebObject.AnObject = aFanSessionActivityCollection;
            }
            catch (TransactionStatusException tx)
            {

                vWebObject.aTransactionStatus.AssignFromSource(tx.TransactionStatus);
                return vWebObject;
            }
            catch (Exception ex)
            {
                vWebObject.aTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vWebObject.aTransactionStatus.Message = "Edit of FanSessionActivityCollection unsuccesful" + ex.Message;
                vWebObject.aTransactionStatus.InnerMessage = ex.InnerException == null ? String.Empty : ex.InnerException.Message;
                return vWebObject;
            }
            return vWebObject;
        }
        #endregion

        #endregion 
    }
}