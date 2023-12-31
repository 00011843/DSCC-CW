﻿namespace API.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public ICollection<Vacancy> Vacancies { get; }  
    }
}
