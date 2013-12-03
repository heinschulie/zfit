using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Zephry;

namespace zfit
{
    public class ExerciseData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="Exercise"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.EXC_Key, t1.EXC_Name, t1.EXC_Type");
            vStringBuilder.AppendLine("from   EXC_Exercise t1");

            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="Exercise"/> object.
        /// </summary>
        /// <param name="aExercise">A <see cref="Exercise"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(Exercise aExercise, SqlDataReader aSqlDataReader)
        {
            aExercise.ExcKey = Convert.ToInt32(aSqlDataReader["EXC_Key"]);
            aExercise.ExcName = Convert.ToString(aSqlDataReader["EXC_Name"]);
            aExercise.ExcType = Convert.ToInt32(aSqlDataReader["EXC_Key"]);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="Exercise"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aExercise">A <see cref="Exercise"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, Exercise aExercise)
        {
            aSqlCommand.Parameters.AddWithValue("@EXCName", aExercise.ExcName);
            aSqlCommand.Parameters.AddWithValue("@EXCType", aExercise.ExcType);
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>ExerciseList</c> property a <see cref="ExerciseCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="Exercise"/>, filtered by the filter properties of the passed <see cref="ExerciseCollection"/>.
        /// </summary>
        /// <param name="aExerciseCollection">The <see cref="ExerciseCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="ExerciseCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aExerciseCollection</c> argument is <c>null</c>.</exception>
        public static void Load(ExerciseCollection aExerciseCollection)
        {
            if (aExerciseCollection == null)
            {
                throw new ArgumentNullException("aExerciseCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aExerciseCollection.IsFiltered)
                {
                    vStringBuilder.AppendFormat("where t1.EXC_Name is like '%{0}%", aExerciseCollection.ExerciseFilter.ExcFilter.ExcName);
                }
                vStringBuilder.AppendLine("order by t1.EXC_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vExercise = new Exercise();
                        DataToObject(vExercise, vSqlDataReader);
                        aExerciseCollection.ExerciseList.Add(vExercise);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load by Key

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Exercise"/>, with keys in the <c>aExercise</c> argument.
        /// </summary>
        /// <param name="aExercise">A <see cref="Exercise"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aExercise</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(Exercise aExercise)
        {
            if (aExercise == null)
            {
                throw new ArgumentNullException("aExercise");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("where t1.EXC_Key = @EXCKey");
                vSqlCommand.Parameters.AddWithValue("@EXCKey", aExercise.ExcKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected Exercise not found: EXC_Key = {0}", aExercise.ExcKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aExercise, vSqlDataReader);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Exercise"/> passed as an argument via Stored Procedure that returns the newly inserted Exercise Key 
        /// </summary>
        /// <param name="aExercise">A <see cref="Exercise"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aExercise</c> argument is <c>null</c>.</exception>
        public static void Insert(Exercise aExercise)
        {
            if (aExercise == null)
            {
                throw new ArgumentNullException("aExercise");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into EXC_Exercise");
                vStringBuilder.AppendLine("       (EXC_Name,");
                vStringBuilder.AppendLine("        EXC_Type)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@EXCName,");
                vStringBuilder.AppendLine("        @EXCType)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aExercise);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aExercise.ExcKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Exercise"/> passed as an argument .
        /// </summary>
        /// <param name="aExercise">A <see cref="Exercise"/>.</param>
        public static void Update(Exercise aExercise)
        {
            if (aExercise == null)
            {
                throw new ArgumentNullException("aExercise");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update EXC_Exercise");
                vStringBuilder.AppendLine("set    EXC_Name = @EXCName,");
                vStringBuilder.AppendLine("       EXC_Type = @EXCType");
                vStringBuilder.AppendLine("where  EXC_Key = @EXCKey");
                ObjectToData(vSqlCommand, aExercise);
                vSqlCommand.Parameters.AddWithValue("@EXCKey", aExercise.ExcKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Exercise"/> object passed as an argument.
        /// </summary>
        /// <param name="aExercise">The <see cref="Exercise"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aExercise</c> argument is <c>null</c>.</exception>
        public static void Delete(Exercise aExercise)
        {
            if (aExercise == null)
            {
                throw new ArgumentNullException("aExercise");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete EXC_Exercise");
                vStringBuilder.AppendLine("where  EXC_Key = @EXCKey");
                vSqlCommand.Parameters.AddWithValue("@EXCKey", aExercise.ExcKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
