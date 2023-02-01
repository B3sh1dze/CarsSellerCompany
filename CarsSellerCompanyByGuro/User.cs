
using System.Diagnostics;
using System.Reflection;

namespace CarsSellerCompanyByGuro
{
    public class User
    {
        public long ID { get; set; } = new Random().NextInt64();
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public double Amount { get; set; }
        public List<Car>? Cars { get; set; } = new List<Car>();
        public List<Car>? UsersCars { get; set; } = new List<Car>();
        public List<User>? Users { get; set; } = new List<User>();
        public void ShowInformation()
        {
            Console.WriteLine(
               $"Id: {ID}\n" +
               $"Username: {UserName}\n" +
               $"Password: {Password}\n" +
               $"money:  {Amount}\n"
               );
        }
        public User()
        {
            
        }
        public User(string userName, string password, double amount)
        {
            UserName = userName;
            Password = password;
            Amount = amount;
        }
        public bool PurchaseCar(Car newCar, User boughter)
        {
            if (boughter.Amount >= newCar.Price)
            {
                boughter.Amount -= newCar.Price;
                boughter.UsersCars.Add(newCar);
                return true;
            }
            else
            {
                Console.WriteLine("Not enough money on account");
                return false;
            }
        }
        public void RemoveCar(Car carToRemove)
        {
            UsersCars.Remove(carToRemove);
        }
        public void ChangeUsername(string userName)
        {
            UserName = userName;
            Console.WriteLine("new userName: " + UserName);
        }
        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
        public void ShowOwnedCars()
        {
            if (UsersCars.Count == 0)
            {
                Console.WriteLine("User " + UserName + " doesn't have any cars.");
            }
            else
            {
                int i = 1;
                foreach (var car in UsersCars)
                {
                    Console.Write(i + ". ");
                    Console.WriteLine(car.ToString());
                    Console.WriteLine();
                    i++;
                }
            }
        }
    }
}