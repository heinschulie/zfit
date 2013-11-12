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
    ///   UserData class.
    /// </summary>
    public class UserData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="User"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL(bool aIncludeAvatar)
        {
            string vAvatar = aIncludeAvatar ? ", t1.USR_Avatar" : String.Empty;
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.USR_Key, t1.USR_ID, t1.USR_Password, t1.USR_Name, t1.USR_Surname,");
            vStringBuilder.AppendFormat("       t1.USR_Email, t1.USR_Mobile, t1.USR_Phone, t1.USR_Fax, t1.USR_WebContact, t1.USR_WebTitle{0}", vAvatar).AppendLine();
            vStringBuilder.AppendLine("from   USR_User t1");

            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="User"/> object.
        /// </summary>
        /// <param name="aUser">A <see cref="User"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(User aUser, SqlDataReader aSqlDataReader, bool aIncludeAvatar)
        {
            aUser.UsrKey = Convert.ToInt32(aSqlDataReader["USR_Key"]);
            aUser.UsrID = Convert.ToString(aSqlDataReader["USR_ID"]);
            aUser.UsrPassword = Convert.ToString(aSqlDataReader["USR_Password"]);
            aUser.UsrName = Convert.ToString(aSqlDataReader["USR_Name"]);
            aUser.UsrSurname = Convert.ToString(aSqlDataReader["USR_Surname"]);
            aUser.UsrEmail = Convert.ToString(aSqlDataReader["USR_Email"]);
            aUser.UsrMobile = Convert.ToString(aSqlDataReader["USR_Mobile"]);
            aUser.UsrPhone = Convert.ToString(aSqlDataReader["USR_Phone"]);
            aUser.UsrFax = Convert.ToString(aSqlDataReader["USR_Fax"]);
            aUser.UsrWebContact = Convert.ToString(aSqlDataReader["USR_WebContact"]) == "Y";
            aUser.UsrWebTitle = Convert.ToString(aSqlDataReader["USR_WebTitle"]);
            if (aIncludeAvatar)
            {
                aUser.UsrAvatar = CommonUtils.DbValueTo<byte[]>(aSqlDataReader["USR_Avatar"], null);
            }
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="User"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aUser">A <see cref="User"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, User aUser)
        {

            aSqlCommand.Parameters.AddWithValue("@USRID", aUser.UsrID);
            aSqlCommand.Parameters.AddWithValue("@USRPassword", aUser.UsrPassword);
            aSqlCommand.Parameters.AddWithValue("@USRName", aUser.UsrName);
            aSqlCommand.Parameters.AddWithValue("@USRSurname", aUser.UsrSurname);
            aSqlCommand.Parameters.AddWithValue("@USREmail", aUser.UsrEmail);
            aSqlCommand.Parameters.AddWithValue("@USRMobile", aUser.UsrMobile);
            aSqlCommand.Parameters.AddWithValue("@USRPhone", aUser.UsrPhone);
            aSqlCommand.Parameters.AddWithValue("@USRFax", aUser.UsrFax);
            aSqlCommand.Parameters.AddWithValue("@USRWebContact", aUser.UsrWebContact ? "Y" : "N");
            aSqlCommand.Parameters.AddWithValue("@USRWebTitle", aUser.UsrWebTitle);
            if (aUser.UsrAvatar == null)
            {
                aSqlCommand.Parameters.Add("@USRAvatar", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@USRAvatar", aUser.UsrAvatar);
            }
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>UserList</c> property a <see cref="UserCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="User"/>, filtered by the filter properties of the passed <see cref="UserCollection"/>.
        /// </summary>
        /// <param name="aUserCollection">The <see cref="UserCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="UserCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aUserCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserCollection aUserCollection)
        {
            if (aUserCollection == null)
            {
                throw new ArgumentNullException("aUserCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL(false);
                if (aUserCollection.IsFiltered)
                {
                    vStringBuilder.AppendLine("where t1.USR_WebContact = 'Y'");
                }
                vStringBuilder.AppendLine("order by t1.USR_ID");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vUser = new User();
                        DataToObject(vUser, vSqlDataReader, false);
                        aUserCollection.UserList.Add(vUser);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load by ID

        /// <summary>
        /// Loads the User by the UsrID of the argument User.
        /// </summary>
        /// <param name="aUser">A user.</param>
        public static void LoadById(User aUser)
        {
            if (aUser == null)
            {
                throw new ArgumentNullException("aUser");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL(true);
                vStringBuilder.AppendLine("where USR_ID = @USRID");
                vSqlCommand.Parameters.AddWithValue("@USRID", aUser.UsrID);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!(vSqlDataReader.HasRows))
                    {
                        throw new Exception(String.Format("Expected User not found: USR_ID = {0}", aUser.UsrID));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aUser, vSqlDataReader, true);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load by Key

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="User"/>, with keys in the <c>aUser</c> argument.
        /// </summary>
        /// <param name="aUser">A <see cref="User"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aUser</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(User aUser)
        {
            if (aUser == null)
            {
                throw new ArgumentNullException("aUser");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL(true);
                vStringBuilder.AppendLine("where t1.USR_Key = @USRKey");
                vSqlCommand.Parameters.AddWithValue("@USRKey", aUser.UsrKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected User not found: USR_Key = {0}", aUser.UsrKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aUser, vSqlDataReader, true);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="User"/> passed as an argument via Stored Procedure that returns the newly inserted User Key 
        /// </summary>
        /// <param name="aUser">A <see cref="User"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aUser</c> argument is <c>null</c>.</exception>
        public static void Insert(User aUser)
        {
            if (aUser == null)
            {
                throw new ArgumentNullException("aUser");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into USR_User");
                vStringBuilder.AppendLine("       (USR_ID, USR_Password, USR_Name, USR_Surname, USR_Email,");
                vStringBuilder.AppendLine("        USR_Mobile, USR_Phone, USR_Fax, USR_WebContact, USR_WebTitle, USR_Avatar)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@USRID, @USRPassword, @USRName, @USRSurname, @USREmail,");
                vStringBuilder.AppendLine("        @USRMobile, @USRPhone, @USRFax, @USRWebContact, @USRWebTitle, @USRAvatar)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aUser);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aUser.UsrKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="User"/> passed as an argument .
        /// </summary>
        /// <param name="aUser">A <see cref="User"/>.</param>
        public static void Update(User aUser)
        {
            if (aUser == null)
            {
                throw new ArgumentNullException("aUser");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update USR_User");
                vStringBuilder.AppendLine("set    USR_ID = @USRID,");
                vStringBuilder.AppendLine("       USR_Password = @USRPassword,");
                vStringBuilder.AppendLine("       USR_Name = @USRName,");
                vStringBuilder.AppendLine("       USR_Surname = @USRSurname,");
                vStringBuilder.AppendLine("       USR_Email = @USREmail,");
                vStringBuilder.AppendLine("       USR_Mobile = @USRMobile,");
                vStringBuilder.AppendLine("       USR_Phone = @USRPhone,");
                vStringBuilder.AppendLine("       USR_Fax = @USRFax,");
                vStringBuilder.AppendLine("       USR_WebContact = @USRWebContact,");
                vStringBuilder.AppendLine("       USR_WebTitle = @USRWebTitle,");
                vStringBuilder.AppendLine("       USR_Avatar = @USRAvatar");
                vStringBuilder.AppendLine("where  USR_Key = @USRKey");
                ObjectToData(vSqlCommand, aUser);
                vSqlCommand.Parameters.AddWithValue("@USRKey", aUser.UsrKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="User"/> object passed as an argument.
        /// </summary>
        /// <param name="aUser">The <see cref="User"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aUser</c> argument is <c>null</c>.</exception>
        public static void Delete(User aUser)
        {
            if (aUser == null)
            {
                throw new ArgumentNullException("aUser");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete USR_User");
                vStringBuilder.AppendLine("where  USR_Key = @USRKey");
                vSqlCommand.Parameters.AddWithValue("@USRKey", aUser.UsrKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
     }
 }