using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Repository
{
    public class MotoRepository
    {
        private VehiclesContext context;

        public MotoRepository()
        {
            this.context = new VehiclesContext();
        }

        public List<MotoModel> List()
        {
            return this.context.Motos.ToList();
        }

        public List<MotoModel> GetByManufacturer(string manufacturer)
        {
            try
            {
                var motos = this.context.Motos
                    .Where(x => x.Manufacturer.Equals(manufacturer))
                    .OrderBy(x => x.Name);
                if (motos != null && motos.Any())
                {
                    return motos.ToList();
                }
                throw new Exception($"Nenhuma moto localizada com o fabricante: {manufacturer}");
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao filtrar por fabricante: {ex.Message}");
            }
        }

        public void Create(MotoModel moto)
        {
            try
            {
                this.context.Motos.Add(moto);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao adicionar uma nova moto: {ex.Message}");
            }
        }

        public void Update(MotoModel moto)
        {
            try
            {
                this.context.Motos.Update(moto);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao adicionar um nova moto: {ex.Message}");
            }
        }

        public MotoModel GetById(Guid id)
        {
            try
            {
                var moto = this.context.Motos.Find(id);

                if (moto != null)
                {
                    return moto;
                }

                throw new Exception($"Nenhuma moto encontrada com o Id: {id}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar uma moto com o Id: {id}. Erro: {ex.Message}");
            }
        }

        public void Delete(MotoModel moto)
        {
            try
            {
                this.context.Remove(moto);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao apagar a moto com o Id: {moto.Id}. Erro: {ex.Message}");
            }
        }
    }
}
