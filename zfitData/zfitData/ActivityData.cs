using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Zephry;

namespace zfit
{
    public class ActivityData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="Workout"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.EXC_Key, t1.EXC_Name, t2.WRT_Key, t2.WRT_Name, t3.ACT_Key, t3.ACT_Description, t3.ACT_UnitOfMeasure, t3.ACT_Measure,");
            vStringBuilder.AppendLine("t3.ACT_UnitOfTime, t3.ACT_Time, t3.ACT_Repetitions, t3.ACT_Rest, t3.ACT_ResultType");
            vStringBuilder.AppendLine("from   EXC_Exercise t1,");
            vStringBuilder.AppendLine("       WRT_Workout t2,");
            vStringBuilder.AppendLine("       ACT_Activity t3");
            vStringBuilder.AppendLine("where    t1.EXC_Key = t3.EXC_Key");
            vStringBuilder.AppendLine("and      t2.WRT_Key = t3.WRT_Key");
            return vStringBuilder;
        }
        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="Workout"/> object.
        /// </summary>
        /// <param name="aActivity">A <see cref="Activity"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(Activity aActivity, SqlDataReader aSqlDataReader)
        {
            aActivity.ExcKey = Convert.ToInt32(aSqlDataReader["EXC_Key"]);
            aActivity.WrtKey = Convert.ToInt32(aSqlDataReader["WRT_Key"]);
            aActivity.ActKey = Convert.ToInt32(aSqlDataReader["ACT_Key"]);
            aActivity.ExcName = Convert.ToString(aSqlDataReader["EXC_Name"]);
            aActivity.WrtName = Convert.ToString(aSqlDataReader["WRT_Name"]);
            aActivity.ActDescription = Convert.ToString(aSqlDataReader["ACT_Description"]);
            aActivity.ActUnitOfMeasure = Convert.ToInt32(aSqlDataReader["ACT_UnitOfMeasure"]);
            aActivity.ActMeasure = Convert.ToInt32(aSqlDataReader["ACT_Measure"]);
            aActivity.ActUnitOfTime = Convert.ToInt32(aSqlDataReader["ACT_UnitOfTime"]);
            aActivity.ActTime = Convert.ToInt32(aSqlDataReader["ACT_Time"]);
            aActivity.ActRepetitions = Convert.ToInt32(aSqlDataReader["ACT_Repetitions"]);
            aActivity.ActResultType = Convert.ToInt32(aSqlDataReader["ACT_ResultType"]);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="Activity"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aActivity">A <see cref="Activity"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, Activity aActivity)
        {
            aSqlCommand.Parameters.AddWithValue("@EXCKey", aActivity.ExcKey);
            aSqlCommand.Parameters.AddWithValue("@WRTKey", aActivity.WrtKey);
            aSqlCommand.Parameters.AddWithValue("@ACTDescription", aActivity.ActDescription);
            aSqlCommand.Parameters.AddWithValue("@ACTUnitOfMeasure", aActivity.ActUnitOfMeasure);
            aSqlCommand.Parameters.AddWithValue("@ACTMeasure", aActivity.ActMeasure);
            aSqlCommand.Parameters.AddWithValue("@ACTUnitOfTime", aActivity.ActUnitOfTime);
            aSqlCommand.Parameters.AddWithValue("@ACTTime", aActivity.ActTime);
            aSqlCommand.Parameters.AddWithValue("@ACTRepetitions", aActivity.ActRepetitions);
            aSqlCommand.Parameters.AddWithValue("@ACTResultType", aActivity.ActResultType);

        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>ActivityList</c> property a <see cref="ActivityCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="Activity"/>, filtered by the filter properties of the passed <see cref="ActivityCollection"/>.
        /// </summary>
        /// <param name="aActivityCollection">The <see cref="ActivityCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="ActivityCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aActivityCollection</c> argument is <c>null</c>.</exception>
        public static void Load(ActivityCollection aActivityCollection)
        {
            if (aActivityCollection == null)
            {
                throw new ArgumentNullException("aActivityCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aActivityCollection.IsFiltered)
                {
                    if (aActivityCollection.ActivityFilter.ActFilter.ExcKey > 0)
                    {
                        vStringBuilder.AppendLine("and t1.EXC_Key = @EXCKey");
                        vSqlCommand.Parameters.AddWithValue("@EXCKey", aActivityCollection.ActivityFilter.ActFilter.ExcKey);
                    }
                    if (aActivityCollection.ActivityFilter.ActFilter.WrtKey > 0)
                    {
                        vStringBuilder.AppendLine("and t2.WRT_Key = @WRTKey");
                        vSqlCommand.Parameters.AddWithValue("@WRTKey", aActivityCollection.ActivityFilter.ActFilter.WrtKey);
                    }
                    if (aActivityCollection.ActivityFilter.ActFilter.ActUnitOfMeasure > 0)
                    {
                        vStringBuilder.AppendFormat("and t3.ACT_UnitOfMeasure = @ACTUnitOfMeasure");
                        vSqlCommand.Parameters.AddWithValue("@ACTUnitOfMeasure", aActivityCollection.ActivityFilter.ActFilter.ActUnitOfMeasure);
                    }
                    if (aActivityCollection.ActivityFilter.ActFilter.ActUnitOfTime > 0)
                    {
                        vStringBuilder.AppendFormat("and t3.ACT_UnitOfTime = @ACTUnitOfTime");
                        vSqlCommand.Parameters.AddWithValue("@ACTUnitOfTime", aActivityCollection.ActivityFilter.ActFilter.ActUnitOfTime);
                    }
                }
                vStringBuilder.AppendLine("order by t3.ACT_Key");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vActivity = new Activity();
                        DataToObject(vActivity, vSqlDataReader);
                        aActivityCollection.ActivityList.Add(vActivity);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load by Key

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Activity"/>, with keys in the <c>aActivity</c> argument.
        /// </summary>
        /// <param name="aActivity">A <see cref="Activity"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aActivity</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(Activity aActivity)
        {
            if (aActivity == null)
            {
                throw new ArgumentNullException("aActivity");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and t1.EXC_Key = @EXCKey");
                vStringBuilder.AppendLine("and t2.WRT_Key = @WRTKey");
                vStringBuilder.AppendLine("and t3.ACT_Key = @ACTKey");
                vSqlCommand.Parameters.AddWithValue("@EXCKey", aActivity.ExcKey);
                vSqlCommand.Parameters.AddWithValue("@WRTKey", aActivity.WrtKey);
                vSqlCommand.Parameters.AddWithValue("@ACTKey", aActivity.ActKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected Activity not found: EXC_Key = {0}, WRT_Key = {1}, ACT_Key = {2}", aActivity.ExcKey, aActivity.WrtKey, aActivity.ActKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aActivity, vSqlDataReader);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Activity"/> passed as an argument via Stored Procedure that returns the newly inserted Activity Key 
        /// </summary>
        /// <param name="aActivity">A <see cref="Activity"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aActivity</c> argument is <c>null</c>.</exception>
        public static void Insert(Activity aActivity)
        {
            if (aActivity == null)
            {
                throw new ArgumentNullException("aActivity");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into ACT_Activity");
                vStringBuilder.AppendLine("       (EXC_Key,");
                vStringBuilder.AppendLine("        WRT_Key,");
                vStringBuilder.AppendLine("        ACT_Description,");
                vStringBuilder.AppendLine("        ACT_UnitOfMeasure,");
                vStringBuilder.AppendLine("        ACT_Measure,");
                vStringBuilder.AppendLine("        ACT_UnitOfTime,");
                vStringBuilder.AppendLine("        ACT_Time,");
                vStringBuilder.AppendLine("        ACT_Repetitions,");
                vStringBuilder.AppendLine("        ACT_ResultType)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@EXCKey,");
                vStringBuilder.AppendLine("        @WRTKey,");
                vStringBuilder.AppendLine("        @ACTDescription,");
                vStringBuilder.AppendLine("        @ACTUnitOfMeasure,");
                vStringBuilder.AppendLine("        @ACTMeasure,");
                vStringBuilder.AppendLine("        @ACTUnitOfTime,");
                vStringBuilder.AppendLine("        @ACTTime,");
                vStringBuilder.AppendLine("        @ACTRepetitions,");
                vStringBuilder.AppendLine("        @ACTResultType)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aActivity);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aActivity.ActKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Activity"/> passed as an argument .
        /// </summary>
        /// <param name="aActivity">A <see cref="Activity"/>.</param>
        public static void Update(Activity aActivity)
        {
            if (aActivity == null)
            {
                throw new ArgumentNullException("aActivity");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update ACT_Activity");
                vStringBuilder.AppendLine("set    EXC_Key = @EXCKey,");
                vStringBuilder.AppendLine("       WRT_Key = @WRTKey,");
                vStringBuilder.AppendLine("       ACT_Description = @ACTDescription,");
                vStringBuilder.AppendLine("       ACT_UnitOfMeasure = @ACTUnitOfMeasure,");
                vStringBuilder.AppendLine("       ACT_Measure = @ACTMeasure,");
                vStringBuilder.AppendLine("       ACT_UnitOfTime = @ACTUnitOfTime,");
                vStringBuilder.AppendLine("       ACT_Time = @ACTTime,");
                vStringBuilder.AppendLine("       ACT_Repetitions = @ACTRepetitions,");
                vStringBuilder.AppendLine("       ACT_ResultType = @ACTResultType");
                vStringBuilder.AppendLine("where  EXC_Key = @EXCKey");
                vStringBuilder.AppendLine("and    WRT_Key = @WRTKey");
                vStringBuilder.AppendLine("and    ACT_Key = @ACTKey");
                ObjectToData(vSqlCommand, aActivity);
                vSqlCommand.Parameters.AddWithValue("@ACTKey", aActivity.ActKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Activity"/> object passed as an argument.
        /// </summary>
        /// <param name="aActivity">The <see cref="Activity"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkout</c> argument is <c>null</c>.</exception>
        public static void Delete(Activity aActivity)
        {
            if (aActivity == null)
            {
                throw new ArgumentNullException("aActivity");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete ACT_Activity");
                vStringBuilder.AppendLine("where  EXC_Key = @EXCKey");
                vStringBuilder.AppendLine("and    WRT_Key = @WRTKey");
                vStringBuilder.AppendLine("and    ACT_Key = @ACTKey");
                vSqlCommand.Parameters.AddWithValue("@EXCKey", aActivity.ExcKey);
                vSqlCommand.Parameters.AddWithValue("@WRTKey", aActivity.WrtKey);
                vSqlCommand.Parameters.AddWithValue("@ACTKey", aActivity.ActKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
