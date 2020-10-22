using ProjetCours.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetCours.Models
{
    //[Table] -> attribut pour agir sur la table lier au model
    public class Car
    {
        public int ID { get; set; }

        
        //[column] -> attribut pour sur la collone dans la base
        [Display(Name = "Marque", Prompt = "Marque du véhicule")]
        [BlackList("reno", "citroen", ErrorMessage = "Cette {0} ne peut pas etre {1}")]
        public string Mark{get; set;}
        [Display(Name = "Model", Prompt = "Model du véhicule")]
        [Required(ErrorMessage = "La {0} est obligatoire")]
        public string Model{get; set;}
        [Display(Name = "Prix", Prompt = "Prix du véhicule")]
        [DataType(DataType.Currency)]
        //Nullable <decimal> peut aussi s'écrire -> decimal?
        public Nullable<decimal> Price{get; set;}
        [ForeignKey("FuelTypeId")]
        public Fuel FuelType{get; set;}
        [Display(Name = "Type de caburant", Prompt = "Type de caburant du véhicule")]
        public int FuelTypeId { get; set; }
        [Display(Name = "Automatic", Prompt = "le véhicule est il automatic")]
        public bool Autonomous{get; set;}

    }
}
