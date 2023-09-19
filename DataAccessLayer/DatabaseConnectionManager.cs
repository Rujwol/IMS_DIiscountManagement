using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DiscountManagementService.DataAccessLayer
{
    public class DatabaseConnectionManager : IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public DatabaseConnectionManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void OpenConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }
        }

        public IDbConnection GetConnection()
        {
            OpenConnection();
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
//------------------------------------********------------------------------------------------------
//using System;
//using System.Data;
//using System.Data.SqlClient;

//namespace DiscountManagementService.DataAccessLayer
//{
//    public class DatabaseConnectionManager : IDisposable
//    {
//        private readonly string _connectionString;
//        private IDbConnection _connection;

//        private static readonly object _lock = new object();
//        private static DatabaseConnectionManager _instance;

//        private DatabaseConnectionManager()
//        {
//            // Read the connection string from configuration
//            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
//        }

//        public static DatabaseConnectionManager Instance
//        {
//            get
//            {
//                lock (_lock)
//                {
//                    if (_instance == null)
//                    {
//                        _instance = new DatabaseConnectionManager();
//                        _instance.OpenConnection();
//                    }
//                    return _instance;
//                }
//            }
//        }

//        public IDbConnection GetOpenConnection()
//        {
//            if (_connection == null || _connection.State != ConnectionState.Open)
//            {
//                OpenConnection();
//            }
//            return _connection;
//        }

//        private void OpenConnection()
//        {
//            _connection = new SqlConnection(_connectionString);
//            _connection.Open();
//        }

//        public void Dispose()
//        {
//            if (_connection != null)
//            {
//                if (_connection.State == ConnectionState.Open)
//                {
//                    _connection.Close();
//                }

//                _connection.Dispose();
//                _connection = null;
//            }
//        }
//    }
//}
//------------------------------------********------------------------------------------------------


//using Microsoft.Extensions.Configuration;
//using System.Data;
//using System.Data.SqlClient;

//namespace DiscountManagementService.DataAccessLayer
//{
//    public class DatabaseConnectionManager : IDisposable
//    {
//        private readonly string _connectionString;
//        private IDbConnection _connection;

//        private static readonly object _lock = new object();
//        private static DatabaseConnectionManager _instance;

//        public DatabaseConnectionManager(IConfiguration configuration)
//        {
//            // Read the connection string from IConfiguration
//            _connectionString = configuration.GetConnectionString("DefaultConnection");
//        }

//        public static DatabaseConnectionManager Instance(IConfiguration configuration)
//        {
//            lock (_lock)
//            {
//                if (_instance == null)
//                {
//                    _instance = new DatabaseConnectionManager(configuration);
//                    _instance.OpenConnection();
//                }
//                return _instance;
//            }
//        }

//        public IDbConnection GetOpenConnection()
//        {
//            if (_connection == null || _connection.State != ConnectionState.Open)
//            {
//                OpenConnection();
//            }
//            return _connection;
//        }

//        private void OpenConnection()
//        {
//            _connection = new SqlConnection(_connectionString);
//            _connection.Open();
//        }

//        public void Dispose()
//        {
//            if (_connection != null)
//            {
//                if (_connection.State == ConnectionState.Open)
//                {
//                    _connection.Close();
//                }

//                _connection.Dispose();
//                _connection = null;
//            }
//        }
//    }
//}


