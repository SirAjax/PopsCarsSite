namespace PopsCars
{
    public class Service
    {
        public List<Cars> GetCarById(int id)
        {
            Data data = new Data();
            return data.carList.Where(c => c.id.ToString().Contains(id.ToString())).ToList();
        }

        public List<Cars> GetCarsByYear(int year) 
        {
            Data data = new Data();
            return data.carList.Where(c => c.year.ToString().Contains(year.ToString())).ToList();

        }

        public List<Cars> GetAllCars() 
        { 
            Data data = new Data();
            return data.carList;
        }

        public List<Cars> GetCarsByModel(string model) 
        { 
            Data data = new Data();
            return data.carList.Where(c => c.model.ToLower().Contains(model)).ToList();
        }

        public List<Cars> GetCarsByMake(string make) 
        { 
            Data data = new Data();
            return data.carList.Where(c => c.make.ToLower().Contains(make)).ToList();
        }

        public List<Cars> GetCarsByColor(string color) 
        { 
            Data data= new Data();  
            return data.carList.Where(c => c.color.ToLower().Contains(color)).ToList();   
        }
    }
}
