using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Zephry;

namespace zfit
{
    public class CellFanData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="CellFan"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.CEL_Key, t1.CEL_Name, t2.FAN_Key, t2.FAN_Name, t2.FAN_Surname, t3.CAN_DateJoined");
            vStringBuilder.AppendLine("from   CEL_Cell t1, ");
            vStringBuilder.AppendLine("       FAN_Fanatic t2,");
            vStringBuilder.AppendLine("       CAN_CellFan t3");
            vStringBuilder.AppendLine("where  t1.CEL_Key = t3.CEL_Key");
            vStringBuilder.AppendLine("and    t2.FAN_Key = t3.FAN_Key");

            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="CellFan"/> object.
        /// </summary>
        /// <param name="aCellFan">A <see cref="Cell"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(CellFan aCellFan, SqlDataReader aSqlDataReader, bool aIncludeAvatar)
        {
            aCellFan.CelKey = Convert.ToInt32(aSqlDataReader["CEL_Key"]);
            aCellFan.CellName = Convert.ToString(aSqlDataReader["CEL_Name"]);
            aCellFan.FanKey = Convert.ToInt32(aSqlDataReader["FAN_Key"]);
            aCellFan.FanName = Convert.ToString(aSqlDataReader["FAN_Name"]);
            aCellFan.FanSurname = Convert.ToString(aSqlDataReader["FAN_Surname"]);
            aCellFan.CellFanDateJoined = Convert.ToDateTime(aSqlDataReader["CAN_DateJoined"]);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="CellFan"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aCell">A <see cref="CellFan"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, CellFan aCellFan)
        {
            aSqlCommand.Parameters.AddWithValue("@CELKey", aCellFan.CelKey);
            aSqlCommand.Parameters.AddWithValue("@FANKey", aCellFan.FanKey);
            aSqlCommand.Parameters.AddWithValue("@CELFANDateJoined", aCellFan.CellFanDateJoined);
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>CellFanList</c> property a <see cref="CellFanCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="CellFan"/>, filtered by the filter properties of the passed <see cref="CellFanCollection"/>.
        /// </summary>
        /// <param name="aCellFanCollection">The <see cref="CellFanCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="CellFanCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aCellFanCollection</c> argument is <c>null</c>.</exception>
        public static void Load(CellFanCollection aCellFanCollection)
        {
            if (aCellFanCollection == null)
            {
                throw new ArgumentNullException("aCellFanCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aCellFanCollection.IsFiltered)
                {
                    if (aCellFanCollection.CellFanFilter.CellfanFilter.CelKey > 0)
                    {
                        vStringBuilder.AppendLine("and t1.CEL_Key = @CELKey");
                        vSqlCommand.Parameters.AddWithValue("@CELKey", aCellFanCollection.CellFanFilter.CellfanFilter.CelKey);
                    }
                    if (aCellFanCollection.CellFanFilter.CellfanFilter.FanKey > 0)
                    {
                        vStringBuilder.AppendLine("and t2.FAN_Key = @FANKey");
                        vSqlCommand.Parameters.AddWithValue("@FANKey", aCellFanCollection.CellFanFilter.CellfanFilter.FanKey);
                    }
                    if (aCellFanCollection.CellFanFilter.CellfanFilter.CellName != null)
                    {
                        vStringBuilder.AppendFormat("and t1.CEL_Name like '%{0}%'", aCellFanCollection.CellFanFilter.CellfanFilter.CellName);
                    }
                    if (aCellFanCollection.CellFanFilter.CellfanFilter.FanName != null)
                    {
                        vStringBuilder.AppendFormat("and t2.FAN_Name like '%{0}%'", aCellFanCollection.CellFanFilter.CellfanFilter.FanName);
                    }
                }
                vStringBuilder.AppendLine("order by t1.CEL_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vCellFan = new CellFan();
                        DataToObject(vCellFan, vSqlDataReader, false);
                        aCellFanCollection.CellFanList.Add(vCellFan);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Save
        public static void Save(CellFanCollection aCellFanCollection)
        {
            Delete(aCellFanCollection.CellFanFilter.CellfanFilter);
            Insert(aCellFanCollection);
        }
        #endregion

        #region Load by Key

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="CellFan"/>, with keys in the <c>aCellFan</c> argument.
        /// </summary>
        /// <param name="aCellFan">A <see cref="CellFan"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aCellFan</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(CellFan aCellFan)
        {
            if (aCellFan == null)
            {
                throw new ArgumentNullException("aCellFan");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and t1.CEL_Key = @CELKey");
                vStringBuilder.AppendLine("and t2.FAN_Key = @FANKey");
                vSqlCommand.Parameters.AddWithValue("@CELKey", aCellFan.CelKey);
                vSqlCommand.Parameters.AddWithValue("@FANKey", aCellFan.FanKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected CellFAN not found: CEL_Key = {0}, FAN_Key = {1}", aCellFan.CelKey, aCellFan.FanKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aCellFan, vSqlDataReader, true);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="CellFan"/> passed as an argument via Stored Procedure that returns the newly inserted CellFan Key 
        /// </summary>
        /// <param name="aCellFan">A <see cref="CellFan"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aCellFan</c> argument is <c>null</c>.</exception>
        public static void Insert(CellFanCollection aCellFanCollection)
        {
            if (aCellFanCollection == null)
            {
                throw new ArgumentNullException("aCellFanCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into CAN_CellFan");
                vStringBuilder.AppendLine("       (CEL_Key, FAN_Key,");
                vStringBuilder.AppendLine("        CAN_DateJoined)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@CELKey, @FANKey,");
                vStringBuilder.AppendLine("        @CANDateJoined)");
                vStringBuilder.AppendLine(";");
                vSqlCommand.Parameters.Add("@CELKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@FANKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@CANDateJoined", SqlDbType.DateTime);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aCellFanCollection.CellFanList.ForEach(vCellFan =>
                {
                    vSqlCommand.Parameters["@CELKey"].Value = vCellFan.CelKey;
                    vSqlCommand.Parameters["@FANKey"].Value = vCellFan.FanKey;
                    vSqlCommand.Parameters["@CANDateJoined"].Value = vCellFan.CellFanDateJoined;
                    vSqlCommand.ExecuteScalar();
                });
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="CellFan"/> passed as an argument .
        /// </summary>
        /// <param name="aCellFan">A <see cref="CellFan"/>.</param>
        public static void Update(CellFan aCellFan)
        {
            if (aCellFan == null)
            {
                throw new ArgumentNullException("aCellFan");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update CAN_CellFan");
                vStringBuilder.AppendLine("set    CAN_DateJoined = @CANDateJoined,");
                vStringBuilder.AppendLine("where  CEL_Key = @CELKey");
                vStringBuilder.AppendLine("and    FAN_Key = @FANKey");
                ObjectToData(vSqlCommand, aCellFan);
                vSqlCommand.Parameters.AddWithValue("@CANDateJoined", aCellFan.CellFanDateJoined);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="CellFan"/> object passed as an argument.
        /// </summary>
        /// <param name="aCellFan">The <see cref="CellFan"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aCellFan</c> argument is <c>null</c>.</exception>
        public static void Delete(CellFan aCellFan)
        {
            if (aCellFan == null)
            {
                throw new ArgumentNullException("aCellFan");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete CAN_CellFan");
                if (aCellFan.CelKey > 0 && aCellFan.FanKey > 0)
                {
                    vStringBuilder.AppendLine("where  CEL_Key = @CELKey");
                    vStringBuilder.AppendLine("and    FAN_Key = @FANKey");
                }
                else if (aCellFan.CelKey > 0)
                {
                    vStringBuilder.AppendLine("where  CEL_Key = @CELKey");
                }
                else if (aCellFan.FanKey > 0)
                {
                    vStringBuilder.AppendLine("where  FAN_Key = @FANKey");
                }
                vSqlCommand.Parameters.AddWithValue("@CELKey", aCellFan.CelKey);
                vSqlCommand.Parameters.AddWithValue("@FANKey", aCellFan.FanKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
