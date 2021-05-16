using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Backend
{
    public class CarModel : IVehicle
    {
        public CarModel(string name, string model, string factoryYear, string color)
        {
            this.Name = name;
            this.Model= model;
            this.FactoryYear = factoryYear;
            this.Color = color;
            this.Type = "Car";
        }


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public string Model { get; set; }
        public string FactoryYear { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        
        public string Honk() => "PiBiii";

        public string Honk(string honk)
        {
            return honk;
        }
    }
}
