using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Zephry;

namespace zfit
{
    public class CellData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="Cell"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL(bool aIncludeAvatar)
        {
            string vAvatar = aIncludeAvatar ? ", t1.CEL_Avatar" : String.Empty;
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.CEL_Key, t1.CEL_Name, t1.FAN_Key,");
            vStringBuilder.AppendFormat("(select FAN_Name from FAN_Fanatic where FAN_Key = t1.FAN_Key) as CellOwner{0}", vAvatar).AppendLine(); //Sub-query to ascertain owner name 
            vStringBuilder.AppendLine("from   CEL_Cell t1");

            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="Cell"/> object.
        /// </summary>
        /// <param name="aCell">A <see cref="Cell"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(Cell aCell, SqlDataReader aSqlDataReader, bool aIncludeAvatar)
        {
            aCell.CelKey = Convert.ToInt32(aSqlDataReader["CEL_Key"]);
            aCell.CellName = Convert.ToString(aSqlDataReader["CEL_Name"]);
            aCell.FanKey = Convert.ToInt32(aSqlDataReader["FAN_Key"]);
            aCell.FanName = Convert.ToString(aSqlDataReader["CellOwner"]);
            
            if (aIncludeAvatar)
            {
                aCell.CellAvatar = CommonUtils.DbValueTo<byte[]>(aSqlDataReader["CEL_Avatar"], null);
            }
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="Cell"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aCell">A <see cref="Cell"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, Cell aCell)
        {
            aSqlCommand.Parameters.AddWithValue("@CELName", aCell.CellName);
            aSqlCommand.Parameters.AddWithValue("@FANKey", aCell.FanKey);
            if (aCell.CellAvatar == null)
            {
                aSqlCommand.Parameters.Add("@CELAvatar", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@CELAvatar", aCell.CellAvatar);
            }
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>CellList</c> property a <see cref="CellCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="Cell"/>, filtered by the filter properties of the passed <see cref="CellCollection"/>.
        /// </summary>
        /// <param name="aCellCollection">The <see cref="CellCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="CellCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aCellCollection</c> argument is <c>null</c>.</exception>
        public static void Load(CellCollection aCellCollection)
        {
            if (aCellCollection == null)
            {
                throw new ArgumentNullException("aCellCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL(false);
                if (aCellCollection.IsFiltered)
                {
                    vStringBuilder.AppendFormat("where t1.CEL_Name is like '%{0}%", aCellCollection.CellFilter.CellNameFilter);
                }
                vStringBuilder.AppendLine("order by t1.CEL_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vCell = new Cell();
                        DataToObject(vCell, vSqlDataReader, false);
                        aCellCollection.CellList.Add(vCell);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load by Key

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Cell"/>, with keys in the <c>aCell</c> argument.
        /// </summary>
        /// <param name="aCell">A <see cref="Cell"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aCell</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(Cell aCell)
        {
            if (aCell == null)
            {
                throw new ArgumentNullException("aCell");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL(true);
                vStringBuilder.AppendLine("where t1.CEL_Key = @CELKey");
                vSqlCommand.Parameters.AddWithValue("@CELKey", aCell.CelKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected Cell not found: CEL_Key = {0}", aCell.CelKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aCell, vSqlDataReader, true);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Cell"/> passed as an argument via Stored Procedure that returns the newly inserted Cell Key 
        /// </summary>
        /// <param name="aCell">A <see cref="Cell"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aCell</c> argument is <c>null</c>.</exception>
        public static void Insert(Cell aCell)
        {
            if (aCell == null)
            {
                throw new ArgumentNullException("aCell");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into CEL_Cell");
                vStringBuilder.AppendLine("       (CEL_Name, FAN_Key,");
                vStringBuilder.AppendLine("        CEL_Avatar)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@CELName, @FANKey,");
                vStringBuilder.AppendLine("        @CELAvatar)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aCell);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aCell.CelKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Cell"/> passed as an argument .
        /// </summary>
        /// <param name="aCell">A <see cref="Cell"/>.</param>
        public static void Update(Cell aCell)
        {
            if (aCell == null)
            {
                throw new ArgumentNullException("aCell");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update CEL_Cell");
                vStringBuilder.AppendLine("set    CEL_Name = @CELName,");
                vStringBuilder.AppendLine("       FAN_Key = @FANKey,");
                vStringBuilder.AppendLine("       CEL_Avatar = @CELAvatar");
                vStringBuilder.AppendLine("where  CEL_Key = @CELKey");
                ObjectToData(vSqlCommand, aCell);
                vSqlCommand.Parameters.AddWithValue("@CELKey", aCell.CelKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Cell"/> object passed as an argument.
        /// </summary>
        /// <param name="aCell">The <see cref="Cell"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aCell</c> argument is <c>null</c>.</exception>
        public static void Delete(Cell aCell)
        {
            if (aCell == null)
            {
                throw new ArgumentNullException("aCell");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete CEL_Cell");
                vStringBuilder.AppendLine("where  CEL_Key = @CELKey");
                vSqlCommand.Parameters.AddWithValue("@CELKey", aCell.CelKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
