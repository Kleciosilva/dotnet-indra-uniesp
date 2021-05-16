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

        public void Create(CarModel car)
        {
            try
            {
                this.context.Cars.Add(car);
                this.context.SaveChanges();
                Console.WriteLine("---------------------> Created");
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao adicionar um novo carro: {ex.Message}");
            }
        }

        //Update()
        //Delete()
        //Get(plate)<Automobile>
    }
}
