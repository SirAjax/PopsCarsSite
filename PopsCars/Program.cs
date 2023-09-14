using PopsCars;

class Program
{

    static void Main(string[] args)
    {
        List<Cars> carOutputList = new();
        Service service = new Service();

        if (args.Length > 0 && args[0] == "-h")
        {
            Console.WriteLine("Congrats you did it!");
        }
        else if (args.Length > 0 && int.TryParse(args[0], out int myInt))
        {
            carOutputList = service.GetCarsByYear(myInt);
            if (carOutputList.Count == 0)
            {
                carOutputList = service.GetCarById(myInt);
                if (carOutputList.Count == 0)
                {
                    Console.WriteLine($"No cars found for id {myInt}.");
                }
            }

            else
            {
                Console.WriteLine($"No cars found for year {myInt}.");
            }
        }

        else
        {
            Console.WriteLine("Welcome to the Car App!");
            carOutputList = service.GetAllCars();
        }

        foreach (Cars car in carOutputList)
        {
            Console.WriteLine(car);
        }
    }
}
