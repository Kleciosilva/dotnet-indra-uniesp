using Backend.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Service
{
    public class MotoService
    {
        private MotoRepository repository = new MotoRepository();

        public MotoService() {}

        public IEnumerable<MotoModel> List()
        {
            return repository.List();
        }

        public MotoModel GetById(Guid id)
        {
            try
            {
                var moto = this.repository.GetById(id);
                return moto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Nenhuma moto encontrada com este Id. {ex.Message}");
            }
        }

        public List<MotoModel> GetByManufacturer(string manufacturer)
        {
            return this.repository.GetByManufacturer(manufacturer);
        }

        public void Delete(Guid id)
        {
            try
            {
                var moto = this.GetById(id);
                this.repository.Delete(moto);
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao apagar a moto. {ex.Message}");
            }
        }
    }
}
