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
    /// Load the merged Role Access Functions for a specific Fan 
    /// </summary>
    public class FanFunctionAccessData
    {
        #region Load Single Function
        /// <summary>
        /// Loads the access to a specific function for a specific user.
        /// </summary>
        /// <param name="aFanFunctionAccess">A user function access.</param>
        public static void Load(FanFunctionAccess aFanFunctionAccess)
        {
            if (aFanFunctionAccess == null)
            {
                throw new ArgumentNullException("aFanFunctionAccess");
            }

            // Clear the map
            aFanFunctionAccess.FunctionAccess.Access.AccessMap = 0;


            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("select RFC_AccessMap");
                vStringBuilder.AppendLine("from FRL_FanRole t1, RFC_RoleFunction t2, FNC_Function t3");
                vStringBuilder.AppendLine("where   t1.ROL_Key = t2.ROL_Key");
                vStringBuilder.AppendLine("and   t2.FNC_Key = t3.FNC_Key");
                vStringBuilder.AppendLine("and   t1.FAN_Key = @FANKey");
                vStringBuilder.AppendLine("and   t3.FNC_Code = @FNCCode");
                vSqlCommand.Parameters.AddWithValue("@FANKey", aFanFunctionAccess.FannKey);
                vSqlCommand.Parameters.AddWithValue("@FNCCode", aFanFunctionAccess.FunctionAccess.Function);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (var vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    bool _haveRows = Read(vSqlDataReader);
                    while (_haveRows)
                    {
                        aFanFunctionAccess.FunctionAccess.Access.Merge(new Access() { AccessMap = Convert.ToInt32(vSqlDataReader["RFC_AccessMap"]) });
                        _haveRows = Read(vSqlDataReader);
                    }
                    aFanFunctionAccess.FunctionAccess.Access.Loaded = true;
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
        /// <param name="aFanFunctionAccessCollection">A user function access collection.</param>
        public static void Load(FanFunctionAccessCollection aFanFunctionAccessCollection)
        {
            if (aFanFunctionAccessCollection == null)
            {
                throw new ArgumentNullException("aFanFunctionAccessCollection");
            }

            // Clear the list
            aFanFunctionAccessCollection.FunctionAccessList.Clear();

            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("select FNC_Code, RFC_AccessMap");
                vStringBuilder.AppendLine("from FRL_FanRole t1, RFC_RoleFunction t2, FNC_Function t3");
                vStringBuilder.AppendLine("where t1.ROL_Key = t2.ROL_Key");
                vStringBuilder.AppendLine("and   t2.FNC_Key = t3.FNC_Key");
                vStringBuilder.AppendLine("and   t1.FAN_Key = @FANKey");
                vSqlCommand.Parameters.AddWithValue("@FANKey", aFanFunctionAccessCollection.FannKey);
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
                        aFanFunctionAccessCollection.FunctionAccessList.Add(vFunctionAccess);
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
        /// <param name="aFanKey">A user key composite.</param>
        /// <param name="aFunction">A function.</param>
        /// <returns></returns>
        public static Access GetAccess(FanKey aFanKey, string aFunction)
        {
            FanFunctionAccess vFanFunctionAccess = new FanFunctionAccess() { FannKey = aFanKey.FannKey };
            vFanFunctionAccess.FunctionAccess.Function = aFunction;
            Load(vFanFunctionAccess);
            return vFanFunctionAccess.FunctionAccess.Access;
        }
        #endregion

        #region HasModeAccess To Function
        /// <summary>
        /// Gets a specific access of a Specific mode for a user.
        /// </summary>
        /// <param name="aFanKey">A user key composite.</param>
        /// <param name="aFunction">A function.</param>
        /// <param name="aAccessMode">A access mode.</param>
        /// <returns></returns>
        public static bool HasModeAccess(FanKey aFanKey, string aFunction, AccessMode aAccessMode)
        {
            FanFunctionAccess vFanFunctionAccess = new FanFunctionAccess() { FannKey = aFanKey.FannKey };
            vFanFunctionAccess.FunctionAccess.Function = aFunction;
            Load(vFanFunctionAccess);
            bool vAccess = false;
            switch (aAccessMode)
            {
                case AccessMode.List:
                    {
                        vAccess = vFanFunctionAccess.FunctionAccess.Access.List;
                        break;
                    }
                case AccessMode.Read:
                    {
                        vAccess = vFanFunctionAccess.FunctionAccess.Access.Read;
                        break;
                    }
                case AccessMode.Create:
                    {
                        vAccess = vFanFunctionAccess.FunctionAccess.Access.Create;
                        break;
                    }
                case AccessMode.Update:
                    {
                        vAccess = vFanFunctionAccess.FunctionAccess.Access.Update;
                        break;
                    }
                case AccessMode.Delete:
                    {
                        vAccess = vFanFunctionAccess.FunctionAccess.Access.Delete;
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
