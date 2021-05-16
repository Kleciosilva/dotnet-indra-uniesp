using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Service
{
    public class CarService
    {
        private CarRepository repository;

        public CarService()
        {
            repository = new CarRepository();
        }
        public IEnumerable<CarModel> List()
        {
            return repository.List();
        }
    }
}
