using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Service
{
    public class CarService
    {

        public CarController Test()
        {
            return new CarController("Fusca", "1990", "1999", "Azul");
        }
    }
}
