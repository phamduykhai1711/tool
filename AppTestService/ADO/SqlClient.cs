using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Solomon_Invoice.ADO
{
    public class SqlClient : IDisposable
    {
        public string connectionString = "";
        private const int ConnectTimeout = 6 * 50;
        private const int CommandTimeout = 6 * 50;
        private bool disposed = false;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public SqlClient()
        {

        }
        public SqlClient(string connection)
        {
            connectionString = connection;
        }

        public void SetConnectionString(string connection)
        {
            connectionString = connection;
        }

        public object ExecuteScalar(string sql, CommandType commandType = CommandType.Text, Dictionary<string, object> parameters = null)
        {

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlCon))
                    {
                        sqlCommand.CommandType = commandType;
                        sqlCommand.CommandTimeout = CommandTimeout;
                        if (parameters != null && parameters.Count > 0)
                        {
                            foreach (var parameter in parameters)
                            {
                                string key = (parameter.Key.IndexOf("@") != -1)
                                    ? parameter.Key
                                    : "@" + parameter.Key;
                                //sqlCommand.Parameters.Add(key, parameter.Value);
                                sqlCommand.Parameters.AddWithValue(key, parameter.Value);
                            }
                        }
                        sqlCon.Open();
                        object obj = sqlCommand.ExecuteScalar();
                        return obj;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex, "SqlClient -> ExecuteScalar:");
                }
                finally
                {
                    if (sqlCon.State == ConnectionState.Open)
                    {
                        sqlCon.Close();
                    }
                }
            }
            return null;
        }
        public int ExecuteNonQuery(string sql, CommandType commandType = CommandType.Text, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlCon))
                    {
                        sqlCommand.CommandType = commandType;
                        sqlCommand.CommandTimeout = CommandTimeout;
                        if (parameters != null && parameters.Count > 0)
                        {
                            foreach (var parameter in parameters)
                            {
                                string key = (parameter.Key.IndexOf("@") != -1) ? parameter.Key : "@" + parameter.Key;
                                //sqlCommand.Parameters.Add(key, parameter.Value);
                                sqlCommand.Parameters.AddWithValue(key, parameter.Value);
                            }
                        }
                        sqlCon.Open();
                        int totalRecord = sqlCommand.ExecuteNonQuery();
                        return totalRecord;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if (sqlCon.State == ConnectionState.Open)
                    {
                        sqlCon.Close();
                    }
                }
            }
            return -1;
        }

        public DataTable Query(string sql, CommandType commandType = CommandType.Text, Dictionary<string, object> parameters = null)
        {
            DataTable result = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
                    sqlCommand.CommandTimeout = CommandTimeout;
                    if (parameters != null && parameters.Count > 0)
                    {
                        foreach (var parameter in parameters)
                        {
                            string key = (parameter.Key.IndexOf("@") != -1) ? parameter.Key : "@" + parameter.Key;
                            sqlCommand.Parameters.AddWithValue(key, parameter.Value);
                        }
                    }
                    sqlCon.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);

                    sda.Fill(result);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if (sqlCon.State == ConnectionState.Open)
                    {
                        sqlCon.Close();
                    }
                }
            }
            return result;
        }

        public DataSet MultiQuery(string sql, CommandType commandType = CommandType.Text)
        {
            DataSet result = new DataSet();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlCon);
                    sqlCommand.CommandTimeout = CommandTimeout;
                    sqlCon.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
                    sda.Fill(result);
                }
                catch //(Exception ex)
                {

                }
                finally
                {
                    if (sqlCon.State == ConnectionState.Open)
                    {
                        sqlCon.Close();
                    }
                }
            }
            return result;
        }

        protected void Dispose(bool disposing)
        {
            if (this.disposed == true)
                return;

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
