using DiscountManagementService.Models;

namespace DiscountManagementService.DataAccessLayer
{
    public interface IDataProcessOrchestrator
    {
        //IEnumerable<BaseDiscount> GetBaseDiscount();
        BaseDiscount GetBaseDiscount();
    }
}
