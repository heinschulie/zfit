using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Zephry;

namespace zfit
{
    public class WorkoutData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="Workout"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.WRT_Key, t1.WRT_Name, t1.WRT_Availability, t1.WRT_ResultFunction, t1.WRT_Description,");
            vStringBuilder.AppendLine("t1.WRT_Date, t2.FAN_Key, t2.FAN_Name, t2.FAN_Surname, t3.FED_Key, t3.FED_Name, t4.CEL_Key, t4.CEL_Name");
            vStringBuilder.AppendLine("from   WRT_Workout t1,");
            vStringBuilder.AppendLine("       FAN_Fanatic t2,");
            vStringBuilder.AppendLine("       FED_Federation t3,");
            vStringBuilder.AppendLine("       CEL_Cell t4");
            vStringBuilder.AppendLine("where    t1.FAN_Key = t2.FAN_Key");
            vStringBuilder.AppendLine("and      t1.FED_Key = t3.FED_Key");
            vStringBuilder.AppendLine("and      t1.CEL_Key = t4.CEL_Key");
            return vStringBuilder;
        }
        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="Workout"/> object.
        /// </summary>
        /// <param name="aWorkout">A <see cref="Workout"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(Workout aWorkout, SqlDataReader aSqlDataReader)
        {
            aWorkout.WrtKey = Convert.ToInt32(aSqlDataReader["WRT_Key"]);
            aWorkout.WrtName = Convert.ToString(aSqlDataReader["WRT_Name"]);
            aWorkout.WrtAvailability = Convert.ToInt32(aSqlDataReader["WRT_Availability"]);
            aWorkout.WrtDescription = Convert.ToString(aSqlDataReader["WRT_Description"]);
            aWorkout.WrtOwnerKey = Convert.ToInt32(aSqlDataReader["FAN_Key"]);
            aWorkout.WrtOwnerName = string.Format("{0} {1}", Convert.ToString(aSqlDataReader["FAN_Name"]), Convert.ToString(aSqlDataReader["FAN_Surname"]));
            aWorkout.WrtResultFunction = Convert.ToString(aSqlDataReader["WRT_ResultFunction"]);
            aWorkout.CelKey = Convert.ToInt32(aSqlDataReader["CEL_Key"]);
            aWorkout.CelName = Convert.ToString(aSqlDataReader["CEL_Name"]);
            aWorkout.FedKey = Convert.ToInt32(aSqlDataReader["FED_Key"]);
            aWorkout.FedName = Convert.ToString(aSqlDataReader["FED_Name"]);
            aWorkout.DateCreated = (Convert.ToDateTime(aSqlDataReader["WRT_Date"])).ToLongDateString();
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="Workout"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aWorkout">A <see cref="Workout"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, Workout aWorkout)
        {
            aSqlCommand.Parameters.AddWithValue("@WRTName", aWorkout.WrtName);
            aSqlCommand.Parameters.AddWithValue("@WRTAvailability", aWorkout.WrtAvailability);
            aSqlCommand.Parameters.AddWithValue("@WRTDescription", aWorkout.WrtDescription);
            aSqlCommand.Parameters.AddWithValue("@WRTOwnerKey", aWorkout.WrtOwnerKey);
            aSqlCommand.Parameters.AddWithValue("@WRTResultFunction", aWorkout.WrtResultFunction);
            aSqlCommand.Parameters.AddWithValue("@WRTDateCreated", DateTime.Parse(aWorkout.DateCreated));
            if (aWorkout.CelKey < 1)
            {
                aSqlCommand.Parameters.AddWithValue("@WRTCelKey", DBNull.Value);
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@WRTCelKey", aWorkout.CelKey);
            }
            if (aWorkout.FedKey < 1)
            {
                aSqlCommand.Parameters.AddWithValue("@WRTFedKey", DBNull.Value);
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@WRTFedKey", aWorkout.FedKey);
            }
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>WorkoutList</c> property a <see cref="WorkoutCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="Workout"/>, filtered by the filter properties of the passed <see cref="WorkoutCollection"/>.
        /// </summary>
        /// <param name="aWorkoutCollection">The <see cref="WorkoutCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="WorkoutCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aWorkoutCollection</c> argument is <c>null</c>.</exception>
        public static void Load(WorkoutCollection aWorkoutCollection)
        {
            if (aWorkoutCollection == null)
            {
                throw new ArgumentNullException("aWorkoutCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aWorkoutCollection.IsFiltered)
                {                   
                    if (aWorkoutCollection.WorkoutFilter.WrtFilter.WrtName != null)
                    {
                        vStringBuilder.AppendFormat("where t1.WRT_Name is like '%{0}%", aWorkoutCollection.WorkoutFilter.WrtFilter.WrtName);
                    }
                    if (aWorkoutCollection.WorkoutFilter.WrtFilter.CelKey > 0)
                    {
                        vStringBuilder.AppendLine("and t4.CEL_Key = @CELKey");
                        vSqlCommand.Parameters.AddWithValue("@CELKey", aWorkoutCollection.WorkoutFilter.WrtFilter.CelKey);
                    }
                    if (aWorkoutCollection.WorkoutFilter.WrtFilter.FedKey > 0)
                    {
                        vStringBuilder.AppendFormat("and t3.FED_Key = @FEDKey", aWorkoutCollection.WorkoutFilter.WrtFilter.FedKey);
                    }
                    if (aWorkoutCollection.WorkoutFilter.WrtFilter.WrtOwnerKey > 0)
                    {
                        vStringBuilder.AppendFormat("and t2.FAN_Key = @FANKey", aWorkoutCollection.WorkoutFilter.WrtFilter.WrtOwnerKey);
                    }
                }
                vStringBuilder.AppendLine("order by t1.WRT_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vWorkout = new Workout();
                        DataToObject(vWorkout, vSqlDataReader);
                        aWorkoutCollection.WorkoutList.Add(vWorkout);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load by Key

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Workout"/>, with keys in the <c>aWorkout</c> argument.
        /// </summary>
        /// <param name="aWorkout">A <see cref="Workout"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkout</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(Workout aWorkout)
        {
            if (aWorkout == null)
            {
                throw new ArgumentNullException("aWorkout");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and t1.WRT_Key = @WRTKey");
                vSqlCommand.Parameters.AddWithValue("@WRTKey", aWorkout.WrtKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected Workout not found: WRT_Key = {0}", aWorkout.WrtKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aWorkout, vSqlDataReader);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Workout"/> passed as an argument via Stored Procedure that returns the newly inserted Workout Key 
        /// </summary>
        /// <param name="aWorkout">A <see cref="Workout"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkout</c> argument is <c>null</c>.</exception>
        public static void Insert(Workout aWorkout)
        {
            if (aWorkout == null)
            {
                throw new ArgumentNullException("aWorkout");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into WRT_Workout");
                vStringBuilder.AppendLine("       (WRT_Name,");
                vStringBuilder.AppendLine("        FAN_Key,");
                vStringBuilder.AppendLine("        WRT_Availability,");
                vStringBuilder.AppendLine("        FED_Key,");
                vStringBuilder.AppendLine("        CEL_Key,");
                vStringBuilder.AppendLine("        WRT_Date,");
                vStringBuilder.AppendLine("        WRT_ResultFunction,");
                vStringBuilder.AppendLine("        WRT_Description)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@WRTName,");
                vStringBuilder.AppendLine("        @WRTOwnerKey,");
                vStringBuilder.AppendLine("        @WRTAvailability,");
                vStringBuilder.AppendLine("        @WRTFedKey,");
                vStringBuilder.AppendLine("        @WRTCelKey,");
                vStringBuilder.AppendLine("        @WRTDateCreated,");
                vStringBuilder.AppendLine("        @WRTResultFunction,");
                vStringBuilder.AppendLine("        @WRTDescription)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aWorkout);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aWorkout.WrtKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Workout"/> passed as an argument .
        /// </summary>
        /// <param name="aWorkout">A <see cref="Workout"/>.</param>
        public static void Update(Workout aWorkout)
        {
            if (aWorkout == null)
            {
                throw new ArgumentNullException("aWorkout");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update WRT_Workout");
                vStringBuilder.AppendLine("set    FAN_Key = @WRTOwnerKey,");
                vStringBuilder.AppendLine("       WRT_Availability = @WRTAvailability,");
                vStringBuilder.AppendLine("       FED_Key = @WRTFedKey,");
                vStringBuilder.AppendLine("       CEL_Key = @WRTCelKey,");
                vStringBuilder.AppendLine("       WRT_Date = @WRTDateCreated,");
                vStringBuilder.AppendLine("       WRT_Name = @WRTName,");
                vStringBuilder.AppendLine("       WRT_ResultFunction = @WRTResultFunction,");
                vStringBuilder.AppendLine("       WRT_Description = @WRTDescription");
                vStringBuilder.AppendLine("where  WRT_Key = @WRTKey");
                ObjectToData(vSqlCommand, aWorkout);
                vSqlCommand.Parameters.AddWithValue("@WRTKey", aWorkout.WrtKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Workout"/> object passed as an argument.
        /// </summary>
        /// <param name="aWorkout">The <see cref="Workout"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkout</c> argument is <c>null</c>.</exception>
        public static void Delete(Workout aWorkout)
        {
            if (aWorkout == null)
            {
                throw new ArgumentNullException("aWorkout");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete WRT_Workout");
                vStringBuilder.AppendLine("where  WRT_Key = @WRTKey");
                vSqlCommand.Parameters.AddWithValue("@WRTKey", aWorkout.WrtKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
