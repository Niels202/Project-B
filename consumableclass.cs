public class Consumable
    {
        public string name;
        public int amount;
        public decimal price;
        public int num;

        public string getData()
        {
            return "Consumable " + num + "\n Name: " + name + "\n amount: " + amount + "\n price: " + price + "\n";
            
        }
    }