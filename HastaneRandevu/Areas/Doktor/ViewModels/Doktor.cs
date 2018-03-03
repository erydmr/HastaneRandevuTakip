using HastaneRandevu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Areas.Doktor.ViewModels
{
    public class DoktorLogin
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Sifre { get; set; }
    }

    public class DoktorRandevu
    {
        public IEnumerable<Randevular> Randevular { get; set; }
    }

}