using HastaneRandevu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HastaneRandevu.ViewModels
{
    public class HastaLogin
    {
        [Required]
        public string TcKimlik { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
    }

    public class HastaKayit
    {

        public int HastaId { get; set; }

        [Required]
        public string AdSoyad { get; set; }

        [Required, MaxLength(11), MinLength(11)]
        public string TcKimlik { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime DogumTarihi { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Tel { get; set; }

        [Required, MaxLength(2)]
        public string Cinsiyet { get; set; }

        [Required]
        public string Adres { get; set; }

        [Required, DataType(DataType.Password)]
        public string Sifre { get; set; }
    }

    public class HastaRandevu
    {
        public int HastaId { get; set; }
        
        public string Tarih { get; set; }

        public string drpil { get; set; }
      
        public string drpilce { get; set; }
        
        public string drphastane { get; set; }
                
        public string drpklinik { get; set; }

        public string drphekim { get; set; }
        
        public string drpsaat { get; set; }
    }


    public class HastaIlIlce
    {
        public int Id { get; set; }
        public int ilId { get; set; }
        public int ilceId { get; set; }

    }
}