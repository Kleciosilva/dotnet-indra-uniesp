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

        public CarModel GetById(Guid id)
        {
            try
            {
                var car = this.repository.GetById(id);
                return car;
            }
            catch (Exception ex)
            {
                throw new Exception($"Nenhum carro encontrado com este Id. {ex.Message}");
            }
        }

        public List<CarModel> GetByManufacturer(string manufacturer)
        {
            return this.repository.GetByManufacturer(manufacturer);
        }

        public void Delete(Guid id)
        {
            try
            {
                var car = this.GetById(id);
                this.repository.Delete(car);
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao apagar o carro. {ex.Message}");
            }
        }
    }
}
