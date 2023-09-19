namespace DiscountManagementService.Models
{
    public class Discount_Weekly
    {
        public int ID { get; set; }
        public string Days { get; set; }
        public int Percent { get; set; }
        public int DiscountRuleID { get; set; }
    }
}
