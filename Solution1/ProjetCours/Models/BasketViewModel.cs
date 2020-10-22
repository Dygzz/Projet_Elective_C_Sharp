using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetCours.Models
{
    public class BasketViewModel
    {
        public decimal Total { get; set; }

        public List<CarsQt> Cars { get; set; } = new List<CarsQt>();

    }

    public class CarsQt
    {
        public Car Car { get; set; }
        public int Count { get; set; }

        public CarsQt(Car car, int count)
        {
            Car = car;
            Count = count;
        }
    }
}
