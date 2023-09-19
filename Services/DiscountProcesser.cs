using DiscountManagementService.DataAccessLayer;
using DiscountManagementService.Models;

namespace DiscountManagementService.Services
{
    public class DiscountProcesser : IDiscountprocessor
    {
        IDataProcessOrchestrator _dataProcess;
        public DiscountProcesser(IDataProcessOrchestrator dataProcess)
        {
            _dataProcess = dataProcess;
        }
        public int GetBaseDiscount(Customer customerInfo)
        {
            if (customerInfo is null)
            {
                throw new ArgumentNullException(nameof(customerInfo));
            }
            TimeSpan Timedifference = DateTime.Now - customerInfo.JoinedDate;
            if (Timedifference.TotalDays <= 365)
            {
                var baseDiscount = _dataProcess.GetBaseDiscount();
                return baseDiscount.Percentage;
            }
            return 0;
        }

    }
}
