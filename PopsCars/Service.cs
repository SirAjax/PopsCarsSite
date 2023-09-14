using System.Drawing;
using System.Reflection.Metadata;

namespace PopsCars
{
    public class Service
    {
        public List<Cars> GetAllCars()
        {   
            Data data = new Data();
            return data.carList;
        }
      
      public List<Cars> MainSearch(string search)
{
        Data data = new Data();
        var searchResults = data.carList.Where(c =>
        c.color.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
        c.make.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
        c.model.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
        c.year.ToString().Contains(search)).ToList();

        return searchResults;
}

        
    }
}
