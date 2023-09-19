namespace DiscountManagementService.Models
{
    public class BaseDiscount
    {
        public int Id { get; set; }
        public string DiscountName { get; set; }
        public int Percentage { get; set; }
    }
}
