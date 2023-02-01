namespace CarsSellerCompanyByGuro
{
    public class Car
    {
        public long ID { get; set; } = new Random().NextInt64();
        public double Price { get; set; }
        public string? Model { get; set; }
        public bool IsUsed { get; set; }

        public void ShowInformation()
        {
            Console.WriteLine(
               $"Id: {ID}\n" +
               $"Model: {Model}\n" +
               $"Price: {Price}\n" +
               $"IsUsed: {IsUsed}\n"
               );
        }
        public override string ToString()
        {
            return $"car ID: {ID}\n" +
                $"car price: {Price}\n" +
                $"car model: {Model}\n" +
                $"Is car used: {IsUsed}";
        }
        public Car(double price, string model, bool isUsed)
        {
            Price = price;
            Model = model;
            IsUsed = isUsed;
        }
    }
}
