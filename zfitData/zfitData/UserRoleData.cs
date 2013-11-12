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
    ///   UserRoleData class.
    /// </summary>
    public class UserRoleData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="UserRole"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.USR_Key, t1.USR_Name + ' ' + t1.USR_Surname as USR_DisplayName, t0.ROL_key");
            vStringBuilder.AppendLine("from   USR_User t1");
            //!!!!!!!!!!!!------------Edit Statement------------!!!!!!!!!!!!
            vStringBuilder.AppendLine("where  t1.USR_Key = t2.USR_Key");
            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="UserRole"/> object.
        /// </summary>
        /// <param name="aUserRole">A <see cref="UserRole"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(UserRole aUserRole, SqlDataReader aSqlDataReader)
        {
            aUserRole.UsrKey = Convert.ToInt32(aSqlDataReader["USR_Key"]);
            aUserRole.UsrDisplayName = Convert.ToString(aSqlDataReader["USR_DisplayName"]);
            aUserRole.Rolkey = Convert.ToInt32(aSqlDataReader["ROL_key"]);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="UserRole"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aUserRole">A <see cref="UserRole"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, UserRole aUserRole)
        {
            aSqlCommand.Parameters.AddWithValue("@USRKey", aUserRole.UsrKey);
            aSqlCommand.Parameters.AddWithValue("@ROLkey", aUserRole.Rolkey);
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>UserRoleList</c> property a <see cref="UserRoleCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="UserRole"/>, filtered by the filter properties of the passed <see cref="UserRoleCollection"/>.
        /// </summary>
        /// <param name="aUserRoleCollection">The <see cref="UserRoleCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="UserRoleCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aUserRoleCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserRoleCollection aUserRoleCollection)
        {
            if (aUserRoleCollection == null)
            {
                throw new ArgumentNullException("aUserRoleCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aUserRoleCollection.IsFiltered)
                {
                    if (aUserRoleCollection.UserKeyFilter > 0)
                    {
                        vStringBuilder.AppendLine("and    t1.USR_Key = @USRKey");
                        vSqlCommand.Parameters.AddWithValue("@USRKey", aUserRoleCollection.UserKeyFilter);
                    }
                }
                vStringBuilder.AppendLine("order by t2.URL_Key");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vUserRole = new UserRole();
                        DataToObject(vUserRole, vSqlDataReader);
                        aUserRoleCollection.UserRoleList.Add(vUserRole);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="UserRole"/>, with keys in the <c>aUserRole</c> argument.
        /// </summary>
        /// <param name="aUserRole">A <see cref="UserRole"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aUserRole</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(UserRole aUserRole)
        {
            if (aUserRole == null)
            {
                throw new ArgumentNullException("aUserRole");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and    t1.USR_Key = @USRKey");
                vSqlCommand.Parameters.AddWithValue("@USRKey", aUserRole.UsrKey);
                vStringBuilder.AppendLine("and    t0.ROL_key = @ROLkey");
                vSqlCommand.Parameters.AddWithValue("@ROLkey", aUserRole.Rolkey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected UserRole not found: USR_Key = {0}, ROL_key = {1}", aUserRole.UsrKey, aUserRole.Rolkey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aUserRole, vSqlDataReader);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="UserRole"/> passed as an argument via Stored Procedure that returns the newly inserted UserRole Key 
        /// </summary>
        /// <param name="aUserRole">A <see cref="UserRole"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aUserRole</c> argument is <c>null</c>.</exception>
        public static void Insert(UserRole aUserRole)
        {
            if (aUserRole == null)
            {
                throw new ArgumentNullException("aUserRole");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into URL_UserRole");
                vStringBuilder.AppendLine("       (USR_Key, ROL_key)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@USRKey, @ROLkey)");
                ObjectToData(vSqlCommand, aUserRole);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="UserRole"/> passed as an argument .
        /// </summary>
        /// <param name="aUserRole">A <see cref="UserRole"/>.</param>
        public static void Update(UserRole aUserRole)
        {
//            if (aUserRole == null)
//            {
//                throw new ArgumentNullException("aUserRole");
//            }
//            using (var vSqlCommand = new SqlCommand()
//            {
//                CommandType = CommandType.Text,
//                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
//            })
//            {
//                var vStringBuilder = new StringBuilder();
//                vStringBuilder.AppendLine("update URL_UserRole");
//");
//                vStringBuilder.AppendLine("where  USR_Key = @USRKey");
//                vStringBuilder.AppendLine("and    ROL_key = @ROLkey");
//                ObjectToData(vSqlCommand, aUserRole);
//                vSqlCommand.CommandText = vStringBuilder.ToString();
//                vSqlCommand.Connection.Open();
//                vSqlCommand.ExecuteNonQuery();
//                vSqlCommand.Connection.Close();
//            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="UserRole"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserRole">The <see cref="UserRole"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aUserRole</c> argument is <c>null</c>.</exception>
        public static void Delete(UserRole aUserRole)
        {
            if (aUserRole == null)
            {
                throw new ArgumentNullException("aUserRole");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete URL_UserRole");
                vStringBuilder.AppendLine("where  USR_Key = @USRKey");
                vSqlCommand.Parameters.AddWithValue("@USRKey", aUserRole.UsrKey);
                vStringBuilder.AppendLine("and    ROL_key = @ROLkey");
                vSqlCommand.Parameters.AddWithValue("@ROLkey", aUserRole.Rolkey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
     }
 }