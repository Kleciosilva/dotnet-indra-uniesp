using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Controller
{
    public class CarController
    {
        private CarModel car;
        private CarRepository repository;

        public CarController(string name, string model, string factoryYear, string color)
        {
            this.car = new CarModel(name, model, factoryYear, color);
            this.car.Type = "Car";
            
            Console.WriteLine("00---------------------> Controller - Constructor");

            this.repository = new CarRepository();
        }

        public void Save()
        {
            Console.WriteLine("00---------------------> Controller - Save");
            this.repository.Create(this.car);
        }
    }
}
