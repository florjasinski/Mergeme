using System;
namespace Client {

    public class ClientLogic
    {
        private static string actualUserName = "NoUser";

        private static string actualPassword = "NoPassword";
        private static bool userLogged = false;

        public void StartMenu()
        {
            Console.WriteLine("\n >>>>>>> WELCOME <<<<<<< ");
            WelcomeScreen();
        }

        public void WelcomeScreen()
        {
            Console.WriteLine("\nSelect an option: \n" +
                "1) Register User \n" +
                "2) Login \n" +
                "3) Exit ");

            bool running = true;

            while (running)
            {
                Console.WriteLine("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        if (!userLogged)
                        {
                            Login();
                        }
                        else
                        {
                            Console.WriteLine("You are already logged in.");
                        }
                        break;
                    case 3:
                        running = false;
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Error, please enter a valid option.");
                        break;
                }
            }
            if (userLogged)
            {
                MainScreen();
            }
        }

        private void Register()
        {
            Console.WriteLine("Please enter your username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            string password = Console.ReadLine();
            actualPassword = password;
            actualUserName = username;
            Console.WriteLine("Registration successful. You can now log in.");
            userLogged = false;
        }

        private void Exit () {
            Console.WriteLine("Exiting...");
            System.Threading.Thread.Sleep(1000);
        }

        private void Login()
        {
            if (actualUserName == "NoUser" && actualPassword == "NoPassword")
            {
                Console.WriteLine("You must register first.");
                return;
            }

            Console.WriteLine("Please enter your username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            string password = Console.ReadLine();

            if (username == actualUserName && !string.IsNullOrEmpty(password) && password == actualPassword)
            {
                userLogged = true;
                Console.WriteLine("Login successful. Welcome back, " + username + "!");
                MainScreen();
            }
            else
            {
                Console.WriteLine("Incorrect credentials, please try again.");
            }
        }

        public void MainScreen()
        {
            Console.WriteLine("\n >>>>>>> Main Menu <<<<<<< \n" +
                "1) Add Game \n" +
                "2) Buy Game \n" +
                "3) Modify Game \n" +
                "4) Delete Game \n" +
                "5) Search Games \n" +
                "6) View Game Details \n" +
                "7) Rate Game \n" +
                "8) Disconnect \n");

            bool running = true;

            while (running && userLogged)
            {
                Console.WriteLine("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddGame();
                        break;
                    case 2:
                        BuyGame();
                        break;
                    case 3:
                        ModifyGame();
                        break;
                    case 4:
                        DeleteGame();
                        break;
                    case 5:
                        SearchGames();
                        break;
                    case 6:
                        ViewGameDetails();
                        break;
                    case 7:
                        RateGame();
                        break;
                    case 8:
                        userLogged = false;
                        actualUserName = "NoUser";
                        Console.WriteLine("Logged out successfully.");
                        StartMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        private void AddGame() { Console.WriteLine("AddGame"); }
        private void BuyGame() { Console.WriteLine("BuyGame"); }
        private void ModifyGame() { Console.WriteLine("ModifyGame"); }
        private void DeleteGame() { Console.WriteLine("DeleteGame"); }
        private void SearchGames() { Console.WriteLine("SearchGames"); }
        private void ViewGameDetails() { Console.WriteLine("ViewGameDetails"); }
        private void RateGame() { Console.WriteLine("RateGame"); }

    }
}
