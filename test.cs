using DiscountManagementService.Models;
namespace DiscountManagementService
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CustomerType { get; set; }
        public DateTime JoinedDate { get; set; }

    }
    public class test
    {
        public void operation()
        {
            Customer customer1 = new Customer();
            customer1.ID = 1;
            customer1.Name = "Alex";
            customer1.CustomerType = "N";
            customer1.JoinedDate = new DateTime(2020, 1, 15);

            Customer customer2 = new Customer();
            customer1.ID = 2;
            customer1.Name = "Nayn";
            customer1.CustomerType = "S";
            customer1.JoinedDate = new DateTime(2022, 11, 15);

            Customer customer3 = new Customer();
            customer1.ID = 3;
            customer1.Name = "Rob";
            customer1.CustomerType = "G";
            customer1.JoinedDate = new DateTime(2023, 1, 15);

            Customer customer4 = new Customer();
            customer1.ID = 1;
            customer1.Name = "PLatip";
            customer1.CustomerType = "P";
            customer1.JoinedDate = new DateTime(2010, 1, 15);

            DiscountType discount_currentUser = new DiscountType();

            if (customer1.CustomerType == "N")
            {
                
            }
        }
    }
}
