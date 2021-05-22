using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Backend
{
    public class MotoModel : IVehicle
    {
        public MotoModel(string name, string model, string factoryYear, string color)
        {
            this.Name = name;
            this.Model = model;
            this.FactoryYear = factoryYear;
            this.Color = color;
            this.Type = "Moto";
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string FactoryYear { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }

        public string Honk() => "Piii";

        public string Honk(string honk)
        {
            return honk;
        }

    }
}
