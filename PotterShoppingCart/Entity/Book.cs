namespace PotterShoppingCart.Entity
{
    public enum Serial
    {
        None,
        HarryPotter,
    }

    public class Book
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Serial Serial { get; set; }
    }
}