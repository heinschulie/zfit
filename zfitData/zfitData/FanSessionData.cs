using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Zephry;

namespace zfit
{
    public class FanSessionData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="FanSession"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.WRT_Key, t1.WRT_Name, t2.FAN_Key, t2.FAN_Name, t2.FAN_Surname, t4.FSS_DateDone");
            vStringBuilder.AppendLine("       t6.CEL_Key, t6.CEL_Name, t5.PRG_Key, t5.PRG_Name, t4.FSS_Lock");
            vStringBuilder.AppendLine("from   WRT_Workout t1, ");
            vStringBuilder.AppendLine("       FAN_Fanatic t2,");
            vStringBuilder.AppendLine("       FAW_FanWorkout t3,");
            vStringBuilder.AppendLine("       FSS_FanSession t4,");
            vStringBuilder.AppendLine("       PRG_Program t5,");
            vStringBuilder.AppendLine("       CEL_Cell t6");
            vStringBuilder.AppendLine("where  t1.WRT_Key = t3.WRT_Key");
            vStringBuilder.AppendLine("and    t3.WRT_Key = t4.WRT_Key");
            vStringBuilder.AppendLine("and    t2.FAN_Key = t3.FAN_Key");
            vStringBuilder.AppendLine("and    t3.FAN_Key = t4.FAN_Key");
            vStringBuilder.AppendLine("and    t5.PRG_Key = t4.PRG_Key");
            vStringBuilder.AppendLine("and    t6.CEL_Key = t4.CEL_Key");

