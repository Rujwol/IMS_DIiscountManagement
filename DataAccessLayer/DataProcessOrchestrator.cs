using Dapper;
using DiscountManagementService.DataAccessLayer;
using DiscountManagementService.Models;
using System;
using System.Data;

namespace DiscountManagementService.DataAccessLayer
{
    public class DataProcessOrchestrator : IDataProcessOrchestrator
    {
        private readonly IDbConnection _dbConnection;

        public DataProcessOrchestrator(DatabaseConnectionManager connectionManager)
        {
            _dbConnection = connectionManager.GetConnection();
        }

        public BaseDiscount GetBaseDiscount()
        {
            // SQL query to retrieve BaseDiscount
            const string query = "SELECT * FROM BaseDiscount";

            BaseDiscount discount = _dbConnection.QueryFirstOrDefault<BaseDiscount>(query);

            // Connection will be automatically closed when Dispose is called on _dbConnection.

            return discount;
        }

        private int CalculateWeeklyDiscount(string customerType)
        {
            // Assuming you have a Discount_Weekly table with discounts for each day of the week.
            string query = "SELECT Percent FROM Discount_Weekly WHERE Days LIKE @day AND DiscountRuleId IN " +
                           "(SELECT DiscountRuleId FROM DiscountRule WHERE DiscountTypeId = " +
                           "(SELECT Id FROM DiscountType WHERE DiscountTypeName = @customerType))";
            // Use LIKE to match the current day of the week (e.g., "Monday").

            int discount = _dbConnection.ExecuteScalar<int>(
                query,
                new { day = "%" + DateTime.Now.DayOfWeek.ToString() + "%", customerType }
            );

            // Connection will be automatically closed when Dispose is called on _dbConnection.

            return discount;
        }

        public void Dispose()
        {
            _dbConnection?.Dispose();
        }
    }
}

//---------------------***-----------------------------------
//using Dapper;
//using DiscountManagementService.DataAccessLayer;
//using DiscountManagementService.Models;
//using System;
//using System.Data;

//namespace DiscountManagementService.DataAccessLayer
//{
//    public class DataProcessOrchestrator : IDataProcessOrchestrator, IDisposable
//    {
//        private readonly IDbConnection _dbConnection;

//        public DataProcessOrchestrator(DatabaseConnectionManager connectionManager)
//        {
//            // Injected IDbConnection instance from DatabaseConnectionManager
//            _dbConnection = connectionManager.GetOpenConnection();
//        }

//        public BaseDiscount GetBaseDiscount()
//        {
//            const string query = "SELECT * FROM BaseDiscount";
//            return _dbConnection.QueryFirstOrDefault<BaseDiscount>(query);
//        }

//        public int CalculateWeeklyDiscount(string customerType)
//        {
//            string query = "SELECT Percent FROM Discount_Weekly WHERE Days LIKE @day AND DiscountRuleId IN " +
//                           "(SELECT DiscountRuleId FROM DiscountRule WHERE DiscountTypeId = " +
//                           "(SELECT Id FROM DiscountType WHERE DiscountTypeName = @customerType))";
//            // Use LIKE to match the current day of the week (e.g., "Monday").

//            int discount = _dbConnection.ExecuteScalar<int>(query, new { day = "%" + DateTime.Now.DayOfWeek.ToString() + "%", customerType });
//            return discount;
//        }

//        public void Dispose()
//        {
//            _dbConnection?.Dispose();
//        }
//    }
//}

