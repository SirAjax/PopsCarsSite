namespace EFTest.Models;

public class Car
{
    public string Make { get; set; } = default!;
    public string? Model { get; set; }
    public int Year { get; set; }
    public string? Color { get; set; }
    public int CarId { get; set; }

    public int UserId {get; set;}

    public Car()
    { 
        //intentially left blank for CRUD operations
    }

    public Car(int year, string make, string model, string color, int id)
    {
        this.Year = year;
        this.Make = make;
        this.Model = model;
        this.Color = color;
        this.CarId = id;
    }

    public override string ToString()
    {
        return $"Year: {Year}, Make: {Make}, Model: {Model}, Color: {Color}, Car Id: {CarId}";
    }
}
