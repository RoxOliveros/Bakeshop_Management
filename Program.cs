namespace BakeshopManagement
{
    internal class Program
    {
        static List<string> menu = new List<string>(); // Stores products

        static void Main(string[] args)

        {
            //  manage a bakeshop's menu by adding, deleting, searching,
            //  and viewing products

            string username = "admin";
            string pin = "1234";
            string usernameInput;
            string pinInput;

            Console.WriteLine("== LOGIN ==");

            // --------------- user login w/ looping --------------
            do
            {
                Console.Write("Enter Username: ");
                usernameInput = Console.ReadLine();

                Console.Write("Enter Pin: ");
                pinInput = Console.ReadLine();

                if (usernameInput != username || pinInput != pin)
                {
                    Console.WriteLine("Invalid username or pin. Please try again :p");

                }
                else
                {
                    Console.WriteLine("\n == WELCOME TO XANNE'S BAKESHOP == ");
                    InputAction();
                }

            } while (usernameInput != username || pinInput != pin);

        }

        // --------------- displays a list of actions --------------
        static void InputAction() {
            int userAction;

           
            do
            {
                string[] actions = new string[] { "[1] Add Product", "[2] Delete Product",
                        "[3] Search Product", "[4] View Menu",  "[5] Exit"  };

                Console.WriteLine("\n Choose an Action");

                foreach (var action in actions)
                {
                    Console.WriteLine(action);
                }
                Console.Write("Enter Action: ");
                userAction = Convert.ToInt16(Console.ReadLine());

                ChooseAction(userAction);

            } while (userAction != 5);
        }

        //  ------------ handles the logic for each selected action -------------
        static void ChooseAction(int action)
        {
            switch (action)
            {
                case 1: // Adding product in the menu 
                    Console.Write("Enter a product: ");
                    string product = Console.ReadLine();


                    if (!string.IsNullOrEmpty(product))
                    {
                        menu.Add(product);
                        Console.WriteLine($"{product} has been added to the menu.");
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid product name.");
                    }

                    BackToActionOption(1);
                    break;

                case 2: // deleting product in the menu
                    Console.Write("Enter product to delete: ");
                    string productDelete = Console.ReadLine();

                    if (!string.IsNullOrEmpty(productDelete))
                    {
                        if (menu.Contains(productDelete))
                        {
                            menu.Remove(productDelete);
                            Console.WriteLine($"{productDelete} has been removed from the menu.");
                        }
                        else
                        {
                            Console.WriteLine($"{productDelete} was not found in the menu.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a product to delete.");
                    }

                    BackToActionOption(2);
                    break;


                case 3: // searching product
                    Console.Write("Enter product name to search: ");
                    string searchItem = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(searchItem))
                    {
                        if (menu.Contains(searchItem))
                        {
                            Console.WriteLine($"{searchItem} is available in the menu.");
                        }
                        else
                        {
                            Console.WriteLine($"{searchItem} is not in the menu.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid product name.");
                    }

                    BackToActionOption(3);
                    break;

                case 4: // showing the list of items added in the menu
                    Console.WriteLine("\n===== MENU ITEMS =====");
                    if (menu.Count == 0)
                    {
                        Console.WriteLine("No products in the menu.");
                    }
                    else
                    {
                       
                        for (int i = 0; i < menu.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + menu[i]);

                           

                        }
                         
                    }
                    break;

                case 5: // exit
                    Console.WriteLine("Exiting program. Thank you!");
                    BackToActionOption(5);
                    break;

                default: // for invalid choice will go back to selecting actions
                    Console.WriteLine("Invalid choice. Please select a number between 1-5.");
                    InputAction();
                    break;
            }
        }

        // ----- This method prompts the user if they want to go back to the action options -------
        static void BackToActionOption(int lastAction)
        {
            Console.WriteLine("\nDo you want to go back to action options? [1] Yes [2] No ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                InputAction();
            }
            else if (input == "2")
            {
                ChooseAction(lastAction);
            }
            else
            {
                Console.WriteLine("Invalid input. Returning to action options.");
                InputAction();
            }
        }
    }
}