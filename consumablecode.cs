using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace projectB2
{

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


	}

	public class Program
	{

		static void Main(string[] args)
		{


			// list of variables: their name, cause and where to find them.
			int x = 0;
			int x2 = 0;
			int x22 = 0;
			int x3 = 0;
			int x4 = 0;
			int x5 = 0;
			int x55 = 0;
			int x6 = 0;
			int totalprice = 0;
			int cons_adjust = 0;            // A variable that gets the value that says which consumable from the list to adjust | line 131 |
			int item_amount = 0;
			string option = "";             // A variable that gets the value that says which option the user wants to select.
			string option2 = "";            // A variable that gets the value that says which option the user wants to select.
			string option3 = "";            // A variable that gets the value that says which option the user wants to select.
			string option4 = "";
			string k2;                      // A variable that gets the value that says the user want to go back | line 201 |
			string loop = "";               // A variable to that stops the while-loop when needed | while-loop line 45  |
			string loop0 = "";              // A variable to that stops the while-loop when needed | while-loop line 69  |
			string loop1 = "";              // A variable to that stops the while-loop when needed | while-loop line 84  |
			string loop2 = "";
			string typecheck = "";          // A varibale that gets a value assigned to it. That value gets checked if it is the right type to parse to the consumable object. | line 72  |

			string user = "";               // A variable that gets a value containing the user-type storred into it. | line 51 |
			int money = 10;

			List<Consumable> ConsumableList = new List<Consumable>();

			while (loop0 != "stop")
			{
				Console.WriteLine("test-anabeler for different user-modes: (chose caterer, admin, customer) usermodes you want to test: ");
				user = Console.ReadLine();

				if (user != "caterer" && user != "admin" && user != "customer")
				{
					Console.WriteLine("wrong input, Try again");
				}

				else if (user == "caterer" || user == "admin" || user == "customer")
				{
					loop0 = "stop";
				}
			}
			loop0 = "";

			if (user == "caterer")
			{
				while (loop != "stop")
				{

					option2 = "";
					option3 = "";

					Console.WriteLine("caterer menu \n 1. Add consumables \n 2. adjust consumables \n 3. show consumables");
					Console.WriteLine("chose option: "); option = Console.ReadLine();

					if (option == "1")
					{
						Console.WriteLine("if you want to create / add a new consumable, type add. if you want to go back to the main menu, type back");
						while (option2 != "back")
						{

							option2 = Console.ReadLine();

							if (option2 == "add")
							{

								option2 = "";
								ConsumableList.Add(new Consumable());
								Console.WriteLine("Creating new consumable... \n ");

								Console.WriteLine("Name of new consumable: ");
								ConsumableList[x].name = Console.ReadLine();

								while (loop0 != "stop")
								{
									Console.WriteLine("Amount in stock of new consumable: ");
									typecheck = Console.ReadLine();

									if (int.TryParse(typecheck, out ConsumableList[x].amount))
									{
										loop0 = "stop";
									}

									else
									{
										Console.WriteLine("Wrong input, please try again.");
									}
								}
								loop0 = "";
								typecheck = "";

								while (loop0 != "stop")
								{
									Console.WriteLine("The price of the new consumable: ");
									typecheck = Console.ReadLine();

									if (int.TryParse(typecheck, out ConsumableList[x].price))
									{
										loop0 = "stop";
									}
									else
									{
										Console.WriteLine("Wrong input, please try again.");
									}
								}
								loop0 = "";
								typecheck = "";
								ConsumableList[x].num += x;

								Console.WriteLine("Do you want to add / create another consumable (type add) or back out to the main menu and safe? (type back) ");

								option2 = "";
								x = x + 1;
							}

							else if (option2 == "back")
							{
								Console.WriteLine("");
							}

							else
							{
								Console.WriteLine("Wrong answer! Please try again.");
							}

						}
					}

					else if (option == "2")
					{
						Console.WriteLine("if you want to adjust / change a consumable, press enter. If you want to go back to the main menu, type back");
						option3 = Console.ReadLine();

						while (option3 != "back")
						{

							while (loop0 != "stop")
							{
								Console.WriteLine("Which consumable do you want to adjust? Type in the number of the consumable.");
								Console.WriteLine("You can find the number of the consumable with option 3 of the main menu called show consumables.");
								typecheck = Console.ReadLine();

								if (int.TryParse(typecheck, out cons_adjust))
								{
									loop0 = "stop";
								}

								else
								{
									Console.WriteLine("Wrong input, please try again.");
								}
							}
							loop0 = "";
							typecheck = "";

							if (cons_adjust <= x && cons_adjust >= 0)
							{
								Console.WriteLine("Unajusted consumable: ");
								Console.WriteLine(ConsumableList[cons_adjust].getData());

								Console.WriteLine("Change what you want to change. Fill in the old value for the things you want to stay the same. \n");

								Console.WriteLine("Name: ");
								ConsumableList[cons_adjust].name = Console.ReadLine();

								while (loop0 != "stop")
								{
									Console.WriteLine("Amount in stock: ");
									typecheck = Console.ReadLine();

									if (int.TryParse(typecheck, out ConsumableList[cons_adjust].amount))
									{
										loop0 = "stop";
									}

									else
									{
										Console.WriteLine("Wrong input, please try again.");
									}
								}
								loop0 = "";
								typecheck = "";

								while (loop0 != "stop")
								{
									Console.WriteLine("The price: ");
									typecheck = Console.ReadLine();

									if (int.TryParse(typecheck, out ConsumableList[cons_adjust].amount))
									{
										loop0 = "stop";
									}

									else
									{
										Console.WriteLine("Wrong input, please try again.");
									}
								}
								loop0 = "";
								typecheck = "";

								Console.WriteLine("\n Do you want to adjust another consumable? \n If you want to adjust another consumable, press enter. If you want to go back to the main menu, type back");
								option3 = Console.ReadLine();
							}

							else
							{
								Console.WriteLine("The consumable you are trying to adjust does not exist yet. Please try again.");
							}
						}
					}

					else if (option == "3")
					{
						foreach (Consumable i in ConsumableList)
						{
							Console.WriteLine(i.getData());
						}

						Console.WriteLine("\n Type anything to go back.");
						k2 = Console.ReadLine();
					}

					else
					{
						Console.WriteLine("Wrong answer! please try again.");
					}

				}
			}

			else if (user == "admin")
			{
				while (loop0 != "stop")
				{
					Console.WriteLine("welcome admin! \n Press enter if you want a overview of all the consumables in stock.");
					string k3 = Console.ReadLine();

					foreach (Consumable i in ConsumableList)
					{
						Console.WriteLine(i.getData());
					}

					Console.WriteLine("\n Type anything to go back.");
					k2 = Console.ReadLine();
				}
				loop0 = "";
			}

			else
			{

				ConsumableList.Add(new Consumable());
				ConsumableList[0].name = "cola";
				ConsumableList[0].amount = 30;
				ConsumableList[0].price = 2;

				ConsumableList.Add(new Consumable());
				ConsumableList[1].name = "spite";
				ConsumableList[1].amount = 30;
				ConsumableList[1].price = 2;

				ConsumableList.Add(new Consumable());
				ConsumableList[2].name = "energy";
				ConsumableList[2].amount = 30;
				ConsumableList[2].price = 2;

				ConsumableList.Add(new Consumable());
				ConsumableList[3].name = "gang";
				ConsumableList[3].amount = 30;
				ConsumableList[3].price = 2;

				List<Consumable> ConsumableList_change = ConsumableList.Select(x => x.Copy()).ToList();
				List<Consumable> ConsumableList_cart = ConsumableList.Select(x => x.Copy()).ToList();

				foreach (Consumable i in ConsumableList_cart)
				{
					i.amount = 0;
				}

				while (loop1 != "stop")
				{
					x2 = 0;
					Console.Clear();
					Console.WriteLine("Welcome customer! \n Chose the product(number) you want to put in your cart or one of the other options.");
					Console.WriteLine("Items in your cart: " + item_amount + " " + "| Te betalen: " + totalprice + " | " + "Money in account: " + money);
					Console.WriteLine("");

					foreach (Consumable i in ConsumableList_change)
					{
						Console.WriteLine("" + x2 + ". " + i.customerproducts());
						x2 += 1;
						x22 = x2;
					}
					x2 = 0;

					Console.WriteLine(x22 + ". adjust cart");
					Console.WriteLine((x22 + 1) + ". proceed to pay");
					Console.WriteLine((x22 + 2) + ". Back out.");

					while (loop0 != "stop")
					{
						Console.WriteLine("select your option number: ");
						typecheck = Console.ReadLine();

						if (int.TryParse(typecheck, out x3) && x3 >= 0 && x3 <= (x22 + 2))
						{
							loop0 = "stop";
						}

						else
						{
							Console.WriteLine("Wrong input. Please try again.");
						}
					}
					loop0 = "";
					typecheck = "";

					if (x3 == x22)
					{
						while (loop2 != "stop")
						{
							List<int> og_listposition = new List<int>();
							x2 = 0;
							x55 = 0;

							Console.WriteLine("The products in your cart: \n select the number of the product you would like to adjust the amount of. ");

							foreach (Consumable i in ConsumableList_cart)
							{
								if (i.amount > 0)
								{
									Console.WriteLine(x55 + ". " + i.name + ": " + i.amount);
									x55 += 1;
									og_listposition.Add(x2);
								}
								x2 += 1;
							}
							Console.WriteLine(x55 + ". back out");

							while (loop0 != "stop")
							{
								Console.WriteLine("select your option number: ");
								typecheck = Console.ReadLine();

								if (int.TryParse(typecheck, out x5) && x5 >= 0 && x5 <= x55)
								{
									loop0 = "stop";
								}

								else
								{
									Console.WriteLine("Wrong input. Please try again.");
								}
							}
							loop0 = "";
							typecheck = "";

							if (x5 == x55)
							{
								loop2 = "stop";
							}

							else
							{
								while (loop0 != "stop")
								{
									Console.WriteLine("name: " + ConsumableList[og_listposition[x5]].name + " | current amount in your cart: " + ConsumableList_change[og_listposition[x5]].amount + ".");
									Console.WriteLine("New amount: ");
									typecheck = Console.ReadLine();

									if (int.TryParse(typecheck, out x6) && x6 >= 0 && x6 <= ConsumableList[og_listposition[x5]].amount)
									{
										loop0 = "stop";
									}

									else
									{
										Console.WriteLine("Wrong input. Please try again.");
									}
								}
								loop0 = "";
								typecheck = "";

								totalprice = totalprice - (ConsumableList_change[og_listposition[x5]].price * ConsumableList_cart[og_listposition[x5]].amount);
								ConsumableList_change[og_listposition[x5]].amount = (ConsumableList_change[og_listposition[x5]].amount + ConsumableList_cart[og_listposition[x5]].amount);
								ConsumableList_cart[og_listposition[x5]].amount = x6;
								ConsumableList_change[og_listposition[x5]].amount = ConsumableList_change[og_listposition[x5]].amount - x6;
							}
						}
						loop2 = "";
					}

					else if (x3 == (x22 + 1))
					{
						if (money >= totalprice)
						{

							while (loop0 != "stop")
							{
								Console.WriteLine("Are you sure you want to pay? \n Press enter to proceed, type back if you want to go back.");
								option4 = Console.ReadLine();

								if (option4 == "back")
								{
									loop0 = "stop";
								}

								else if (option4 == "")
								{
									money = money - totalprice;
									ConsumableList = ConsumableList_change.Select(x => x.Copy()).ToList();
									totalprice = 0;
									item_amount = 0;
									Console.WriteLine("Thank you for your purchase.");
									loop0 = "stop";
								}

								else
								{
									Console.WriteLine("Wrong input, please try again.");
								}
							}
							loop0 = "";
						}

						else
						{
							Console.WriteLine("You do not have enough money for this purchase, please change the amount that is in your cart.");
						}
					}

					else if (x3 == (x22 + 2))
					{
						loop1 = "stop";
						totalprice = 0;
						item_amount = 0;
					}

					else
					{
						while (loop0 != "stop")
						{
							Console.WriteLine("amount of " + ConsumableList[x3].name);
							typecheck = Console.ReadLine();

							if (int.TryParse(typecheck, out x4))
							{
								loop0 = "stop";
							}

							else
							{
								Console.WriteLine("Wrong input. Please try again.");
							}
						}
						loop0 = "";
						typecheck = "";

						item_amount += x4;
						ConsumableList_change[x3].amount = (ConsumableList_change[x3].amount - x4);
						ConsumableList_cart[x3].amount = (ConsumableList_cart[x3].amount + x4);
						totalprice = totalprice + ConsumableList_change[x3].price * x4;
					}
				}
			}
		}
	}
}
