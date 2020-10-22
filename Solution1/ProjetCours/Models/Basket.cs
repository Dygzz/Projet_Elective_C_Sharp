using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetCours.Utils;

namespace ProjetCours.Models
{
    public class Basket
    {
        public Dictionary<int, int> Cars { get; set; } = new Dictionary<int, int>();

        public void AddCar(int idCar)
        {
            if (Cars.ContainsKey(idCar))
                Cars[idCar] ++;
            else
                Cars.Add(idCar, 1);
        }

        public String ToJson()
        {
            return "{\"Cars\":" + Cars.ToJson() + "}"; 
        }
    }
}
