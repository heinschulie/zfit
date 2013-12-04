using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Zephry;

namespace zfit
{
    public class FanWorkoutData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="FanWorkout"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.WRT_Key, t1.WRT_Name, t2.FAN_Key, t2.FAN_Name, t2.FAN_Surname, t3.FAW_DateCreated");
            vStringBuilder.AppendLine("from   WRT_Workout t1, ");
            vStringBuilder.AppendLine("       FAN_Fanatic t2,");
            vStringBuilder.AppendLine("       FAW_FanWorkout t3");
            vStringBuilder.AppendLine("where  t1.WRT_Key = t3.WRT_Key");
            vStringBuilder.AppendLine("and    t2.FAN_Key = t3.FAN_Key");

            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="FanWorkout"/> object.
        /// </summary>
        /// <param name="aFanWorkout">A <see cref="Workout"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(FanWorkout aFanWorkout, SqlDataReader aSqlDataReader, bool aIncludeAvatar)
        {
            aFanWorkout.WrtKey = Convert.ToInt32(aSqlDataReader["WRT_Key"]);
            aFanWorkout.WrtName = Convert.ToString(aSqlDataReader["WRT_Name"]);
            aFanWorkout.FanKey = Convert.ToInt32(aSqlDataReader["FAN_Key"]);
            aFanWorkout.FanName = Convert.ToString(aSqlDataReader["FAN_Name"]);
            aFanWorkout.FanSurname = Convert.ToString(aSqlDataReader["FAN_Surname"]);
            aFanWorkout.FanWorkoutDateCreated = (Convert.ToDateTime(aSqlDataReader["FAW_DateCreated"])).ToLongDateString();
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="FanWorkout"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aWorkout">A <see cref="FanWorkout"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, FanWorkout aFanWorkout)
        {
            aSqlCommand.Parameters.AddWithValue("@WRTKey", aFanWorkout.WrtKey);
            aSqlCommand.Parameters.AddWithValue("@FANKey", aFanWorkout.FanKey);
            aSqlCommand.Parameters.AddWithValue("@WRTFANDateCreated", DateTime.Parse(aFanWorkout.FanWorkoutDateCreated));
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>FanWorkoutList</c> property a <see cref="FanWorkoutCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="FanWorkout"/>, filtered by the filter properties of the passed <see cref="FanWorkoutCollection"/>.
        /// </summary>
        /// <param name="aFanWorkoutCollection">The <see cref="FanWorkoutCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="FanWorkoutCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aFanWorkoutCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanWorkoutCollection aFanWorkoutCollection)
        {
            if (aFanWorkoutCollection == null)
            {
                throw new ArgumentNullException("aFanWorkoutCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aFanWorkoutCollection.IsFiltered)
                {
                    if (aFanWorkoutCollection.FanWorkoutFilter.FawFilter.WrtKey > 0)
                    {
                        vStringBuilder.AppendLine("and t1.WRT_Key = @WRTKey");
                        vSqlCommand.Parameters.AddWithValue("@WRTKey", aFanWorkoutCollection.FanWorkoutFilter.FawFilter.WrtKey);
                    }
                    if (aFanWorkoutCollection.FanWorkoutFilter.FawFilter.FanKey > 0)
                    {
                        vStringBuilder.AppendLine("and t2.FAN_Key = @FANKey");
                        vSqlCommand.Parameters.AddWithValue("@FANKey", aFanWorkoutCollection.FanWorkoutFilter.FawFilter.FanKey);
                    }
                    if (aFanWorkoutCollection.FanWorkoutFilter.FawFilter.WrtName != null)
                    {
                        vStringBuilder.AppendFormat("and t1.WRT_Name like '%{0}%'", aFanWorkoutCollection.FanWorkoutFilter.FawFilter.WrtName);
                    }
                    if (aFanWorkoutCollection.FanWorkoutFilter.FawFilter.FanName != null)
                    {
                        vStringBuilder.AppendFormat("and t2.FAN_Name like '%{0}%'", aFanWorkoutCollection.FanWorkoutFilter.FawFilter.FanName);
                    }
                }
                vStringBuilder.AppendLine("order by t1.WRT_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vFanWorkout = new FanWorkout();
                        DataToObject(vFanWorkout, vSqlDataReader, false);
                        aFanWorkoutCollection.FanWorkoutList.Add(vFanWorkout);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Save
        public static void Save(FanWorkoutCollection aFanWorkoutCollection)
        {
            Delete(aFanWorkoutCollection.FanWorkoutFilter.FawFilter);
            Insert(aFanWorkoutCollection);
        }
        #endregion

        #region Load by Key

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="FanWorkout"/>, with keys in the <c>aFanWorkout</c> argument.
        /// </summary>
        /// <param name="aFanWorkout">A <see cref="FanWorkout"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanWorkout</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(FanWorkout aFanWorkout)
        {
            if (aFanWorkout == null)
            {
                throw new ArgumentNullException("aFanWorkout");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and t1.WRT_Key = @WRTKey");
                vStringBuilder.AppendLine("and t2.FAN_Key = @FANKey");
                vSqlCommand.Parameters.AddWithValue("@WRTKey", aFanWorkout.WrtKey);
                vSqlCommand.Parameters.AddWithValue("@FANKey", aFanWorkout.FanKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected WorkoutFAN not found: WRT_Key = {0}, FAN_Key = {1}", aFanWorkout.WrtKey, aFanWorkout.FanKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aFanWorkout, vSqlDataReader, true);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="FanWorkout"/> passed as an argument via Stored Procedure that returns the newly inserted FanWorkout Key 
        /// </summary>
        /// <param name="aFanWorkout">A <see cref="FanWorkout"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanWorkout</c> argument is <c>null</c>.</exception>
        public static void Insert(FanWorkoutCollection aFanWorkoutCollection)
        {
            if (aFanWorkoutCollection == null)
            {
                throw new ArgumentNullException("aFanWorkoutCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into FAW_FanWorkout");
                vStringBuilder.AppendLine("       (WRT_Key, FAN_Key,");
                vStringBuilder.AppendLine("        FAW_DateCreated)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@WRTKey, @FANKey,");
                vStringBuilder.AppendLine("        @FAWDateCreated)");
                vStringBuilder.AppendLine(";");
                vSqlCommand.Parameters.Add("@WRTKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@FANKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@FAWDateCreated", SqlDbType.DateTime);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aFanWorkoutCollection.FanWorkoutList.ForEach(vFanWorkout =>
                {
                    vSqlCommand.Parameters["@WRTKey"].Value = vFanWorkout.WrtKey;
                    vSqlCommand.Parameters["@FANKey"].Value = vFanWorkout.FanKey;
                    vSqlCommand.Parameters["@FAWDateCreated"].Value = DateTime.Parse(vFanWorkout.FanWorkoutDateCreated);
                    vSqlCommand.ExecuteScalar();
                });
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="FanWorkout"/> passed as an argument .
        /// </summary>
        /// <param name="aFanWorkout">A <see cref="FanWorkout"/>.</param>
        public static void Update(FanWorkout aFanWorkout)
        {
            if (aFanWorkout == null)
            {
                throw new ArgumentNullException("aFanWorkout");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update FAW_FanWorkout");
                vStringBuilder.AppendLine("set    FAW_DateCreated = @FAWDateCreated");
                vStringBuilder.AppendLine("where  WRT_Key = @WRTKey");
                vStringBuilder.AppendLine("and    FAN_Key = @FANKey");
                ObjectToData(vSqlCommand, aFanWorkout);
                vSqlCommand.Parameters.AddWithValue("@FAWDateCreated", aFanWorkout.FanWorkoutDateCreated);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="FanWorkout"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanWorkout">The <see cref="FanWorkout"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanWorkout</c> argument is <c>null</c>.</exception>
        public static void Delete(FanWorkout aFanWorkout)
        {
            if (aFanWorkout == null)
            {
                throw new ArgumentNullException("aFanWorkout");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete FAW_FanWorkout");
                if (aFanWorkout.WrtKey > 0 && aFanWorkout.FanKey > 0)
                {
                    vStringBuilder.AppendLine("where  WRT_Key = @WRTKey");
                    vStringBuilder.AppendLine("and    FAN_Key = @FANKey");
                }
                else if (aFanWorkout.WrtKey > 0)
                {
                    vStringBuilder.AppendLine("where  WRT_Key = @WRTKey");
                }
                else if (aFanWorkout.FanKey > 0)
                {
                    vStringBuilder.AppendLine("where  FAN_Key = @FANKey");
                }
                vSqlCommand.Parameters.AddWithValue("@WRTKey", aFanWorkout.WrtKey);
                vSqlCommand.Parameters.AddWithValue("@FANKey", aFanWorkout.FanKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
