namespace WeeklyMiniChallenge_Checkpoint2
{
    internal class MyMethods
    {
        // Collects inputdata, Creates and returns a list of products. 
        public static List<Product> CreateProducts(List<Product> productList)
        {
            OpeningInstruction(); // Adds a message to the user with instructions -> could also be added to userFeedback in the future. 

            string category;
            while (true)
            {
                Console.Write("Enter a Category: ");
                category = Console.ReadLine();

                if (category.ToLower().Trim() == "q")
                {
                    break;
                }

                if (string.IsNullOrWhiteSpace(category))
                {
                    UserFeedback("Please enter a Product Category");
                    continue;
                }

                string productName;
                while (true)
                {

                    Console.Write("Enter a Product Name: ");
                    productName = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(productName))
                    {
                        break;
                    }
                    else
                    {
                        UserFeedback("Please enter a Product Name");
                    }
                }
                decimal price;
                while (true) // will continue to ask for price until an int or decimal number is added.
                {
                    Console.Write("Enter a Price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out price))
                    {
                        UserFeedback("Invalid price format. Please enter a valid decimal number.");
                    }
                    else
                    {
                        UserFeedback("The product was succesfully added!", false);
                        break;
                    }
                }

                Product product = new Product(category, productName, price);
                productList.Add(product);
            }

            return productList;
        }
        //Sorts and displays the products to the console.
        public static void DisplayProducts(List<Product> productList)
        {
            productList = productList.OrderBy(product => product.Price).ToList();
            CreateBanner();

            foreach (Product product in productList)
            {
                product.PresentItems();
            }
        }
        //Calculates the sum of the products using LINQ and displays it.
        public static void DisplayTotalSum(List<Product> productList)
        {
            decimal totalSum = productList.Sum(product => product.Price);

            Console.WriteLine("\n" + "Total Amount:".PadLeft(33) + "".PadRight(7) + totalSum);
            Console.WriteLine("--------------------------------------------------------------------------");
        }
        //Creates an opening message with instructions for the user.
        public static void OpeningInstruction()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("To enter a new product - follow the steps | To quit - enter: \"Q\"");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //Creates a Banner with titels for displaying products
        public static void CreateBanner()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Category".PadRight(20) + $"Product".PadRight(20) + $"Price".PadRight(20));
            Console.ForegroundColor = ConsoleColor.White;
        }
        //Creates and returns colored user feedback messages depending on type of message. 
        public static void UserFeedback(string msg, bool errorMsg = true)
        {
            if (errorMsg)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msg);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(msg);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }
}
