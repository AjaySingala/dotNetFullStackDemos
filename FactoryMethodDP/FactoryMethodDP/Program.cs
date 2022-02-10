using System;

namespace FactoryMethodDP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Factory Method Design Pattern Demo...");

            RunDemo();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void RunDemo()
        {
            bool toEnd = false;
            do
            {
                CardFactory factory = null;
                Console.Write("Enter the card type you would like to create (Moneyback, Titanium or Platinum): ");
                string card = Console.ReadLine();
                if (string.IsNullOrEmpty(card))
                    continue;

                switch (card.ToLower())
                {
                    case "quit":
                    case "exit":
                        toEnd = true;
                        break;
                    case "moneyback":
                        factory = new MoneyBackFactory(50000, 0);
                        break;
                    case "titanium":
                        factory = new TitaniumFactory(100000, 500);
                        break;
                    case "platinum":
                        factory = new PlatinumFactory(500000, 1000);
                        break;
                    default:
                        Console.WriteLine("Invalid card type selected. Please retry...");
                        continue;
                        //break;
                }

                if (!toEnd)
                {
                    CreditCard creditCard = factory.GetCreditCard();
                    Console.WriteLine("\nYour card details are below : \n");
                    Console.WriteLine("Card Type: {0}\nCredit Limit: {1}\nAnnual Charge: {2}",
                        creditCard.CardType, creditCard.CreditLimit, creditCard.AnnualCharge);
                }
            } while (!toEnd);
        }
    }
}