﻿using EFTest.Models;

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
                search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).All(term =>   //received help for line 19 
                    c.color.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
                    c.make.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
                    c.model.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
                    c.year.ToString().Contains(term))
            ).ToList();

            return searchResults;
        }
        



















        /*
         public List<Cars> MainSearch(string search)
        {
            Data data = new Data();

        var searchResults = data.carList.Where(c =>
            search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Any(term => 
                c.color.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
                c.make.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
                c.model.Contains(term, StringComparison.InvariantCultureIgnoreCase) ||
                c.year.ToString().Contains(term))
        ).ToList();

            return searchResults;
        }
        */
    }
}
