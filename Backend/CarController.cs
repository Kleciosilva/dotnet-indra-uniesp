using System;
using System.Collections.Generic;
using System.Text;

namespace Backend
{
    public class CarController : IAutomobile
    {
        public CarController(string name, string model, string factoryYear, string color)
        {
            this.Name = name;
            this.Model= model;
            this.FactoryYear = factoryYear;
            this.Color = color;
            this.Type = "Car";
        }

        public string Name { get; set; }

        public string Model { get; set; }

        public string FactoryYear { get; set; }

        public string Color { get; set; }

        public string Type { get; set; }

        public string Honk() => "PiBiii";

        public string Honk(string honk)
        {
            return honk;
        }
    }
}
