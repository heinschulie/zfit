using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Zephry;

namespace zfit 
{
    public class FedData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="Fed"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL(bool aIncludeAvatar)
        {
            string vAvatar = aIncludeAvatar ? ", t1.FED_Avatar" : String.Empty;
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.FED_Key, t1.FED_Name, t1.FAN_Key,");
            vStringBuilder.AppendFormat("(select FAN_Name from FAN_Fanatic where FAN_Key = t1.FAN_Key) as FedOwner{0}", vAvatar).AppendLine(); //Sub-query to ascertain owner name 
            vStringBuilder.AppendLine("from   FED_Federation t1");

            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="Fed"/> object.
        /// </summary>
        /// <param name="aFed">A <see cref="Fed"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(Fed aFed, SqlDataReader aSqlDataReader, bool aIncludeAvatar)
        {
            aFed.FeddKey = Convert.ToInt32(aSqlDataReader["FED_Key"]);
            aFed.FedName = Convert.ToString(aSqlDataReader["FED_Name"]);
            aFed.FanKey = Convert.ToInt32(aSqlDataReader["FAN_Key"]);
            aFed.FanName = Convert.ToString(aSqlDataReader["FedOwner"]);

            if (aIncludeAvatar)
            {
                aFed.FedAvatar = CommonUtils.DbValueTo<byte[]>(aSqlDataReader["FED_Avatar"], null);
            }
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="Fed"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aFed">A <see cref="Fed"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, Fed aFed)
        {
            aSqlCommand.Parameters.AddWithValue("@FEDName", aFed.FedName);
            aSqlCommand.Parameters.AddWithValue("@FANKey", aFed.FanKey);
            if (aFed.FedAvatar == null)
            {
                aSqlCommand.Parameters.Add("@FEDAvatar", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@FEDAvatar", aFed.FedAvatar);
            }
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>FedList</c> property a <see cref="FedCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="Fed"/>, filtered by the filter properties of the passed <see cref="FedCollection"/>.
        /// </summary>
        /// <param name="aFedCollection">The <see cref="FedCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="FedCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aFedCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FedCollection aFedCollection)
        {
            if (aFedCollection == null)
            {
                throw new ArgumentNullException("aFedCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL(false);
                if (aFedCollection.IsFiltered)
                {
                    vStringBuilder.AppendFormat("where t1.FED_Name is like '%{0}%", aFedCollection.FedFilter.FedNameFilter);
                }
                vStringBuilder.AppendLine("order by t1.FED_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vFed = new Fed();
                        DataToObject(vFed, vSqlDataReader, false);
                        aFedCollection.FedList.Add(vFed);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load by Key

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Fed"/>, with keys in the <c>aFed</c> argument.
        /// </summary>
        /// <param name="aFed">A <see cref="Fed"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFed</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(Fed aFed)
        {
            if (aFed == null)
            {
                throw new ArgumentNullException("aFed");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL(true);
                vStringBuilder.AppendLine("where t1.FED_Key = @FEDKey");
                vSqlCommand.Parameters.AddWithValue("@FEDKey", aFed.FeddKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected Fed not found: FED_Key = {0}", aFed.FeddKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aFed, vSqlDataReader, true);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Fed"/> passed as an argument via Stored Procedure that returns the newly inserted Fed Key 
        /// </summary>
        /// <param name="aFed">A <see cref="Fed"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFed</c> argument is <c>null</c>.</exception>
        public static void Insert(Fed aFed)
        {
            if (aFed == null)
            {
                throw new ArgumentNullException("aFed");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into FED_Federation");
                vStringBuilder.AppendLine("       (FED_Name, FAN_Key,");
                vStringBuilder.AppendLine("        FED_Avatar)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@FEDName, @FANKey,");
                vStringBuilder.AppendLine("        @FEDAvatar)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aFed);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aFed.FeddKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Fed"/> passed as an argument .
        /// </summary>
        /// <param name="aFed">A <see cref="Fed"/>.</param>
        public static void Update(Fed aFed)
        {
            if (aFed == null)
            {
                throw new ArgumentNullException("aFed");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update FED_Federation");
                vStringBuilder.AppendLine("set    FED_Name = @FEDName,");
                vStringBuilder.AppendLine("       FAN_Key = @FANKey,");
                vStringBuilder.AppendLine("       FED_Avatar = @FEDAvatar");
                vStringBuilder.AppendLine("where  FED_Key = @FEDKey");
                ObjectToData(vSqlCommand, aFed);
                vSqlCommand.Parameters.AddWithValue("@FEDKey", aFed.FeddKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Fed"/> object passed as an argument.
        /// </summary>
        /// <param name="aFed">The <see cref="Fed"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aFed</c> argument is <c>null</c>.</exception>
        public static void Delete(Fed aFed)
        {
            if (aFed == null)
            {
                throw new ArgumentNullException("aFed");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete FED_Federation");
                vStringBuilder.AppendLine("where  FED_Key = @FEDKey");
                vSqlCommand.Parameters.AddWithValue("@FEDKey", aFed.FeddKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
