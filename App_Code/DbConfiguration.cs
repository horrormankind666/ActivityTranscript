using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

public class DbConfiguration
{
    public static SqlConnection GetConnection()
    {
        string connectionStr = ConfigurationManager.ConnectionStrings["eStudentConn"].ToString();

        return new SqlConnection(connectionStr);
    }
    //public static SqlConnection GetEPan()
    //{
    //    string connectionStr = ConfigurationManager.ConnectionStrings["ePan"].ToString();

    //    return new SqlConnection(connectionStr);
    //}

    public static DataSet ExecuteQueryWithSqlCommand(string query, params SqlParameter[] parameters) {
        return ExecuteQueryWithSqlCommand(query, string.Empty, parameters);
    }
    public static DataSet ExecuteQueryWithSqlCommand(string query, string dataSetName, params SqlParameter[] parameters)
    {
        DataSet _ds = new DataSet();

        using (SqlConnection _conn = GetConnection())
        {
            SqlCommand _cmd = new SqlCommand(query);
            _cmd.Connection = _conn;
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = query;

            foreach (var parameter in parameters)
            {
                _cmd.Parameters.Add(parameter);
            }

            SqlDataAdapter _da = new SqlDataAdapter(_cmd);
            _da.Fill(_ds);
        }
        if (!string.IsNullOrEmpty(dataSetName))
            _ds.DataSetName = dataSetName;

        return _ds;
    }
    public static DataSet ExecuteQuery(string query, params SqlParameter[] parameters)
    {
        return ExecuteQuery(query, string.Empty, CommandType.Text, parameters);
    }
    public static DataSet ExecuteQuery(string query, string dataSetName, params SqlParameter[] parameters)
    {
        return ExecuteQuery(query, dataSetName, CommandType.Text, parameters);
    }
    public static DataSet ExecuteQuery(string query, CommandType commandType, params SqlParameter[] parameters)
    {
        return ExecuteQuery(query, string.Empty, commandType, parameters);
    }
    public static DataSet ExecuteQuery(string query, string dataSetName, CommandType commandType, params SqlParameter[] parameters)
    {
        DataSet _ds = new DataSet();

        using (SqlConnection _conn = GetConnection())
        {
            SqlCommand _cmd = new SqlCommand(query);
            _cmd.Connection = _conn;
            _cmd.CommandType = commandType;
            _cmd.CommandText = query;

            foreach (var parameter in parameters)
            {
                _cmd.Parameters.Add(parameter);
            }

            SqlDataAdapter _da = new SqlDataAdapter(_cmd);
            _da.Fill(_ds);
        }
        if (!string.IsNullOrEmpty(dataSetName))
            _ds.DataSetName = dataSetName;

        return _ds;
    }
    public static int ExecuteNoneQuery(string query, params SqlParameter[] parameters)
    {
        return ExecuteNoneQuery(query, CommandType.Text, parameters);
    }
    public static int ExecuteNoneQuery(string query, CommandType commandType, params SqlParameter[] parameters)
    {
        try
        {
            using (SqlConnection _conn = GetConnection())
            {
                SqlCommand _cmd = new SqlCommand(query);
                _cmd.Connection = _conn;
                _cmd.CommandType = commandType;
                _cmd.CommandText = query;

                foreach (var parameter in parameters)
                {
                    _cmd.Parameters.Add(parameter);
                }

                _conn.Open();
                return _cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex) {
            return 0;
        }
    }
    public static object ExecuteScalar(string query, params SqlParameter[] parameters) {
        return ExecuteScalar(query, CommandType.Text, parameters);
    }
    public static object ExecuteScalar(string query, CommandType commandType, params SqlParameter[] parameters) {
        try
        {
            using (SqlConnection _conn = GetConnection())
            {
                SqlCommand _cmd = new SqlCommand(query);
                _cmd.Connection = _conn;
                _cmd.CommandType = commandType;
                _cmd.CommandText = query;

                foreach (var parameter in parameters)
                {
                    _cmd.Parameters.Add(parameter);
                }

                _conn.Open();
                return _cmd.ExecuteScalar();
            }
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
    public static DataSet XMLTextToDataSet(string xmlStr) {
        try
        {
            StringReader _sr = new StringReader(System.Uri.UnescapeDataString(xmlStr));
            DataSet _ds = new DataSet();
            _ds.ReadXml(_sr);

            return _ds;
        }
        catch {
            return new DataSet();
        }
    }
}
public static class DataTableExtension
{
    public static DataTable OrderBy(this DataTable _dt, params Orderer[] objs)
    {
        dynamic sortObj = _dt;
        foreach (var obj in objs)
        {
            if (sortObj is IOrderedEnumerable<DataRow>)
                if (obj.direction == SortDirection.Ascending)
                    sortObj = ((IOrderedEnumerable<DataRow>)sortObj).ThenBy(row => row.Field<object>(obj.key));
                else
                    sortObj = ((IOrderedEnumerable<DataRow>)sortObj).ThenByDescending(row => row.Field<object>(obj.key));
            else
                if (obj.direction == SortDirection.Ascending)
                    sortObj = ((DataTable)sortObj).Select().OrderBy(row => row.Field<object>(obj.key));
                else
                    sortObj = ((DataTable)sortObj).Select().OrderByDescending(row => row.Field<object>(obj.key));
        }
        if (objs.Count() > 0)
            return ((IOrderedEnumerable<DataRow>)sortObj).CopyToDataTable();
        else
            return _dt;
    }
        
}
public class Orderer
{
    public string key { get; set; }
    public SortDirection direction { get; set; }
}
public enum SortDirection
{
    Ascending,
    Descending
}