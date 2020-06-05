using static System.Console;
public class Consumable
    {
        public string name;
        public int amount;
        public int price;
        public int num;

        public string getData()
        {
            return "Consumable " + num + "\n Name: " + name + "\n amount: " + amount + "\n price: " + price + "\n";
        }
        public string customerproducts()
		{
			return name + " $" + price + " amount left: " + amount;
		}

		public Consumable Copy() => new Consumable() { name = name, amount = amount, num = num, price = price };

		public static int i_try_parse(string question)
		{
			while (true)
			{
				Write(question);
				string typecheck = ReadLine();
				if (int.TryParse(typecheck, out int res))
					return res;
				WriteLine("wrong input, please try again.");
			}
		}

		public static int o_try_parse(string question, int limit)
		{
			while (true)
			{
				Write(question);
				string typecheck = ReadLine();
				if (int.TryParse(typecheck, out int res) && res >= 0 && res <= limit)
					return res;
				WriteLine("wrong input, please try again.");
			}
		}

		public static decimal m_try_parse(string question)
		{
			while (true)
			{
				Write(question);
				string typecheck = ReadLine();
				if (decimal.TryParse(typecheck.Replace('.', ','), out decimal res))
					return res;
				WriteLine("wrong input, please try again.");
			}
		}
    }