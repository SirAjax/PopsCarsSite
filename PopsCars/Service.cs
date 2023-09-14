namespace PopsCars
{
    public class Service
    {
        private readonly Data data;
        public Service() 
        {
            data = new Data();
        }
        public List<Cars> GetCarById(int id)
        {
            
            return data.carList.Where(c => c.id.ToString().Contains(id.ToString())).ToList();
        }

        public List<Cars> GetCarsByYear(int year)
        {
            
            return data.carList.Where(c => c.year.ToString().Contains(year.ToString())).ToList();

        }

        public List<Cars> GetAllCars()
        {
            
            return data.carList;
        }

        public List<Cars> GetCarsByModel(string model)
        {
            return data.carList.Where(c => c.model.Contains(model, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public List<Cars> GetCarsByMake(string make)
        {
            
            return data.carList.Where(c => c.make.Contains(make, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public List<Cars> GetCarsByColor(string color)
        {
            
            return data.carList.Where(c => c.color.Contains(color, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }


    }
}
