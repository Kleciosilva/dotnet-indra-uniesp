using Backend.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Controller
{
    public class MotoController
    {
        private MotoModel moto;
        private MotoRepository repository;

        public MotoController(string name, string model, string factoryYear, string color)
        {
            this.moto = new MotoModel(name, model, factoryYear, color);

            this.repository = new MotoRepository();
        }

        public void Save()
        {
            this.repository.Create(this.moto);
        }

        public void Update(string id)
        {
            Guid MotoId = Guid.Parse(id);
            this.moto.Id = MotoId;

            this.repository.Update(this.moto);
        }
    }
}
