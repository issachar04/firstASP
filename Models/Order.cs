namespace firstASP.Models
{
    public class Order
    {
        public int Order_Id { get; set; }          // unique ID (the primary key)
        public int Product_Id { get; set; } 
        public int Quantity { get; set; }
    }
}