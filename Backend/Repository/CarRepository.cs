using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class CarRepository
    {
        private VehiclesContext context;

        public CarRepository()
        {
            this.context = new VehiclesContext();
        }

        public List<CarModel> List()
        {
            return this.context.Cars.ToList();
        }

        public List<CarModel> GetByManufacturer(string name)
        {
            try
            {
                var Cars = this.context.Cars
                    .Where(x => x.Manufacturer.Equals(name))
                    .OrderBy(x => x.Name);
                if (Cars != null && Cars.Any())
                {
                    return Cars.ToList();
                }
                throw new Exception($"Nenhum carro localizado com o nome {name}");
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao filtrar por fabricante: {ex.Message}");
            }
        }

        public void Create(CarModel car)
        {
            try
            {
                this.context.Cars.Add(car);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao adicionar um novo carro: {ex.Message}");
            }
        }

        public void Update(CarModel car)
        {
            try
            {
                this.context.Cars.Update(car);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao adicionar um novo carro: {ex.Message}");
            }
        }

        public CarModel GetById(Guid id)
        {
            try
            {
                var car = this.context.Cars.Find(id);

                if (car != null)
                {
                    return car;
                }

                throw new Exception($"Nenhum carro encontrado com o Id: {id}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar um carro com o Id: {id}. Erro: {ex.Message}");
            }
        }

        public void Delete(CarModel car)
        {
            try
            {
                this.context.Remove(car);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao apagar o carro com o Id: {car.Id}. Erro: {ex.Message}");
            }
        }
    }
}
