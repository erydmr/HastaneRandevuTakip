using HastaneRandevu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Areas.Admin.ViewModels
{
    public class HastaneIndex
    {
    
        public IEnumerable<Hastaneler> Hastaneler { get; set; }
    }

    public class HastaneYeni
    {
        [Required, MaxLength(128)]
        public string IlceID { get; set; }
        [Required, MaxLength(128)]
        public string HastaneAdi { get; set; }


    }

    public class HastaneDuzenle
    {
        [Required, MaxLength(128)]
        public string IlceID { get; set; }
        [Required, MaxLength(128)]
        public string HastaneAdi { get; set; }

    }
    
}