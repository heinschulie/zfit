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
    ///   RoleFunctionData class.
    /// </summary>
    public class RoleFunctionData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="RoleFunction"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.ROL_Key, t1.ROL_Name, t2.FNC_Key, t2.FNC_Name, t3.RFC_AccessMap");
            vStringBuilder.AppendLine("from   ROL_Role t1,");
            vStringBuilder.AppendLine("       FNC_Function t2");
            //!!!!!!!!!!!!------------Edit Statement------------!!!!!!!!!!!!
            vStringBuilder.AppendLine("where  t1.ROL_Key = t3.ROL_Key");
            vStringBuilder.AppendLine("and    t2.FNC_Key = t3.FNC_Key");
            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="RoleFunction"/> object.
        /// </summary>
        /// <param name="aRoleFunction">A <see cref="RoleFunction"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(RoleFunction aRoleFunction, SqlDataReader aSqlDataReader)
        {
            aRoleFunction.RolKey = Convert.ToInt32(aSqlDataReader["ROL_Key"]);
            aRoleFunction.RolName = Convert.ToString(aSqlDataReader["ROL_Name"]);
            aRoleFunction.FncKey = Convert.ToInt32(aSqlDataReader["FNC_Key"]);
            aRoleFunction.FncName = Convert.ToString(aSqlDataReader["FNC_Name"]);
            aRoleFunction.RfcAccessMap = Convert.ToInt32(aSqlDataReader["RFC_AccessMap"]);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="RoleFunction"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aRoleFunction">A <see cref="RoleFunction"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, RoleFunction aRoleFunction)
        {
            aSqlCommand.Parameters.AddWithValue("@ROLKey", aRoleFunction.RolKey);
            aSqlCommand.Parameters.AddWithValue("@FNCKey", aRoleFunction.FncKey);
            aSqlCommand.Parameters.AddWithValue("@RFCAccessMap", aRoleFunction.RfcAccessMap);
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>RoleFunctionList</c> property a <see cref="RoleFunctionCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="RoleFunction"/>, filtered by the filter properties of the passed <see cref="RoleFunctionCollection"/>.
        /// </summary>
        /// <param name="aRoleFunctionCollection">The <see cref="RoleFunctionCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="RoleFunctionCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aRoleFunctionCollection</c> argument is <c>null</c>.</exception>
        public static void Load(RoleFunctionCollection aRoleFunctionCollection)
        {
            if (aRoleFunctionCollection == null)
            {
                throw new ArgumentNullException("aRoleFunctionCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aRoleFunctionCollection.IsFiltered)
                {
                    if (aRoleFunctionCollection.RoleKeyFilter > 0)
                    {
                        vStringBuilder.AppendLine("and    t1.ROL_Key = @ROLKey");
                        vSqlCommand.Parameters.AddWithValue("@ROLKey", aRoleFunctionCollection.RoleKeyFilter);
                    }
                    if (aRoleFunctionCollection.FunctionKeyFilter > 0)
                    {
                        vStringBuilder.AppendLine("and    t2.FNC_Key = @FNCKey");
                        vSqlCommand.Parameters.AddWithValue("@FNCKey", aRoleFunctionCollection.FunctionKeyFilter);
                    }
                }
                vStringBuilder.AppendLine("order by t3.RFC_Key");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vRoleFunction = new RoleFunction();
                        DataToObject(vRoleFunction, vSqlDataReader);
                        aRoleFunctionCollection.RoleFunctionList.Add(vRoleFunction);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="RoleFunction"/>, with keys in the <c>aRoleFunction</c> argument.
        /// </summary>
        /// <param name="aRoleFunction">A <see cref="RoleFunction"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aRoleFunction</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(RoleFunction aRoleFunction)
        {
            if (aRoleFunction == null)
            {
                throw new ArgumentNullException("aRoleFunction");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and    t1.ROL_Key = @ROLKey");
                vSqlCommand.Parameters.AddWithValue("@ROLKey", aRoleFunction.RolKey);
                vStringBuilder.AppendLine("and    t2.FNC_Key = @FNCKey");
                vSqlCommand.Parameters.AddWithValue("@FNCKey", aRoleFunction.FncKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected RoleFunction not found: ROL_Key = {0}, FNC_Key = {1}", aRoleFunction.RolKey, aRoleFunction.FncKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aRoleFunction, vSqlDataReader);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="RoleFunction"/> passed as an argument via Stored Procedure that returns the newly inserted RoleFunction Key 
        /// </summary>
        /// <param name="aRoleFunction">A <see cref="RoleFunction"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aRoleFunction</c> argument is <c>null</c>.</exception>
        public static void Insert(RoleFunction aRoleFunction)
        {
            if (aRoleFunction == null)
            {
                throw new ArgumentNullException("aRoleFunction");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into RFC_RoleFunction");
                vStringBuilder.AppendLine("       (ROL_Key, FNC_Key, RFC_AccessMap)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@ROLKey, @FNCKey, @RFCAccessMap)");
                ObjectToData(vSqlCommand, aRoleFunction);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="RoleFunction"/> passed as an argument .
        /// </summary>
        /// <param name="aRoleFunction">A <see cref="RoleFunction"/>.</param>
        public static void Update(RoleFunction aRoleFunction)
        {
            if (aRoleFunction == null)
            {
                throw new ArgumentNullException("aRoleFunction");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update RFC_RoleFunction");
                vStringBuilder.AppendLine("set    RFC_AccessMap = @RFCAccessMap");
                vStringBuilder.AppendLine("where  ROL_Key = @ROLKey");
                vStringBuilder.AppendLine("and    FNC_Key = @FNCKey");
                ObjectToData(vSqlCommand, aRoleFunction);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="RoleFunction"/> object passed as an argument.
        /// </summary>
        /// <param name="aRoleFunction">The <see cref="RoleFunction"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aRoleFunction</c> argument is <c>null</c>.</exception>
        public static void Delete(RoleFunction aRoleFunction)
        {
            if (aRoleFunction == null)
            {
                throw new ArgumentNullException("aRoleFunction");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete RFC_RoleFunction");
                vStringBuilder.AppendLine("where  ROL_Key = @ROLKey");
                vSqlCommand.Parameters.AddWithValue("@ROLKey", aRoleFunction.RolKey);
                vStringBuilder.AppendLine("and    FNC_Key = @FNCKey");
                vSqlCommand.Parameters.AddWithValue("@FNCKey", aRoleFunction.FncKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
     }
 }