using System;
using System.Data;
using System.Data.SqlClient;
using BusinessModel;
using Microsoft.Data.SqlClient;

namespace RazorCrudApp.Data
{
    public class DataAccessLayer
    {
        public readonly ConnectionString _connectionStrings;
        public DataAccessLayer(ConnectionString _con) => this._connectionStrings = _con;

        #region "Return DataSet"
        public DataSet GetDataSet(SqlCommand _cmd)
        {
            try
            {
                using (SqlConnection _con = new SqlConnection(_connectionStrings.DbConnection))
                {
                    _con.Open();
                    using (DataSet _dataset = new DataSet())
                    {
                        _cmd.Connection = _con;
                        _cmd.CommandTimeout = 300;
                        using (SqlDataAdapter _dataAdapter = new SqlDataAdapter())
                        {
                            _dataAdapter.Fill(_dataset);
                        }
                        return _dataset;
                    }
                }
            }
            finally
            {
                _cmd.Dispose();
            }
        }
        #endregion

        #region "Return DataSet"
        public DataTable GetDataTable(SqlCommand _cmd)
        {
            try
            {
                using (SqlConnection _con = new SqlConnection(_connectionStrings.DbConnection))
                {
                    _con.Open();
                    using (DataTable _datatable = new DataTable())
                    {
                        _cmd.Connection = _con;
                        _cmd.CommandTimeout = 300;
                        using (SqlDataAdapter _dataAdapter = new SqlDataAdapter())
                        {
                            _dataAdapter.Fill(_datatable);
                        }
                        return _datatable;
                    }
                }
            }
            finally
            {
                _cmd.Dispose();
            }
        }
        #endregion

        #region "Return Boolean"
        private int rowsReturn;
        public bool ExecuteNonQuery_RetRool(SqlCommand _cmd)
        {
            try
            {
                using SqlConnection _con = new SqlConnection(_connectionStrings.DbConnection);
                _con.Open();
                using DataTable _dt = new DataTable();
                _cmd.Connection = _con;
                _cmd.CommandTimeout = 300;
                rowsReturn = _cmd.ExecuteNonQuery();
                if (rowsReturn > 0)
                    return true;
                else
                    return false;                
            }
            finally
            {
                _cmd.Dispose();
            }
        }
        #endregion
    }
}
