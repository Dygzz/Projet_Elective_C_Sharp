using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjetCours.Data;
using ProjetCours.Models;

namespace ProjetCours.Controlers
{
    public class BasketController : Controller
    {
        private readonly ProjetCoursContext _context;

        public BasketController(ProjetCoursContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult AddCarToBasket(int idCar)
        {
            Basket basket;
            if (this.HttpContext.Session.GetString("BASKET") != null)
                basket = JsonConvert.DeserializeObject<Basket>(this.HttpContext.Session.GetString("BASKET"));
            else
                basket = new Basket();
            basket.AddCar(idCar);
            var json = basket.ToJson();
            this.HttpContext.Session.SetString("BASKET", json);
            return Ok(json);
        }

        public async  Task<IActionResult> Index()
        {
            var vm = new BasketViewModel();
            if (this.HttpContext.Session.GetString("BASKET") != null)
            {
                var bucket = JsonConvert.DeserializeObject<Basket>(this.HttpContext.Session.GetString("BASKET"));
                Dictionary<Car, int> Cars = new Dictionary<Car, int>();
                foreach (var item in bucket.Cars)
                {
                    var car = await _context.Car.Include(x => x.FuelType)
                        .SingleOrDefaultAsync(m => m.ID == item.Key);
                    Cars.Add(car,item.Value);
                    var carQt = new CarsQt(car, item.Value);
                    vm.Cars.Add(carQt);
                    vm.Total += car.Price.GetValueOrDefault() * item.Value;
                }
            }
            return View(vm);
        }
    } 
}
