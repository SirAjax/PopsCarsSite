namespace PopsCars;

public class Cars
{
    public string? make;
    public string? model;
    public int year;
    public string? color;
    public int id;

    public Cars(int year, string make, string model, string color, int id)
    {
        this.year = year;
        this.make = make;
        this.model = model;
        this.color = color;
        this.id = id;
    }

    public override string ToString()
    {
        return $"Year: {year}, Make: {make}, Model: {model}, Color: {color}, Car Id: {id}";
    }
}
