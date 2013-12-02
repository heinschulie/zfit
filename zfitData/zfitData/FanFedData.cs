using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Zephry;

namespace zfit
{
    public class FanFedData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="FanFed"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.FED_Key, t1.FED_Name, t2.FAN_Key, t2.FAN_Name, t2.FAN_Surname, t3.FEN_DateJoined");
            vStringBuilder.AppendLine("from   FED_Federation t1, ");
            vStringBuilder.AppendLine("       FAN_Fanatic t2,");
            vStringBuilder.AppendLine("       FEN_FanFederation t3");
            vStringBuilder.AppendLine("where  t1.FED_Key = t3.FED_Key");
            vStringBuilder.AppendLine("and    t2.FAN_Key = t3.FAN_Key");

            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="FanFed"/> object.
        /// </summary>
        /// <param name="aFanFed">A <see cref="Federation"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(FanFed aFanFed, SqlDataReader aSqlDataReader, bool aIncludeAvatar)
        {
            aFanFed.FedKey = Convert.ToInt32(aSqlDataReader["FED_Key"]);
            aFanFed.FedName = Convert.ToString(aSqlDataReader["FED_Name"]);
            aFanFed.FanKey = Convert.ToInt32(aSqlDataReader["FAN_Key"]);
            aFanFed.FanName = Convert.ToString(aSqlDataReader["FAN_Name"]);
            aFanFed.FanSurname = Convert.ToString(aSqlDataReader["FAN_Surname"]);
            aFanFed.FanFedDateJoined = Convert.ToDateTime(aSqlDataReader["FEN_DateJoined"]);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="FanFed"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aFederation">A <see cref="FanFed"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, FanFed aFanFed)
        {
            aSqlCommand.Parameters.AddWithValue("@FEDKey", aFanFed.FedKey);
            aSqlCommand.Parameters.AddWithValue("@FANKey", aFanFed.FanKey);
            aSqlCommand.Parameters.AddWithValue("@FEDFANDateJoined", aFanFed.FanFedDateJoined);
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>FanFedList</c> property a <see cref="FanFedCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="FanFed"/>, filtered by the filter properties of the passed <see cref="FanFedCollection"/>.
        /// </summary>
        /// <param name="aFanFedCollection">The <see cref="FanFedCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="FanFedCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aFanFedCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanFedCollection aFanFedCollection)
        {
            if (aFanFedCollection == null)
            {
                throw new ArgumentNullException("aFanFedCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aFanFedCollection.IsFiltered)
                {
                    if (aFanFedCollection.FanFedFilter.FanfedFilter.FedKey > 0)
                    {
                        vStringBuilder.AppendLine("and t1.FED_Key = @FEDKey");
                        vSqlCommand.Parameters.AddWithValue("@FEDKey", aFanFedCollection.FanFedFilter.FanfedFilter.FedKey);
                    }
                    if (aFanFedCollection.FanFedFilter.FanfedFilter.FanKey > 0)
                    {
                        vStringBuilder.AppendLine("and t2.FAN_Key = @FANKey");
                        vSqlCommand.Parameters.AddWithValue("@FANKey", aFanFedCollection.FanFedFilter.FanfedFilter.FanKey);
                    }
                    if (aFanFedCollection.FanFedFilter.FanfedFilter.FedName != null)
                    {
                        vStringBuilder.AppendFormat("and t1.FED_Name like '%{0}%'", aFanFedCollection.FanFedFilter.FanfedFilter.FedName);
                    }
                    if (aFanFedCollection.FanFedFilter.FanfedFilter.FanName != null)
                    {
                        vStringBuilder.AppendFormat("and t2.FAN_Name like '%{0}%'", aFanFedCollection.FanFedFilter.FanfedFilter.FanName);
                    }
                }
                vStringBuilder.AppendLine("order by t1.FED_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vFanFed = new FanFed();
                        DataToObject(vFanFed, vSqlDataReader, false);
                        aFanFedCollection.FanFedList.Add(vFanFed);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Save
        public static void Save(FanFedCollection aFanFedCollection)
        {
            Delete(aFanFedCollection.FanFedFilter.FanfedFilter);
            Insert(aFanFedCollection);
        }
        #endregion

        #region Load by Key

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="FanFed"/>, with keys in the <c>aFanFed</c> argument.
        /// </summary>
        /// <param name="aFanFed">A <see cref="FanFed"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanFed</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(FanFed aFanFed)
        {
            if (aFanFed == null)
            {
                throw new ArgumentNullException("aFanFed");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and t1.FED_Key = @FEDKey");
                vStringBuilder.AppendLine("and t2.FAN_Key = @FANKey");
                vSqlCommand.Parameters.AddWithValue("@FEDKey", aFanFed.FedKey);
                vSqlCommand.Parameters.AddWithValue("@FANKey", aFanFed.FanKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected FederationFAN not found: FED_Key = {0}, FAN_Key = {1}", aFanFed.FedKey, aFanFed.FanKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aFanFed, vSqlDataReader, true);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="FanFed"/> passed as an argument via Stored Procedure that returns the newly inserted FanFed Key 
        /// </summary>
        /// <param name="aFanFed">A <see cref="FanFed"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanFed</c> argument is <c>null</c>.</exception>
        public static void Insert(FanFedCollection aFanFedCollection)
        {
            if (aFanFedCollection == null)
            {
                throw new ArgumentNullException("aFanFedCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into FEN_FanFederation");
                vStringBuilder.AppendLine("       (FED_Key, FAN_Key,");
                vStringBuilder.AppendLine("        FEN_DateJoined)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@FEDKey, @FANKey,");
                vStringBuilder.AppendLine("        @FENDateJoined)");
                vStringBuilder.AppendLine(";");
                vSqlCommand.Parameters.Add("@FEDKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@FANKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@FENDateJoined", SqlDbType.DateTime);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aFanFedCollection.FanFedList.ForEach(vFanFed =>
                {
                    vSqlCommand.Parameters["@FEDKey"].Value = vFanFed.FedKey;
                    vSqlCommand.Parameters["@FANKey"].Value = vFanFed.FanKey;
                    vSqlCommand.Parameters["@FENDateJoined"].Value = vFanFed.FanFedDateJoined;
                    vSqlCommand.ExecuteScalar();
                });
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="FanFed"/> passed as an argument .
        /// </summary>
        /// <param name="aFanFed">A <see cref="FanFed"/>.</param>
        public static void Update(FanFed aFanFed)
        {
            if (aFanFed == null)
            {
                throw new ArgumentNullException("aFanFed");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update FEN_FanFederation");
                vStringBuilder.AppendLine("set    FEN_DateJoined = @FENDateJoined,");
                vStringBuilder.AppendLine("where  FED_Key = @FEDKey");
                vStringBuilder.AppendLine("and    FAN_Key = @FANKey");
                ObjectToData(vSqlCommand, aFanFed);
                vSqlCommand.Parameters.AddWithValue("@FENDateJoined", aFanFed.FanFedDateJoined);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="FanFed"/> object passed as an argument.
        /// </summary>
        /// <param name="aFanFed">The <see cref="FanFed"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aFanFed</c> argument is <c>null</c>.</exception>
        public static void Delete(FanFed aFanFed)
        {
            if (aFanFed == null)
            {
                throw new ArgumentNullException("aFanFed");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete FEN_FanFederation");
                if (aFanFed.FedKey > 0 && aFanFed.FanKey > 0)
                {
                    vStringBuilder.AppendLine("where  FED_Key = @FEDKey");
                    vStringBuilder.AppendLine("and    FAN_Key = @FANKey");
                }
                else if (aFanFed.FedKey > 0)
                {
                    vStringBuilder.AppendLine("where  FED_Key = @FEDKey");
                }
                else if (aFanFed.FanKey > 0)
                {
                    vStringBuilder.AppendLine("where  FAN_Key = @FANKey");
                }
                vSqlCommand.Parameters.AddWithValue("@FEDKey", aFanFed.FedKey);
                vSqlCommand.Parameters.AddWithValue("@FANKey", aFanFed.FanKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
