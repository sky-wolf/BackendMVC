﻿namespace LexiconMVC.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
        public List<PersonDB> Persons { get; set; } =  new List<PersonDB>();
    }
}