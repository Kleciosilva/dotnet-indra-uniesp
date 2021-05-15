using System;

namespace Backend
{
    public interface IAutomobile
    {
        public string Name { get; set; }

        public string Model{ get; set; }

        public string FactoryYear { get; set; }

        public string Color { get; set; }

        public string Type { get; set; }

        public string Honk();
    }
}
