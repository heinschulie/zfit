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
    ///   RoleData class.
    /// </summary>
    public class RoleData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="Role"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.ROL_Key, t1.ROL_Name");
            vStringBuilder.AppendLine("from   ROL_Role t1");
            //!!!!!!!!!!!!------------Edit Statement------------!!!!!!!!!!!!

            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="Role"/> object.
        /// </summary>
        /// <param name="aRole">A <see cref="Role"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(Role aRole, SqlDataReader aSqlDataReader)
        {
            aRole.RolKey = Convert.ToInt32(aSqlDataReader["ROL_Key"]);
            aRole.RolName = Convert.ToString(aSqlDataReader["ROL_Name"]);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="Role"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aRole">A <see cref="Role"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, Role aRole)
        {

            aSqlCommand.Parameters.AddWithValue("@ROLName", aRole.RolName);
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>RoleList</c> property a <see cref="RoleCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="Role"/>, filtered by the filter properties of the passed <see cref="RoleCollection"/>.
        /// </summary>
        /// <param name="aRoleCollection">The <see cref="RoleCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="RoleCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aRoleCollection</c> argument is <c>null</c>.</exception>
        public static void Load(RoleCollection aRoleCollection)
        {
            if (aRoleCollection == null)
            {
                throw new ArgumentNullException("aRoleCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aRoleCollection.IsFiltered)
                {

                }
                vStringBuilder.AppendLine("order by t1.ROL_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vRole = new Role();
                        DataToObject(vRole, vSqlDataReader);
                        aRoleCollection.RoleList.Add(vRole);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Role"/>, with keys in the <c>aRole</c> argument.
        /// </summary>
        /// <param name="aRole">A <see cref="Role"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aRole</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(Role aRole)
        {
            if (aRole == null)
            {
                throw new ArgumentNullException("aRole");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and    t1.ROL_Key = @ROLKey");
                vSqlCommand.Parameters.AddWithValue("@ROLKey", aRole.RolKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected Role not found: ROL_Key = {0}", aRole.RolKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aRole, vSqlDataReader);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Role"/> passed as an argument via Stored Procedure that returns the newly inserted Role Key 
        /// </summary>
        /// <param name="aRole">A <see cref="Role"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aRole</c> argument is <c>null</c>.</exception>
        public static void Insert(Role aRole)
        {
            if (aRole == null)
            {
                throw new ArgumentNullException("aRole");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into ROL_Role");
                vStringBuilder.AppendLine("       (ROL_Name)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@ROLName)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aRole);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aRole.RolKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Role"/> passed as an argument .
        /// </summary>
        /// <param name="aRole">A <see cref="Role"/>.</param>
        public static void Update(Role aRole)
        {
            if (aRole == null)
            {
                throw new ArgumentNullException("aRole");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update ROL_Role");
                vStringBuilder.AppendLine("set    ROL_Name = @ROLName");
                vStringBuilder.AppendLine("where  ROL_Key = @ROLKey");
                ObjectToData(vSqlCommand, aRole);
                vSqlCommand.Parameters.AddWithValue("@ROLKey", aRole.RolKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Role"/> object passed as an argument.
        /// </summary>
        /// <param name="aRole">The <see cref="Role"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aRole</c> argument is <c>null</c>.</exception>
        public static void Delete(Role aRole)
        {
            if (aRole == null)
            {
                throw new ArgumentNullException("aRole");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete ROL_Role");
                vStringBuilder.AppendLine("where  ROL_Key = @ROLKey");
                vSqlCommand.Parameters.AddWithValue("@ROLKey", aRole.RolKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
     }
 }