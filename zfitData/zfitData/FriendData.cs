using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Zephry;

namespace zfit
{
    public class FriendData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="Friend"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select  t1.FAN_Key as 'Friend1_Key', t1.FAN_Name as 'Friend1_Name', t1.FAN_Surname as 'Friend1_Surname',");
            vStringBuilder.AppendLine("        t2.FAN_Key as 'Friend2_Key', t2.FAN_Name as 'Friend2_Name', t2.FAN_Surname as 'Friend2_Surname',");
            vStringBuilder.AppendLine("        t3.FRD_DateEstablished, t3.REL_Key as 'Relationship_Key', t4.REL_Type as 'Relationship_Type'");
            vStringBuilder.AppendLine("from   FAN_Fanatic t1, ");
            vStringBuilder.AppendLine("       FAN_Fanatic t2,");
            vStringBuilder.AppendLine("       FRD_Friend t3,");
            vStringBuilder.AppendLine("       REL_Relationship t4");
            vStringBuilder.AppendLine("where  t1.FAN_Key = t3.FAN_Key1");
            vStringBuilder.AppendLine("and    and t2.FAN_Key = t3.FAN_Key2");
            vStringBuilder.AppendLine("and    and t4.REL_Key = t3.REL_Key");
            
            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="Friend"/> object.
        /// </summary>
        /// <param name="aFriend">A <see cref="Fanatic"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(Friend aFriend, SqlDataReader aSqlDataReader, bool aIncludeAvatar)
        {
            aFriend.Fan1Key = Convert.ToInt32(aSqlDataReader["FAN_Key"]);
            aFriend.Fan1Name = Convert.ToString(aSqlDataReader["FAN_Name"]);
            aFriend.Fan1Surname = Convert.ToString(aSqlDataReader["FAN_Surname"]);
            aFriend.Fan2Key = Convert.ToInt32(aSqlDataReader["FAN_Key"]);
            aFriend.Fan2Name = Convert.ToString(aSqlDataReader["FAN_Name"]);
            aFriend.Fan2Surname = Convert.ToString(aSqlDataReader["FAN_Surname"]);
            aFriend.FriendDateEstablished = Convert.ToDateTime(aSqlDataReader["FRD_DateEstablished,"]);
            aFriend.Relationship = Convert.ToInt32(aSqlDataReader["Relationship_Key"]);
            aFriend.RelationshipType = Convert.ToString(aSqlDataReader["Relationship_Type"]);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="Friend"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aFanatic">A <see cref="Friend"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, Friend aFriend)
        {
            aSqlCommand.Parameters.AddWithValue("@FAN1Key", aFriend.Fan1Key);
            aSqlCommand.Parameters.AddWithValue("@FAN2Key", aFriend.Fan2Key);
            aSqlCommand.Parameters.AddWithValue("@FRDDateEstablished", aFriend.FriendDateEstablished);
            aSqlCommand.Parameters.AddWithValue("@RELKey", aFriend.RelationshipType);
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>FriendList</c> property a <see cref="FriendCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="Friend"/>, filtered by the filter properties of the passed <see cref="FriendCollection"/>.
        /// </summary>
        /// <param name="aFriendCollection">The <see cref="FriendCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="FriendCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aFriendCollection</c> argument is <c>null</c>.</exception>
        public static void Load(FriendCollection aFriendCollection)
        {
            if (aFriendCollection == null)
            {
                throw new ArgumentNullException("aFriendCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aFriendCollection.IsFiltered)
                {
                    if (aFriendCollection.FriendFilter.FriendshipFilter.Fan1Key > 0)
                    {
                        vStringBuilder.AppendLine("and (t1.FAN_Key = @FAN1Key or t2.FAN_Key = @FAN1Key)");
                        vSqlCommand.Parameters.AddWithValue("@FAN1Key", aFriendCollection.FriendFilter.FriendshipFilter.Fan1Key);
                    }
                    if (aFriendCollection.FriendFilter.FriendshipFilter.Fan2Key > 0)
                    {
                        vStringBuilder.AppendLine("and (t2.FAN_Key = @FAN2Key or t2.FAN_Key = @FAN2Key)");
                        vSqlCommand.Parameters.AddWithValue("@FAN2Key", aFriendCollection.FriendFilter.FriendshipFilter.Fan2Key);
                    }
                    if (aFriendCollection.FriendFilter.FriendshipFilter.Fan1Name != null)
                    {
                        vStringBuilder.AppendFormat("and (t1.FAN_Name like '%{0}%' or t2.FAN_Name like '%{0}%')", aFriendCollection.FriendFilter.FriendshipFilter.Fan1Name);
                    }
                    if (aFriendCollection.FriendFilter.FriendshipFilter.Fan2Name != null)
                    {
                        vStringBuilder.AppendFormat("and (t1.FAN_Name like '%{0}%' or t2.FAN_Name like '%{0}%')", aFriendCollection.FriendFilter.FriendshipFilter.Fan2Name);
                    }
                }
                vStringBuilder.AppendLine("order by t3.FRD_DateEstablished");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vFriend = new Friend();
                        DataToObject(vFriend, vSqlDataReader, false);
                        aFriendCollection.FriendList.Add(vFriend);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Save
        public static void Save(FriendCollection aFriendCollection)
        {
            Delete(aFriendCollection.FriendFilter.FriendshipFilter);
            Insert(aFriendCollection);
        }
        #endregion

        #region Load by Key

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Friend"/>, with keys in the <c>aFriend</c> argument.
        /// </summary>
        /// <param name="aFriend">A <see cref="Friend"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFriend</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(Friend aFriend)
        {
            if (aFriend == null)
            {
                throw new ArgumentNullException("aFriend");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and t1.FAN_Key = @FAN1Key");
                vStringBuilder.AppendLine("and t2.FAN_Key = @FAN2Key");
                vSqlCommand.Parameters.AddWithValue("@FAN1Key", aFriend.Fan1Key);
                vSqlCommand.Parameters.AddWithValue("@FAN2Key", aFriend.Fan2Key);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected Friendship not found: FAN_Key1 = {0}, FAN_Key2 = {1}", aFriend.Fan1Key, aFriend.Fan2Key));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aFriend, vSqlDataReader, true);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Friend"/> passed as an argument via Stored Procedure that returns the newly inserted Friend Key 
        /// </summary>
        /// <param name="aFriend">A <see cref="Friend"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aFriend</c> argument is <c>null</c>.</exception>
        public static void Insert(FriendCollection aFriendCollection)
        {
            if (aFriendCollection == null)
            {
                throw new ArgumentNullException("aFriendCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into FRD_Friend");
                vStringBuilder.AppendLine("       (FAN_Key, FAN_Key,");
                vStringBuilder.AppendLine("        REL_Key,");
                vStringBuilder.AppendLine("        FRD_DateJoined)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@FAN1Key, @FAN2Key,");
                vStringBuilder.AppendLine("        @RELKey, @FRDDateJoined)");
                vStringBuilder.AppendLine(";");
                vSqlCommand.Parameters.Add("@FAN1Key", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@FAN2Key", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@RELKey", SqlDbType.Int);
                vSqlCommand.Parameters.Add("@FRDDateJoined", SqlDbType.DateTime);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aFriendCollection.FriendList.ForEach(vFriend =>
                {
                    vSqlCommand.Parameters["@FAN1Key"].Value = vFriend.Fan1Key;
                    vSqlCommand.Parameters["@FAN2Key"].Value = vFriend.Fan2Key;
                    vSqlCommand.Parameters["@RELKey"].Value = vFriend.Relationship; 
                    vSqlCommand.Parameters["@FRDDateJoined"].Value = vFriend.FriendDateEstablished;
                    vSqlCommand.ExecuteScalar();
                });
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Friend"/> passed as an argument .
        /// </summary>
        /// <param name="aFriend">A <see cref="Friend"/>.</param>
        public static void Update(Friend aFriend)
        {
            if (aFriend == null)
            {
                throw new ArgumentNullException("aFriend");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update FRD_Friend");
                vStringBuilder.AppendLine("set    REL_Key = @RELKey,");
                vStringBuilder.AppendLine("where  FAN_Key = @FAN1Key");
                vStringBuilder.AppendLine("and    FAN_Key = @FAN2Key");
                vSqlCommand.Parameters.AddWithValue("@RELKey", aFriend.Relationship);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Friend"/> object passed as an argument.
        /// </summary>
        /// <param name="aFriend">The <see cref="Friend"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aFriend</c> argument is <c>null</c>.</exception>
        public static void Delete(Friend aFriend)
        {
            if (aFriend == null)
            {
                throw new ArgumentNullException("aFriend");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete FRD_Friend");
                if (aFriend.Fan1Key > 0 && aFriend.Fan2Key > 0)
                {
                    vStringBuilder.AppendLine("where  FAN_Key = @FAN1Key");
                    vStringBuilder.AppendLine("and    FAN_Key = @FAN2Key");
                }
                else if (aFriend.Fan1Key > 0)
                {
                    vStringBuilder.AppendLine("where  FAN_Key = @FAN1Key");
                }
                else if (aFriend.Fan2Key > 0)
                {
                    vStringBuilder.AppendLine("where  FAN_Key = @FAN2Key");
                }
                vSqlCommand.Parameters.AddWithValue("@FAN1Key", aFriend.Fan1Key);
                vSqlCommand.Parameters.AddWithValue("@FAN2Key", aFriend.Fan2Key);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
