namespace firstASP.Models
{
    public class Product
    {
        public int Id { get; set; }          // unique ID (the primary key)
        public string Name { get; set; } = "";
        public int Price { get; set; }
    }
}