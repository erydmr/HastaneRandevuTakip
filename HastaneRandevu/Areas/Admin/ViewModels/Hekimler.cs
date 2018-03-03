using HastaneRandevu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Areas.Admin.ViewModels
{
    public class HekimIndex
    {

        public IEnumerable<Hekimler> Hekimler { get; set; }
    }

    public class HekimYeni
    {
        [Required, MaxLength(128)]
        public string HastaneID { get; set; }
        [Required, MaxLength(128)]
        public string KlinikID { get; set; }
        [Required, MaxLength(128)]
        public string HekimAdi { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }


    }

    public class HekimDuzenle
    {
        [Required, MaxLength(128)]
        public string HastaneID { get; set; }
        [Required, MaxLength(128)]
        public string KlinikID { get; set; }
        [Required, MaxLength(128)]
        public string HekimAdi { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }


    public class HekimSifre
    {
        public string HekimAdi { get; set; }

        [Required, DataType(DataType.Password)]
        public string Parola { get; set; }

    }
}