            return vStringBuilder; 
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="FanSession"/> object.
        /// </summary>
        /// <param name="aFanSession">A <see cref="Workout"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(FanSession aFanSession, SqlDataReader aSqlDataReader, bool aIncludeAvatar)
        {
            aFanSession.WrtKey = Convert.ToInt32(aSqlDataReader["WRT_Key"]);
            aFanSession.WrtName = Convert.ToString(aSqlDataReader["WRT_Name"]);
            aFanSession.FanKey = Convert.ToInt32(aSqlDataReader["FAN_Key"]);
            aFanSession.FanName = Convert.ToString(aSqlDataReader["FAN_Name"]);
            aFanSession.FanSurname = Convert.ToString(aSqlDataReader["FAN_Surname"]);
            aFanSession.FssKey = Convert.ToInt32(aSqlDataReader["FSS_Key"]);
            aFanSession.FanSessionDateDone = (Convert.ToDateTime(aSqlDataReader["FSS_DateDone"])).ToLongDateString();
            aFanSession.CelKey = Convert.ToInt32(aSqlDataReader["CEL_Key"]);
            aFanSession.CelName = Convert.ToString(aSqlDataReader["FAN_Surname"]);
            aFanSession.PrgKey = Convert.ToInt32(aSqlDataReader["PRG_Key"]);
            aFanSession.PrgName = Convert.ToString(aSqlDataReader["FAN_Surname"]);
            aFanSession.FssLock = Convert.ToBoolean(aSqlDataReader["FSS_Lock"]);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="FanSession"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aWorkout">A <see cref="FanSession"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, FanSession aFanSession)
        {
            aSqlCommand.Parameters.AddWithValue("@WRTKey", aFanSession.WrtKey);
            aSqlCommand.Parameters.AddWithValue("@FANKey", aFanSession.FanKey);
            aSqlCommand.Parameters.AddWithValue("@CELKey", aFanSession.CelKey);
            aSqlCommand.Parameters.AddWithValue("@FSSLock", aFanSession.FssLock);
            aSqlCommand.Parameters.AddWithValue("@PRGKey", aFanSession.PrgKey);
            aSqlCommand.Parameters.AddWithValue("@WRTFANDateCreated", DateTime.Parse(aFanSession.FanSessionDateDone));
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>FanSessionList</c> property a <see cref="FanSessionCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="FanSession"/>, filtered by the filter properties of the passed <see cref="FanSessionCollection"/>.
        /// </summary>
        /// <param name="aFanSessionCollection">The <see cref="FanSessionCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="FanSessionCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aFanSessionCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanSessionCollection aFanSessionCollection)
        {
            if (aFanSessionCollection == null)
            {
                throw new ArgumentNullException("aFanSessionCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aFanSessionCollection.IsFiltered)
                {
                    if (aFanSessionCollection.FanSessionFilter.FssFilter.WrtKey > 0)
                    {
                        vStringBuilder.AppendLine("and t1.WRT_Key = @WRTKey");
                        vSqlCommand.Parameters.AddWithValue("@WRTKey", aFanSessionCollection.FanSessionFilter.FssFilter.WrtKey);
                    }
                    if (aFanSessionCollection.FanSessionFilter.FssFilter.FanKey > 0)
                    {
                        vStringBuilder.AppendLine("and t2.FAN_Key = @FANKey");
                        vSqlCommand.Parameters.AddWithValue("@FANKey", aFanSessionCollection.FanSessionFilter.FssFilter.FanKey);
                    }
                    if (aFanSessionCollection.FanSessionFilter.FssFilter.WrtName != null)
                    {
                        vStringBuilder.AppendFormat("and t1.WRT_Name like '%{0}%'", aFanSessionCollection.FanSessionFilter.FssFilter.WrtName);
                    }
                    if (aFanSessionCollection.FanSessionFilter.FssFilter.FanName != null)
                    {
                        vStringBuilder.AppendFormat("and t2.FAN_Name like '%{0}%'", aFanSessionCollection.FanSessionFilter.FssFilter.FanName);
                    }
                }
                vStringBuilder.AppendLine("order by t1.WRT_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vFanSession = new FanSession();
                        DataToObject(vFanSession, vSqlDataReader, false);
                        aFanSessionCollection.FanSessionList.Add(vFanSession);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Save
        public static void Save(FanSessionCollection aFanSessionCollection)
        {
            Delete(aFanSessionCollection.FanSessionFilter.FssFilter);
            Insert(aFanSessionCollection);
        }
        #endregion

        #region Load by Key

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="FanSession"/>, with keys in the <c>aFanSession</c> argument.
        /// </summary>
        /// <param name="aFanSession">A <see cref="FanSession"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanSession</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(FanSession aFanSession)
        {
            if (aFanSession == null)
            {
                throw new ArgumentNullException("aFanSession");
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
                vStringBuilder.AppendLine("and t3.FSS_Key = @FSSKey");
                vSqlCommand.Parameters.AddWithValue("@WRTKey", aFanSession.WrtKey);
                vSqlCommand.Parameters.AddWithValue("@FANKey", aFanSession.FanKey);
                vSqlCommand.Parameters.AddWithValue("@FSSKey", aFanSession.FssKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected WorkoutFAN not found: WRT_Key = {0}, FAN_Key = {1}, FSS_Key = {2}", aFanSession.WrtKey, aFanSession.FanKey, aFanSession.FssKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aFanSession, vSqlDataReader, true);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="FanSession"/> passed as an argument via Stored Procedure that returns the newly inserted FanSession Key 
        /// </summary>
        /// <param name="aFanSession">A <see cref="FanSession"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanSession</c> argument is <c>null</c>.</exception>
        public static void Insert(FanSessionCollection aFanSessionCollection)
        {
            if (aFanSessionCollection == null)
            {
                throw new ArgumentNullException("aFanSessionCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into FSS_FanSession");
                vStringBuilder.AppendLine("       (WRT_Key,");
                vStringBuilder.AppendLine("        FAN_Key,");
                vStringBuilder.AppendLine("        CEL_Key,");
                vStringBuilder.AppendLine("        PRG_Key,");
                vStringBuilder.AppendLine("        FSS_Lock,");
                vStringBuilder.AppendLine("        FSS_DateDone)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@WRTKey,");
                vStringBuilder.AppendLine("       (@FANKey,");
                vStringBuilder.AppendLine("       (@CELKey,");
                vStringBuilder.AppendLine("       (@PRGKey,");
                vStringBuilder.AppendLine("       (@FSSLock,");
                vStringBuilder.AppendLine("        @FSSDateDone)");
                vStringBuilder.AppendLine(";");
                vSqlCommand.Parameters.Add("@WRTKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@FANKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@CELKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@PRGKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@FSSLock", SqlDbType.Char);
                vSqlCommand.Parameters.Add("@FAWDateCreated", SqlDbType.DateTime);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aFanSessionCollection.FanSessionList.ForEach(vFanSession =>
                {
                    vSqlCommand.Parameters["@WRTKey"].Value = vFanSession.WrtKey;
                    vSqlCommand.Parameters["@FANKey"].Value = vFanSession.FanKey;
                    vSqlCommand.Parameters["@CELKey"].Value = vFanSession.CelKey;
                    vSqlCommand.Parameters["@PRGKey"].Value = vFanSession.PrgKey;
                    vSqlCommand.Parameters["@FSSLock"].Value = vFanSession.FssLock;
                    vSqlCommand.Parameters["@FSSDateDone"].Value = DateTime.Parse(vFanSession.FanSessionDateDone);
                    vSqlCommand.ExecuteScalar();
                });
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="FanSession"/> passed as an argument .
        /// </summary>
        /// <param name="aFanSession">A <see cref="FanSession"/>.</param>
        public static void Update(FanSession aFanSession)
        {
            if (aFanSession == null)
            {
                throw new ArgumentNullException("aFanSession");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update FAW_FanSession");
                vStringBuilder.AppendLine("set    CEL_Key = @CELKey,");
                vStringBuilder.AppendLine("       PRG_KEY = @PRGKEY,");
                vStringBuilder.AppendLine("       FSS_Lock = @FSSLock,");
                vStringBuilder.AppendLine("       FAW_DateDone = @FAWDateDone");
                vStringBuilder.AppendLine("where  WRT_Key = @WRTKey");
                vStringBuilder.AppendLine("and    FAN_Key = @FANKey");
                vStringBuilder.AppendLine("and    FSS_Key = @FSSKey");
                ObjectToData(vSqlCommand, aFanSession);
                vSqlCommand.Parameters.AddWithValue("@CELKey", aFanSession.CelKey);
                vSqlCommand.Parameters.AddWithValue("@PRG_KEY", aFanSession.PrgKey);
                vSqlCommand.Parameters.AddWithValue("@FSS_Lock", aFanSession.FssLock);
                vSqlCommand.Parameters.AddWithValue("@FAWDateCreated", DateTime.Parse(aFanSession.FanSessionDateDone));
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="FanSession"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanSession">The <see cref="FanSession"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanSession</c> argument is <c>null</c>.</exception>
        public static void Delete(FanSession aFanSession)
        {
            if (aFanSession == null)
            {
                throw new ArgumentNullException("aFanSession");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete FSS_FanSession");
                vStringBuilder.AppendLine("where  WRT_Key = @WRTKey");
                vStringBuilder.AppendLine("and    FAN_Key = @FANKey");
                vStringBuilder.AppendLine("and    FSS_Key = @FSSKey");
                vSqlCommand.Parameters.AddWithValue("@WRTKey", aFanSession.WrtKey);
                vSqlCommand.Parameters.AddWithValue("@FANKey", aFanSession.FanKey);
                vSqlCommand.Parameters.AddWithValue("@FSSKey", aFanSession.FssKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
