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
    /// Load the merged Role Access Functions for a specific User 
    /// </summary>
    public class UserFunctionAccessData
    {
        #region Load Single Function
        /// <summary>
        /// Loads the access to a specific function for a specific user.
        /// </summary>
        /// <param name="aUserFunctionAccess">A user function access.</param>
        public static void Load(UserFunctionAccess aUserFunctionAccess)
        {
            if (aUserFunctionAccess == null)
            {
                throw new ArgumentNullException("aUserFunctionAccess");
            }

            // Clear the map
            aUserFunctionAccess.FunctionAccess.Access.AccessMap = 0;


            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("select RFC_AccessMap");
                vStringBuilder.AppendLine("from URL_UserRole t1, RFC_RoleFunction t2, FNC_Function t3");
                vStringBuilder.AppendLine("where   t1.ROL_Key = t2.ROL_Key");
                vStringBuilder.AppendLine("and   t2.FNC_Key = t3.FNC_Key");
                vStringBuilder.AppendLine("and   t1.USR_Key = @USRKey");
                vStringBuilder.AppendLine("and   t3.FNC_Code = @FNCCode");
                vSqlCommand.Parameters.AddWithValue("@USRKey", aUserFunctionAccess.UsrKey);
                vSqlCommand.Parameters.AddWithValue("@FNCCode", aUserFunctionAccess.FunctionAccess.Function);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (var vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    bool _haveRows = Read(vSqlDataReader);
                    while (_haveRows)
                    {
                        aUserFunctionAccess.FunctionAccess.Access.Merge(new Access() { AccessMap = Convert.ToInt32(vSqlDataReader["RFC_AccessMap"]) });
                        _haveRows = Read(vSqlDataReader);
                    }
                    aUserFunctionAccess.FunctionAccess.Access.Loaded = true;
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }
        #endregion

        #region Load Collection
        /// <summary>
        /// Loads the access to all functions for a specific user.
        /// </summary>
        /// <param name="aUserFunctionAccessCollection">A user function access collection.</param>
        public static void Load(UserFunctionAccessCollection aUserFunctionAccessCollection)
        {
            if (aUserFunctionAccessCollection == null)
            {
                throw new ArgumentNullException("aUserFunctionAccessCollection");
            }

            // Clear the list
            aUserFunctionAccessCollection.FunctionAccessList.Clear();

            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("select FNC_Code, RFC_AccessMap");
                vStringBuilder.AppendLine("from URL_UserRole t1, RFC_RoleFunction t2, FNC_Function t3");
                vStringBuilder.AppendLine("where t1.ROL_Key = t2.ROL_Key");
                vStringBuilder.AppendLine("and   t2.FNC_Key = t3.FNC_Key");
                vStringBuilder.AppendLine("and   t1.USR_Key = @USRKey");
                vSqlCommand.Parameters.AddWithValue("@USRKey", aUserFunctionAccessCollection.UsrKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (var vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    bool _haveRows = Read(vSqlDataReader);
                    while (_haveRows)
                    {
                        // Create an initialized FunctionAccess
                        FunctionAccess vFunctionAccess = new FunctionAccess();
                        vFunctionAccess.Function = Convert.ToString(vSqlDataReader["FNC_Code"]);
                        vFunctionAccess.Access.AccessMap = 0;
                        while (_haveRows && vFunctionAccess.Function == Convert.ToString(vSqlDataReader["FNC_Code"]))
                        {
                            vFunctionAccess.Access.Merge(new Access() { AccessMap = Convert.ToInt32(vSqlDataReader["RFC_AccessMap"]) });
                            _haveRows = Read(vSqlDataReader);
                        }
                        aUserFunctionAccessCollection.FunctionAccessList.Add(vFunctionAccess);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }           
        }
        #endregion

        #region ReadSqlDataReader
        /// <summary>
        /// Reads the specified a SQL data reader.
        /// </summary>
        /// <param name="aSqlDataReader">An SQL data reader.</param>
        /// <returns>true if rows exist, else false</returns>
        private static bool Read(SqlDataReader aSqlDataReader)
        {
            return aSqlDataReader.Read();
        }
        #endregion

        #region GetAccess Full
        /// <summary>
        /// Gets a specific access for a user.
        /// </summary>
        /// <param name="aUserKey">A user key composite.</param>
        /// <param name="aFunction">A function.</param>
        /// <returns></returns>
        public static Access GetAccess(UserKey aUserKey, string aFunction)
        {
            UserFunctionAccess vUserFunctionAccess = new UserFunctionAccess() { UsrKey = aUserKey.UsrKey };
            vUserFunctionAccess.FunctionAccess.Function = aFunction;
            Load(vUserFunctionAccess);
            return vUserFunctionAccess.FunctionAccess.Access;
        }
        #endregion

        #region HasModeAccess To Function
        /// <summary>
        /// Gets a specific access of a Specific mode for a user.
        /// </summary>
        /// <param name="aUserKey">A user key composite.</param>
        /// <param name="aFunction">A function.</param>
        /// <param name="aAccessMode">A access mode.</param>
        /// <returns></returns>
        public static bool HasModeAccess(UserKey aUserKey, string aFunction, AccessMode aAccessMode)
        {
            UserFunctionAccess vUserFunctionAccess = new UserFunctionAccess() { UsrKey = aUserKey.UsrKey };
            vUserFunctionAccess.FunctionAccess.Function = aFunction;
            Load(vUserFunctionAccess);
            bool vAccess = false;
            switch (aAccessMode)
            {
                case AccessMode.List:
                    {
                        vAccess = vUserFunctionAccess.FunctionAccess.Access.List;
                        break;
                    }
                case AccessMode.Read:
                    {
                        vAccess = vUserFunctionAccess.FunctionAccess.Access.Read;
                        break;
                    }
                case AccessMode.Create:
                    {
                        vAccess = vUserFunctionAccess.FunctionAccess.Access.Create;
                        break;
                    }
                case AccessMode.Update:
                    {
                        vAccess = vUserFunctionAccess.FunctionAccess.Access.Update;
                        break;
                    }
                case AccessMode.Delete:
                    {
                        vAccess = vUserFunctionAccess.FunctionAccess.Access.Delete;
                        break;
                    }
                default:
                    {
                        vAccess = false;
                        break;
                    }
            }
            return vAccess; 
        }
        #endregion
    }
}
