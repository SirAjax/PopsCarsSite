using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTest.Models;

public class Car
{
    public string Make { get; set; } = default!;
    public string? Model { get; set; }
    public int Year { get; set; }
    public string? Color { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? UserId { get; set; }

    public User User { get; set; } = null!;



    public Car()
    { 
        //intentially left blank for CRUD operations
    }

    public Car(int year, string make, string model, string color, int id, int userId)
    {
        this.Year = year;
        this.Make = make;
        this.Model = model;
        this.Color = color;
        this.Id = id;
        this.UserId = userId;
    }

    public override string ToString()
    {
        return $"Year: {Year}, Make: {Make}, Model: {Model}, Color: {Color}, Car Id: {Id}, User Id: {UserId}";
    }
}
