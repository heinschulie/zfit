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
    ///   FunctionData class.
    /// </summary>
    public class FunctionData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="Function"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.FNC_Key, t1.FNC_Code, t1.FNC_Name");
            vStringBuilder.AppendLine("from   FNC_Function t1");
            //!!!!!!!!!!!!------------Edit Statement------------!!!!!!!!!!!!

            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="Function"/> object.
        /// </summary>
        /// <param name="aFunction">A <see cref="Function"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(Function aFunction, SqlDataReader aSqlDataReader)
        {
            aFunction.FncKey = Convert.ToInt32(aSqlDataReader["FNC_Key"]);
            aFunction.FncCode = Convert.ToString(aSqlDataReader["FNC_Code"]);
            aFunction.FncName = Convert.ToString(aSqlDataReader["FNC_Name"]);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="Function"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aFunction">A <see cref="Function"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, Function aFunction)
        {
            aSqlCommand.Parameters.AddWithValue("@FNCCode", aFunction.FncCode);
            aSqlCommand.Parameters.AddWithValue("@FNCName", aFunction.FncName);
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>FunctionList</c> property a <see cref="FunctionCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="Function"/>, filtered by the filter properties of the passed <see cref="FunctionCollection"/>.
        /// </summary>
        /// <param name="aFunctionCollection">The <see cref="FunctionCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="FunctionCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aFunctionCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FunctionCollection aFunctionCollection)
        {
            if (aFunctionCollection == null)
            {
                throw new ArgumentNullException("aFunctionCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aFunctionCollection.IsFiltered)
                {

                }
                vStringBuilder.AppendLine("order by t1.FNC_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vFunction = new Function();
                        DataToObject(vFunction, vSqlDataReader);
                        aFunctionCollection.FunctionList.Add(vFunction);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Function"/>, with keys in the <c>aFunction</c> argument.
        /// </summary>
        /// <param name="aFunction">A <see cref="Function"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFunction</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(Function aFunction)
        {
            if (aFunction == null)
            {
                throw new ArgumentNullException("aFunction");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and    t1.FNC_Key = @FNCKey");
                vSqlCommand.Parameters.AddWithValue("@FNCKey", aFunction.FncKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected Function not found: FNC_Key = {0}", aFunction.FncKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aFunction, vSqlDataReader);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Function"/> passed as an argument via Stored Procedure that returns the newly inserted Function Key 
        /// </summary>
        /// <param name="aFunction">A <see cref="Function"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFunction</c> argument is <c>null</c>.</exception>
        public static void Insert(Function aFunction)
        {
            if (aFunction == null)
            {
                throw new ArgumentNullException("aFunction");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into FNC_Function");
                vStringBuilder.AppendLine("       (FNC_Code, FNC_Name)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@FNCCode, @FNCName)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aFunction);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aFunction.FncKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Function"/> passed as an argument .
        /// </summary>
        /// <param name="aFunction">A <see cref="Function"/>.</param>
        public static void Update(Function aFunction)
        {
            if (aFunction == null)
            {
                throw new ArgumentNullException("aFunction");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update FNC_Function");
                vStringBuilder.AppendLine("set    FNC_Code = @FNCCode,");
                vStringBuilder.AppendLine("       FNC_Name = @FNCName");
                vStringBuilder.AppendLine("where  FNC_Key = @FNCKey");
                ObjectToData(vSqlCommand, aFunction);
                vSqlCommand.Parameters.AddWithValue("@FNCKey", aFunction.FncKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Function"/> object passed as an argument.
        /// </summary>
        /// <param name="aFunction">The <see cref="Function"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aFunction</c> argument is <c>null</c>.</exception>
        public static void Delete(Function aFunction)
        {
            if (aFunction == null)
            {
                throw new ArgumentNullException("aFunction");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete FNC_Function");
                vStringBuilder.AppendLine("where  FNC_Key = @FNCKey");
                vSqlCommand.Parameters.AddWithValue("@FNCKey", aFunction.FncKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
     }
 }