using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Zephry;

namespace zfit
{
    public class CellFedData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="CellFed"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.CEL_Key, t1.CEL_Name, t2.FED_Key, t2.FED_Name, t3.CED_DateJoined");
            vStringBuilder.AppendLine("from   CEL_Cell t1, ");
            vStringBuilder.AppendLine("       FED_Federation t2,");
            vStringBuilder.AppendLine("       CED_CellFederation t3");
            vStringBuilder.AppendLine("where  t1.CEL_Key = t3.CEL_Key");
            vStringBuilder.AppendLine("and    t2.FED_Key = t3.FED_Key");

            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="CellFed"/> object.
        /// </summary>
        /// <param name="aCellFed">A <see cref="Cell"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(CellFed aCellFed, SqlDataReader aSqlDataReader, bool aIncludeAvatar)
        {
            aCellFed.CelKey = Convert.ToInt32(aSqlDataReader["CEL_Key"]);
            aCellFed.CellName = Convert.ToString(aSqlDataReader["CEL_Name"]);
            aCellFed.FedKey = Convert.ToInt32(aSqlDataReader["FED_Key"]);
            aCellFed.FedName = Convert.ToString(aSqlDataReader["FED_Name"]);
            aCellFed.CellFedDateJoined = Convert.ToDateTime(aSqlDataReader["CED_DateJoined"]);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="CellFed"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aCell">A <see cref="CellFed"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, CellFed aCellFed)
        {
            aSqlCommand.Parameters.AddWithValue("@CELKey", aCellFed.CelKey);
            aSqlCommand.Parameters.AddWithValue("@FEDKey", aCellFed.FedKey);
            aSqlCommand.Parameters.AddWithValue("@CELFEDDateJoined", aCellFed.CellFedDateJoined);
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>CellFedList</c> property a <see cref="CellFedCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="CellFed"/>, filtered by the filter properties of the passed <see cref="CellFedCollection"/>.
        /// </summary>
        /// <param name="aCellFedCollection">The <see cref="CellFedCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="CellFedCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aCellFedCollection</c> argument is <c>null</c>.</exception>
        public static void Load(CellFedCollection aCellFedCollection)
        {
            if (aCellFedCollection == null)
            {
                throw new ArgumentNullException("aCellFedCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aCellFedCollection.IsFiltered)
                {
                    if (aCellFedCollection.CellFedFilter.CellfedFilter.CelKey > 0)
                    {
                        vStringBuilder.AppendLine("and t1.CEL_Key = @CELKey");
                        vSqlCommand.Parameters.AddWithValue("@CELKey", aCellFedCollection.CellFedFilter.CellfedFilter.CelKey);
                    }
                    if (aCellFedCollection.CellFedFilter.CellfedFilter.FedKey > 0)
                    {
                        vStringBuilder.AppendLine("and t2.FED_Key = @FEDKey");
                        vSqlCommand.Parameters.AddWithValue("@FEDKey", aCellFedCollection.CellFedFilter.CellfedFilter.FedKey);
                    }
                    if (aCellFedCollection.CellFedFilter.CellfedFilter.CellName != null)
                    {
                        vStringBuilder.AppendFormat("and t1.CEL_Name like '%{0}%'", aCellFedCollection.CellFedFilter.CellfedFilter.CellName);
                    }
                    if (aCellFedCollection.CellFedFilter.CellfedFilter.FedName != null)
                    {
                        vStringBuilder.AppendFormat("and t2.FED_Name like '%{0}%'", aCellFedCollection.CellFedFilter.CellfedFilter.FedName);
                    }
                }
                vStringBuilder.AppendLine("order by t1.CEL_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vCellFed = new CellFed();
                        DataToObject(vCellFed, vSqlDataReader, false);
                        aCellFedCollection.CellFedList.Add(vCellFed);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Save
        public static void Save(CellFedCollection aCellFedCollection)
        {
            Delete(aCellFedCollection.CellFedFilter.CellfedFilter);
            Insert(aCellFedCollection);
        }
        #endregion

        #region Load by Key

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="CellFed"/>, with keys in the <c>aCellFed</c> argument.
        /// </summary>
        /// <param name="aCellFed">A <see cref="CellFed"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aCellFed</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(CellFed aCellFed)
        {
            if (aCellFed == null)
            {
                throw new ArgumentNullException("aCellFed");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and t1.CEL_Key = @CELKey");
                vStringBuilder.AppendLine("and t2.FED_Key = @FEDKey");
                vSqlCommand.Parameters.AddWithValue("@CELKey", aCellFed.CelKey);
                vSqlCommand.Parameters.AddWithValue("@FEDKey", aCellFed.FedKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected CellFED not found: CEL_Key = {0}, FED_Key = {1}", aCellFed.CelKey, aCellFed.FedKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aCellFed, vSqlDataReader, true);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="CellFed"/> passed as an argument via Stored Procedure that returns the newly inserted CellFed Key 
        /// </summary>
        /// <param name="aCellFed">A <see cref="CellFed"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aCellFed</c> argument is <c>null</c>.</exception>
        public static void Insert(CellFedCollection aCellFedCollection)
        {
            if (aCellFedCollection == null)
            {
                throw new ArgumentNullException("aCellFedCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into CED_CellFederation");
                vStringBuilder.AppendLine("       (CEL_Key, FED_Key,");
                vStringBuilder.AppendLine("        CED_DateJoined)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@CELKey, @FEDKey,");
                vStringBuilder.AppendLine("        @CEDDateJoined)");
                vStringBuilder.AppendLine(";");
                vSqlCommand.Parameters.Add("@CELKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@FEDKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@CEDDateJoined", SqlDbType.DateTime);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aCellFedCollection.CellFedList.ForEach(vCellFed =>
                {
                    vSqlCommand.Parameters["@CELKey"].Value = vCellFed.CelKey;
                    vSqlCommand.Parameters["@FEDKey"].Value = vCellFed.FedKey;
                    vSqlCommand.Parameters["@CEDDateJoined"].Value = vCellFed.CellFedDateJoined;
                    vSqlCommand.ExecuteScalar();
                });
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="CellFed"/> passed as an argument .
        /// </summary>
        /// <param name="aCellFed">A <see cref="CellFed"/>.</param>
        public static void Update(CellFed aCellFed)
        {
            if (aCellFed == null)
            {
                throw new ArgumentNullException("aCellFed");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update CED_CellFederation");
                vStringBuilder.AppendLine("set    CED_DateJoined = @CEDDateJoined,");
                vStringBuilder.AppendLine("where  CEL_Key = @CELKey");
                vStringBuilder.AppendLine("and    FED_Key = @FEDKey");
                ObjectToData(vSqlCommand, aCellFed);
                vSqlCommand.Parameters.AddWithValue("@CEDDateJoined", aCellFed.CellFedDateJoined);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="CellFed"/> object passed as an argument.
        /// </summary>
        /// <param name="aCellFed">The <see cref="CellFed"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aCellFed</c> argument is <c>null</c>.</exception>
        public static void Delete(CellFed aCellFed)
        {
            if (aCellFed == null)
            {
                throw new ArgumentNullException("aCellFed");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete CED_CellFederation");
                if (aCellFed.CelKey > 0 && aCellFed.FedKey > 0)
                {
                    vStringBuilder.AppendLine("where  CEL_Key = @CELKey");
                    vStringBuilder.AppendLine("and    FED_Key = @FEDKey");
                }
                else if (aCellFed.CelKey > 0)
                {
                    vStringBuilder.AppendLine("where  CEL_Key = @CELKey");
                }
                else if (aCellFed.FedKey > 0)
                {
                    vStringBuilder.AppendLine("where  FED_Key = @FEDKey");
                }
                vSqlCommand.Parameters.AddWithValue("@CELKey", aCellFed.CelKey);
                vSqlCommand.Parameters.AddWithValue("@FEDKey", aCellFed.FedKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
