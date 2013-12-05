using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Zephry;

namespace zfit
{
    public class FanSessionActivityData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="FanSessionActivity"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t2.WRT_Key, t2.FAN_Key, t2.FSS_Key, t1.EXC_Key, t1.ACT_Key, t3.FSA_Result");
            vStringBuilder.AppendLine("from   ACT_Activity t1, ");
            vStringBuilder.AppendLine("       FSS_FanSession t2,");
            vStringBuilder.AppendLine("       FSA_FanSessionActivity t3");
            vStringBuilder.AppendLine("where  t1.EXC_Key = t3.EXC_Key");
            vStringBuilder.AppendLine("and    t1.ACT_Key = t3.ACT_Key");
            vStringBuilder.AppendLine("and    t2.FAN_Key = t3.FAN_Key");
            vStringBuilder.AppendLine("and    t2.FSS_Key = t3.FSS_Key");
            vStringBuilder.AppendLine("and    t2.WRT_Key = t3.WRT_Key");

            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="FanSessionActivity"/> object.
        /// </summary>
        /// <param name="aFanSessionActivity">A <see cref="FanSessionActivity"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(FanSessionActivity aFanSessionActivity, SqlDataReader aSqlDataReader, bool aIncludeAvatar)
        {
            aFanSessionActivity.WrtKey = Convert.ToInt32(aSqlDataReader["WRT_Key"]);
            aFanSessionActivity.FanKey = Convert.ToInt32(aSqlDataReader["FAN_Key"]);
            aFanSessionActivity.FssKey = Convert.ToInt32(aSqlDataReader["FSS_Key"]);  
            aFanSessionActivity.ExcKey = Convert.ToInt32(aSqlDataReader["EXC_Key"]); 
            aFanSessionActivity.ActKey = Convert.ToInt32(aSqlDataReader["ACT_Key"]);   
            aFanSessionActivity.FsaResult = Convert.ToString(aSqlDataReader["FSA_Result"]);           
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="FanSessionActivity"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aWorkout">A <see cref="FanSessionActivity"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, FanSessionActivity aFanSessionActivity)
        {
            aSqlCommand.Parameters.AddWithValue("@WRTKey", aFanSessionActivity.WrtKey);
            aSqlCommand.Parameters.AddWithValue("@FANKey", aFanSessionActivity.FanKey);
            aSqlCommand.Parameters.AddWithValue("@FSSKey", aFanSessionActivity.FssKey);
            aSqlCommand.Parameters.AddWithValue("@EXCKey", aFanSessionActivity.ExcKey);
            aSqlCommand.Parameters.AddWithValue("@ACTKey", aFanSessionActivity.ActKey);
            aSqlCommand.Parameters.AddWithValue("@FSAResult", aFanSessionActivity.FsaResult); 
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>FanSessionActivityList</c> property a <see cref="FanSessionActivityCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="FanSessionActivity"/>, filtered by the filter properties of the passed <see cref="FanSessionActivityCollection"/>.
        /// </summary>
        /// <param name="aFanSessionActivityCollection">The <see cref="FanSessionActivityCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="FanSessionActivityCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aFanSessionActivityCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanSessionActivityCollection aFanSessionActivityCollection)
        {
            if (aFanSessionActivityCollection == null)
            {
                throw new ArgumentNullException("aFanSessionActivityCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aFanSessionActivityCollection.IsFiltered)
                {
                    if (aFanSessionActivityCollection.FanSessionActivityFilter.FsaFilter.WrtKey > 0)
                    {
                        vStringBuilder.AppendLine("and t2.WRT_Key = @WRTKey");
                        vSqlCommand.Parameters.AddWithValue("@WRTKey", aFanSessionActivityCollection.FanSessionActivityFilter.FsaFilter.WrtKey);
                    }
                    if (aFanSessionActivityCollection.FanSessionActivityFilter.FsaFilter.FanKey > 0)
                    {
                        vStringBuilder.AppendLine("and t2.FAN_Key = @FANKey");
                        vSqlCommand.Parameters.AddWithValue("@FANKey", aFanSessionActivityCollection.FanSessionActivityFilter.FsaFilter.FanKey);
                    }
                    if (aFanSessionActivityCollection.FanSessionActivityFilter.FsaFilter.FssKey > 0)
                    {
                        vStringBuilder.AppendLine("and t2.FSS_Key = @FSSKey");
                        vSqlCommand.Parameters.AddWithValue("@FSSKey", aFanSessionActivityCollection.FanSessionActivityFilter.FsaFilter.FssKey);
                    }
                    if (aFanSessionActivityCollection.FanSessionActivityFilter.FsaFilter.ActKey > 0)
                    {
                        vStringBuilder.AppendLine("and t1.ACT_Key = @ACTKey");
                        vSqlCommand.Parameters.AddWithValue("@ACTKey", aFanSessionActivityCollection.FanSessionActivityFilter.FsaFilter.ActKey);
                    }
                    if (aFanSessionActivityCollection.FanSessionActivityFilter.FsaFilter.ExcKey > 0)
                    {
                        vStringBuilder.AppendLine("and t1.EXC_Key = @EXCKey");
                        vSqlCommand.Parameters.AddWithValue("@EXCKey", aFanSessionActivityCollection.FanSessionActivityFilter.FsaFilter.ExcKey);
                    }
                }
                vStringBuilder.AppendLine("order by t2.FSS_Key");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vFanSessionActivity = new FanSessionActivity();
                        DataToObject(vFanSessionActivity, vSqlDataReader, false);
                        aFanSessionActivityCollection.FanSessionActivityList.Add(vFanSessionActivity);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Save
        public static void Save(FanSessionActivityCollection aFanSessionActivityCollection)
        {
            Delete(aFanSessionActivityCollection.FanSessionActivityFilter.FsaFilter);
            Insert(aFanSessionActivityCollection);
        }
        #endregion

        #region Load by Key

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="FanSessionActivity"/>, with keys in the <c>aFanSessionActivity</c> argument.
        /// </summary>
        /// <param name="aFanSessionActivity">A <see cref="FanSessionActivity"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanSessionActivity</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(FanSessionActivity aFanSessionActivity)
        {
            if (aFanSessionActivity == null)
            {
                throw new ArgumentNullException("aFanSessionActivity");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and t2.WRT_Key = @WRTKey");
                vStringBuilder.AppendLine("and t2.FAN_Key = @FANKey");
                vStringBuilder.AppendLine("and t2.FSS_Key = @FSSKey");
                vStringBuilder.AppendLine("and t1.EXC_Key = @EXCKey");
                vStringBuilder.AppendLine("and t1.ACT_Key = @ACTKey");
                vSqlCommand.Parameters.AddWithValue("@WRTKey", aFanSessionActivity.WrtKey);
                vSqlCommand.Parameters.AddWithValue("@FANKey", aFanSessionActivity.FanKey);
                vSqlCommand.Parameters.AddWithValue("@FSSKey", aFanSessionActivity.FssKey);
                vSqlCommand.Parameters.AddWithValue("@EXCKey", aFanSessionActivity.ExcKey);
                vSqlCommand.Parameters.AddWithValue("@ACTKey", aFanSessionActivity.ActKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected FanSessionActivity not found: WRT_Key = {0}, FAN_Key = {1}, FSS_Key = {2}, EXC_Key = {3}, ACT_Key = {4}", aFanSessionActivity.WrtKey, aFanSessionActivity.FanKey, aFanSessionActivity.FssKey, aFanSessionActivity.ExcKey, aFanSessionActivity.ActKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aFanSessionActivity, vSqlDataReader, true);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="FanSessionActivity"/> passed as an argument via Stored Procedure that returns the newly inserted FanSessionActivity Key 
        /// </summary>
        /// <param name="aFanSessionActivity">A <see cref="FanSessionActivity"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanSessionActivity</c> argument is <c>null</c>.</exception>
        public static void Insert(FanSessionActivity aFanSessionActivity)
        {
            if (aFanSessionActivity == null)
            {
                throw new ArgumentNullException("aFanSessionActivity");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into FSA_FanSessionActivity");
                vStringBuilder.AppendLine("       (FAN_Key,");
                vStringBuilder.AppendLine("        WRT_Key,");
                vStringBuilder.AppendLine("        EXC_Key,");
                vStringBuilder.AppendLine("        ACT_Key,");
                vStringBuilder.AppendLine("        FSA_Result)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@FANKey,");
                vStringBuilder.AppendLine("        @WRTKey,");
                vStringBuilder.AppendLine("        @EXCKey,");
                vStringBuilder.AppendLine("        @ACTKey,");
                vStringBuilder.AppendLine("        @FSAResult)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aFanSessionActivity);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aFanSessionActivity.FssKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert Collection

        /// <summary>
        ///   Insert a <see cref="FanSessionActivity"/> passed as an argument via Stored Procedure that returns the newly inserted FanSessionActivity Key 
        /// </summary>
        /// <param name="aFanSessionActivity">A <see cref="FanSessionActivity"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanSessionActivity</c> argument is <c>null</c>.</exception>
        public static void Insert(FanSessionActivityCollection aFanSessionActivityCollection)
        {
            if (aFanSessionActivityCollection == null)
            {
                throw new ArgumentNullException("aFanSessionActivityCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into FSA_FanSessionActivity");
                vStringBuilder.AppendLine("       (FAN_Key,");
                vStringBuilder.AppendLine("        WRT_Key,");
                vStringBuilder.AppendLine("        EXC_Key,");
                vStringBuilder.AppendLine("        ACT_Key,");
                vStringBuilder.AppendLine("        FSA_Result)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@FANKey,");
                vStringBuilder.AppendLine("        @WRTKey,");
                vStringBuilder.AppendLine("        @EXCKey,");
                vStringBuilder.AppendLine("        @ACTKey,");
                vStringBuilder.AppendLine("        @FSAResult)");
                vStringBuilder.AppendLine(";");
                vSqlCommand.Parameters.Add("@FANKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@WRTKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@EXCKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@ACTKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@FSAResult", SqlDbType.NVarChar);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aFanSessionActivityCollection.FanSessionActivityList.ForEach(vFanSessionActivity =>
                {
                    vSqlCommand.Parameters["@FANKey"].Value = vFanSessionActivity.WrtKey;
                    vSqlCommand.Parameters["@WRTKey"].Value = vFanSessionActivity.FanKey;
                    vSqlCommand.Parameters["@EXCKey"].Value = vFanSessionActivity.ExcKey;
                    vSqlCommand.Parameters["@ACTKey"].Value = vFanSessionActivity.ActKey;
                    vSqlCommand.Parameters["@FSAResult"].Value = vFanSessionActivity.FsaResult;
                    vSqlCommand.ExecuteScalar();
                });
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="FanSessionActivity"/> passed as an argument .
        /// </summary>
        /// <param name="aFanSessionActivity">A <see cref="FanSessionActivity"/>.</param>
        public static void Update(FanSessionActivity aFanSessionActivity)
        {
            if (aFanSessionActivity == null)
            {
                throw new ArgumentNullException("aFanSessionActivity");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update FSS_FanSession");
                vStringBuilder.AppendLine("set    FSA_Result = @FSAResult");
                vStringBuilder.AppendLine("where  WRT_Key = @WRTKey");
                vStringBuilder.AppendLine("and    FAN_Key = @FANKey");
                vStringBuilder.AppendLine("and    FSS_Key = @FSSKey");
                vStringBuilder.AppendLine("and    EXC_Key = @EXCKey");
                vStringBuilder.AppendLine("and    ACT_Key = @ACTKey");
                ObjectToData(vSqlCommand, aFanSessionActivity);
                vSqlCommand.Parameters.AddWithValue("@FSSKey", aFanSessionActivity.FssKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();

            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="FanSessionActivity"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanSessionActivity">The <see cref="FanSessionActivity"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanSessionActivity</c> argument is <c>null</c>.</exception>
        public static void Delete(FanSessionActivityKey aFanSessionActivityKey)
        {
            if (aFanSessionActivityKey == null)
            {
                throw new ArgumentNullException("aFanSessionActivityKey");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete FSA_FanSessionActivity");
                vStringBuilder.AppendLine("where  WRT_Key = @WRTKey");
                vStringBuilder.AppendLine("and    FAN_Key = @FANKey");
                vStringBuilder.AppendLine("and    FSS_Key = @FSSKey");
                vStringBuilder.AppendLine("and    EXC_Key = @EXCKey");
                vStringBuilder.AppendLine("and    ACT_Key = @ACTKey");
                vSqlCommand.Parameters.AddWithValue("@WRTKey", aFanSessionActivityKey.WrtKey);
                vSqlCommand.Parameters.AddWithValue("@FANKey", aFanSessionActivityKey.FanKey);
                vSqlCommand.Parameters.AddWithValue("@FSSKey", aFanSessionActivityKey.FssKey);
                vSqlCommand.Parameters.AddWithValue("@EXCKey", aFanSessionActivityKey.ExcKey);
                vSqlCommand.Parameters.AddWithValue("@ACTKey", aFanSessionActivityKey.ActKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
