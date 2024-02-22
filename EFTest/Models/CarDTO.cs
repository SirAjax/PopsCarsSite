using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest.Models;
public class CarDTO
{
	public string Company { get; set; } = default!;
	public string? Model { get; set; }
	public int Year { get; set; }
	public string? Color { get; set; }

}
