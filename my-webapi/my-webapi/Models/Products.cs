namespace my_webapi.Models
{
    public class ProductVM
    {
        public string productName { get; set; }
        public double ProductPrice { get; set; }
    }
    public class Product : ProductVM
    {
        public Guid productID { get; set; }
    }

}
