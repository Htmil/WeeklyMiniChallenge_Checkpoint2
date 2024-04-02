namespace WeeklyMiniChallenge_Checkpoint2
{
    internal class Product
    {
        public Product(string category, string name, decimal price)
        {
            Category = category;
            productName = name;
            Price = price;
        }

        public string Category { get; set; }
        public string productName { get; set; }
        public decimal Price { get; set; }

        public void PresentItems()
        {
            Console.WriteLine($"{Category}".PadRight(20) + $"{productName}".PadRight(20) + $"{Price}".PadRight(20));
        }
    }
}
