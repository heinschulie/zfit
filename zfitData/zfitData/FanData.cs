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
    ///   FanData class.
    /// </summary>
    public class FanData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="Fan"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL(bool aIncludeAvatar)
        {
            string vAvatar = aIncludeAvatar ? ", t1.FAN_Avatar" : String.Empty;
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.FAN_Key, t1.FAN_UserID, t1.FAN_Password, t1.FAN_Name, t1.FAN_Surname,");
            vStringBuilder.AppendFormat("       t1.FAN_Email{0}", vAvatar).AppendLine();
            vStringBuilder.AppendLine("from   FAN_Fanatic t1");

            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="Fan"/> object.
        /// </summary>
        /// <param name="aFan">A <see cref="Fan"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(Fan aFan, SqlDataReader aSqlDataReader, bool aIncludeAvatar)
        {
            aFan.FannKey = Convert.ToInt32(aSqlDataReader["FAN_Key"]);
            aFan.FanUserID = Convert.ToString(aSqlDataReader["FAN_UserID"]);
            aFan.FanPassword = Convert.ToString(aSqlDataReader["FAN_Password"]);
            aFan.FanName = Convert.ToString(aSqlDataReader["FAN_Name"]);
            aFan.FanSurname = Convert.ToString(aSqlDataReader["FAN_Surname"]);
            aFan.FanEmail = Convert.ToString(aSqlDataReader["FAN_Email"]);
            if (aIncludeAvatar)
            {
                aFan.FanAvatar = CommonUtils.DbValueTo<byte[]>(aSqlDataReader["FAN_Avatar"], null);
            }
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="Fan"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aFan">A <see cref="Fan"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, Fan aFan)
        {

            aSqlCommand.Parameters.AddWithValue("@FANID", aFan.FanUserID);
            aSqlCommand.Parameters.AddWithValue("@FANPassword", aFan.FanPassword);
            aSqlCommand.Parameters.AddWithValue("@FANName", aFan.FanName);
            aSqlCommand.Parameters.AddWithValue("@FANSurname", aFan.FanSurname);
            aSqlCommand.Parameters.AddWithValue("@FANEmail", aFan.FanEmail);
            if (aFan.FanAvatar == null)
            {
                aSqlCommand.Parameters.Add("@FANAvatar", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@FANAvatar", aFan.FanAvatar);
            }
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>FanList</c> property a <see cref="FanCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="Fan"/>, filtered by the filter properties of the passed <see cref="FanCollection"/>.
        /// </summary>
        /// <param name="aFanCollection">The <see cref="FanCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="FanCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aFanCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FanCollection aFanCollection)
        {
            if (aFanCollection == null)
            {
                throw new ArgumentNullException("aFanCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL(false);
                //if (aFanCollection.IsFiltered)
                //{
                //    vStringBuilder.AppendLine("where t1.FAN_WebContact = 'Y'");
                //}
                vStringBuilder.AppendLine("order by t1.FAN_UserID");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vFan = new Fan();
                        DataToObject(vFan, vSqlDataReader, false);
                        aFanCollection.FanList.Add(vFan);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load by ID

        /// <summary>
        /// Loads the Fan by the FanID of the argument Fan.
        /// </summary>
        /// <param name="aFan">A user.</param>
        public static void LoadById(Fan aFan)
        {
            if (aFan == null)
            {
                throw new ArgumentNullException("aFan");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL(true);
                vStringBuilder.AppendLine("where FAN_UserID = @FANID");
                vSqlCommand.Parameters.AddWithValue("@FANID", aFan.FanUserID);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!(vSqlDataReader.HasRows))
                    {
                        throw new Exception(String.Format("Expected Fan not found: FAN_ID = {0}", aFan.FanUserID));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aFan, vSqlDataReader, true);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load by Key

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Fan"/>, with keys in the <c>aFan</c> argument.
        /// </summary>
        /// <param name="aFan">A <see cref="Fan"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFan</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(Fan aFan)
        {
            if (aFan == null)
            {
                throw new ArgumentNullException("aFan");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL(true);
                vStringBuilder.AppendLine("where t1.FAN_Key = @FANKey");
                vSqlCommand.Parameters.AddWithValue("@FANKey", aFan.FannKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected Fan not found: FAN_Key = {0}", aFan.FannKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aFan, vSqlDataReader, true);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Fan"/> passed as an argument via Stored Procedure that returns the newly inserted Fan Key 
        /// </summary>
        /// <param name="aFan">A <see cref="Fan"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFan</c> argument is <c>null</c>.</exception>
        public static void Insert(Fan aFan)
        {
            if (aFan == null)
            {
                throw new ArgumentNullException("aFan");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into FAN_Fanatic");
                vStringBuilder.AppendLine("       (FAN_UserID, FAN_Password, FAN_Name, FAN_Surname, FAN_Email,");
                vStringBuilder.AppendLine("        FAN_Avatar)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@FANID, @FANPassword, @FANName, @FANSurname, @FANEmail,");
                vStringBuilder.AppendLine("        @FANAvatar)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aFan);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aFan.FannKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Fan"/> passed as an argument .
        /// </summary>
        /// <param name="aFan">A <see cref="Fan"/>.</param>
        public static void Update(Fan aFan)
        {
            if (aFan == null)
            {
                throw new ArgumentNullException("aFan");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update FAN_Fanatic");
                vStringBuilder.AppendLine("set    FAN_UserID = @FANID,");
                vStringBuilder.AppendLine("       FAN_Password = @FANPassword,");
                vStringBuilder.AppendLine("       FAN_Name = @FANName,");
                vStringBuilder.AppendLine("       FAN_Surname = @FANSurname,");
                vStringBuilder.AppendLine("       FAN_Email = @FANEmail,");
                vStringBuilder.AppendLine("       FAN_Avatar = @FANAvatar");
                vStringBuilder.AppendLine("where  FAN_Key = @FANKey");
                ObjectToData(vSqlCommand, aFan);
                vSqlCommand.Parameters.AddWithValue("@FANKey", aFan.FannKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Fan"/> object passed as an argument.
        /// </summary>
        /// <param name="aFan">The <see cref="Fan"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aFan</c> argument is <c>null</c>.</exception>
        public static void Delete(Fan aFan)
        {
            if (aFan == null)
            {
                throw new ArgumentNullException("aFan");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete FAN_Fanatic");
                vStringBuilder.AppendLine("where  FAN_Key = @FANKey");
                vSqlCommand.Parameters.AddWithValue("@FANKey", aFan.FannKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
     }
 }