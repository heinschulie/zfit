using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   FanRoleData class.
    /// </summary>
    public class FanRoleData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="FanRole"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.FAN_Key, t1.FAN_Name + ' ' + t1.FAN_Surname as FAN_DisplayName, t0.ROL_key");
            vStringBuilder.AppendLine("from   FAN_Fan t1");
            //!!!!!!!!!!!!------------Edit Statement------------!!!!!!!!!!!!
            vStringBuilder.AppendLine("where  t1.FAN_Key = t2.FAN_Key");
            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="FanRole"/> object.
        /// </summary>
        /// <param name="aFanRole">A <see cref="FanRole"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(FanRole aFanRole, SqlDataReader aSqlDataReader)
        {
            aFanRole.FanKey = Convert.ToInt32(aSqlDataReader["FAN_Key"]);
            aFanRole.FanDisplayName = Convert.ToString(aSqlDataReader["FAN_DisplayName"]);
            aFanRole.Rolkey = Convert.ToInt32(aSqlDataReader["ROL_key"]);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="FanRole"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aFanRole">A <see cref="FanRole"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, FanRole aFanRole)
        {
            aSqlCommand.Parameters.AddWithValue("@FANKey", aFanRole.FanKey);
            aSqlCommand.Parameters.AddWithValue("@ROLkey", aFanRole.Rolkey);
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>FanRoleList</c> property a <see cref="FanRoleCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="FanRole"/>, filtered by the filter properties of the passed <see cref="FanRoleCollection"/>.
        /// </summary>
        /// <param name="aFanRoleCollection">The <see cref="FanRoleCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="FanRoleCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aFanRoleCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanRoleCollection aFanRoleCollection)
        {
            if (aFanRoleCollection == null)
            {
                throw new ArgumentNullException("aFanRoleCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aFanRoleCollection.IsFiltered)
                {
                    if (aFanRoleCollection.FanKeyFilter > 0)
                    {
                        vStringBuilder.AppendLine("and    t1.FAN_Key = @FANKey");
                        vSqlCommand.Parameters.AddWithValue("@FANKey", aFanRoleCollection.FanKeyFilter);
                    }
                }
                vStringBuilder.AppendLine("order by t2.FRL_Key");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vFanRole = new FanRole();
                        DataToObject(vFanRole, vSqlDataReader);
                        aFanRoleCollection.FanRoleList.Add(vFanRole);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="FanRole"/>, with keys in the <c>aFanRole</c> argument.
        /// </summary>
        /// <param name="aFanRole">A <see cref="FanRole"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanRole</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(FanRole aFanRole)
        {
            if (aFanRole == null)
            {
                throw new ArgumentNullException("aFanRole");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and    t1.FAN_Key = @FANKey");
                vSqlCommand.Parameters.AddWithValue("@FANKey", aFanRole.FanKey);
                vStringBuilder.AppendLine("and    t0.ROL_key = @ROLkey");
                vSqlCommand.Parameters.AddWithValue("@ROLkey", aFanRole.Rolkey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected FanRole not found: FAN_Key = {0}, ROL_key = {1}", aFanRole.FanKey, aFanRole.Rolkey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aFanRole, vSqlDataReader);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="FanRole"/> passed as an argument via Stored Procedure that returns the newly inserted FanRole Key 
        /// </summary>
        /// <param name="aFanRole">A <see cref="FanRole"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanRole</c> argument is <c>null</c>.</exception>
        public static void Insert(FanRole aFanRole)
        {
            if (aFanRole == null)
            {
                throw new ArgumentNullException("aFanRole");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into FRL_FanRole");
                vStringBuilder.AppendLine("       (FAN_Key, ROL_key)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@FANKey, @ROLkey)");
                ObjectToData(vSqlCommand, aFanRole);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="FanRole"/> passed as an argument .
        /// </summary>
        /// <param name="aFanRole">A <see cref="FanRole"/>.</param>
        public static void Update(FanRole aFanRole)
        {
//            if (aFanRole == null)
//            {
//                throw new ArgumentNullException("aFanRole");
//            }
//            using (var vSqlCommand = new SqlCommand()
//            {
//                CommandType = CommandType.Text,
//                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
//            })
//            {
//                var vStringBuilder = new StringBuilder();
//                vStringBuilder.AppendLine("update FRL_FanRole");
//");
//                vStringBuilder.AppendLine("where  FAN_Key = @FANKey");
//                vStringBuilder.AppendLine("and    ROL_key = @ROLkey");
//                ObjectToData(vSqlCommand, aFanRole);
//                vSqlCommand.CommandText = vStringBuilder.ToString();
//                vSqlCommand.Connection.Open();
//                vSqlCommand.ExecuteNonQuery();
//                vSqlCommand.Connection.Close();
//            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="FanRole"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanRole">The <see cref="FanRole"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanRole</c> argument is <c>null</c>.</exception>
        public static void Delete(FanRole aFanRole)
        {
            if (aFanRole == null)
            {
                throw new ArgumentNullException("aFanRole");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete FRL_FanRole");
                vStringBuilder.AppendLine("where  FAN_Key = @FANKey");
                vSqlCommand.Parameters.AddWithValue("@FANKey", aFanRole.FanKey);
                vStringBuilder.AppendLine("and    ROL_key = @ROLkey");
                vSqlCommand.Parameters.AddWithValue("@ROLkey", aFanRole.Rolkey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
     }
 }