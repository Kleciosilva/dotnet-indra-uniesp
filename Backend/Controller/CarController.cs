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
            
            this.repository = new CarRepository();
        }

        public void Save()
        {
            this.repository.Create(this.car);
        }

        public void Update(string id)
        {
            Guid CarId = Guid.Parse(id);
            this.car.Id = CarId;

            this.repository.Update(this.car);
        }
    }
}
