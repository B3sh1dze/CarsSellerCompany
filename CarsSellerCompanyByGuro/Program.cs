using CarsSellerCompanyByGuro;

class Program
{
    public static void UsersCarConfirmation(int userChoice, User user, User boughter)
    {
        if (userChoice <= 0 || userChoice > user.UsersCars.Count)
        {
            Console.WriteLine("Incorrect Input");
            Console.WriteLine("Please enter the valid number.");
        }
        if(user.UsersCars.Count == 0)
        {
            Console.WriteLine("This seller doesn't have any cars.");
        }
        user.ShowOwnedCars();
        Console.WriteLine("Choose which one you want to buy.");
        var userChoice1 = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        var userChoosenCar = user.UsersCars[userChoice1 - 1];
        Console.WriteLine("You have chosen: ");
        userChoosenCar.ShowInformation();
        bool canUserBuyCar = user.PurchaseCar(userChoosenCar, boughter);
        if (canUserBuyCar)
        {
            Console.WriteLine("Your Balance: " + boughter.Amount);
            Console.WriteLine("Car price : " + userChoosenCar.Price);
            Console.WriteLine("Congratulations you've bought this car.");
            user.RemoveCar(userChoosenCar);
        }
        else
        {
            Console.WriteLine("You haven't enough money.");
        }
    }
    public static bool IsUserRegistered(string userName, User users)
    {
        foreach (var user in users.Users)
        {
            if (userName == user.UserName)
            {
                return true;
            }
        }
        return false;
    }
    public static bool IsPasswordCorrect(string userName, string password, User users)
    {
        foreach (var pass in users.Users)
        {
            var user = users.Users.Find(x => x.UserName == userName);
            if (password == user.Password)
            {
                return true;
            }
        }
        return false;
    }
    public static void DisplayMenu(User seller1, User seller2, User boughter, string userName)
    {
        while (true)
        {
            Console.WriteLine("1 - Purchase cars");
            Console.WriteLine("2 - show your information");
            Console.WriteLine("3 - exit");
            Console.WriteLine("Enter the number");
            var choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                var user = boughter.Users.Find(x => x.UserName == userName);
                ShowPurchaseCarsMenu(seller1, seller2, user);
            }
            else if (choice == 2)
            {
                var user = boughter.Users.Find(x => x.UserName == userName);
                user.ShowInformation();
                Console.WriteLine("to Change userName press 1.");
                Console.WriteLine("press 2 to change password.");
                Console.WriteLine("press 3 to exit.");
                int change = Convert.ToInt32(Console.ReadLine());
                if (change == 1)
                {
                    string newUserName;
                    Console.Write("If you want to change username at first please enter your current username: ");
                    userName = Console.ReadLine();
                    if (userName == user.UserName)
                    {
                        Console.Write("Please enter your future username: ");
                        newUserName = Console.ReadLine()!;
                        user.UserName = newUserName;
                        user.ChangeUsername(newUserName);
                    }
                    else
                    {
                        Console.WriteLine("Your current username is wrong.");
                    }
                }
                else if (change == 2)
                {
                    string newPassword;
                    Console.Write("If you want to change password at first please enter your current password: ");
                    var password = Console.ReadLine();
                    if (password == user.Password)
                    {
                        Console.Write("Please enter your future password: ");
                        newPassword = Console.ReadLine()!;
                        newPassword = user.Password!;
                        user.ChangePassword(newPassword);
                    }
                    else
                    {
                        Console.WriteLine("Your current password is wrong.");
                    }
                }
                else if (change == 3)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input.");
                }
            }
            else if(choice == 3)
            {
                break;
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
        }
    }
    public static void ShowPurchaseCarsMenu(User seller1, User seller2, User boughter)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine();
            boughter.ShowInformation();
            Console.WriteLine("Owned cars: ");
            boughter.ShowOwnedCars();
            Console.WriteLine();
            Console.WriteLine("Choose which sellers cars you want to see.");
            Console.WriteLine();
            Console.WriteLine("seller 1. ");
            seller1.ShowInformation();
            Console.WriteLine("seller 2. ");
            seller2.ShowInformation();
            var userChoice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (userChoice == 1)
            {
                UsersCarConfirmation(userChoice, seller1, boughter);
            }
            else if (userChoice == 2)
            {
                UsersCarConfirmation(userChoice, seller2, boughter);
            }
        }
    }
    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        var renault = new Car(7500.53, "Renault", true);
        var BMW = new Car(12335.65, "BMW", true);
        var mercedes = new Car(20653.15, "Mercedes", false);
        var mcLaren = new Car(122335.65, "McLaren", false);
        var boughterJohn = new User(" John", "1234", 57931.35);
        var seller1 = new User()
        {
            UserName = "guro",
            Password = "guro123",
            Amount = 120000
        };
        var seller2 = new User()
        {
            UserName = "John",
            Password = "Doe",
            Amount = 15396
        };
        var boughter = new User()
        {
            UserName = "Jake",
            Password = "1234",
            Amount = 63742
        };
        var users = new User();
        users.Users.Add(seller1);
        users.Users.Add(seller2);
        users.Users.Add(boughter);
        users.Users.Add(boughterJohn);
        seller1.UsersCars.Add(renault);
        seller1.UsersCars.Add(BMW);
        seller2.UsersCars.Add(mercedes);
        seller2.UsersCars.Add(mcLaren);

        while (true)
        {
            Console.WriteLine("Hello there");
            Console.WriteLine("press 1 to log in.");
            Console.WriteLine("press 2 to register.");
            Console.WriteLine("press 3 to exit.");
            var userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                // log in
                Console.Write("Enter your username: ");
                var userName = Console.ReadLine();
                bool userVerification = IsUserRegistered(userName, users);
                while (true)
                {
                    if (userVerification)
                    {
                        Console.Write("Enter your password: ");
                        var password = Console.ReadLine();
                        bool isPasswordCorrect = IsPasswordCorrect(userName, password, users);
                        if (isPasswordCorrect)
                        {
                            Console.Clear();
                            Console.WriteLine("Access granted.");
                            DisplayMenu(seller1, seller2, users, userName);
                        }
                        else
                        {
                            Console.WriteLine("Wrong password.");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong username.");
                        break;
                    }
                }
            }
            else if (userInput == 2)
            {
                //register
                Console.Write("Enter your username: ");
                var userName = Console.ReadLine();
                Console.Write("Enter your password: ");
                var password = Console.ReadLine();
                Console.Write("Enter your Amount of money: ");
                var money = Convert.ToDouble(Console.ReadLine());
                var newUser = new User(userName, password, money);
                newUser.Users.Add(newUser);
                Console.Clear();
                DisplayMenu(seller1, seller2, newUser, userName);
            }
            else if (userInput == 3)
            {
                break;
            }
            else
            {
                Console.WriteLine("Wrong input.");
            }
        }
    }
}