using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Models
{
    public class Randevular
    {
        public virtual int Id { get; set; }
        public virtual int hastaId { get; set; }
        public virtual int hekimId { get; set; }
        public virtual int klinikId { get; set; }
        public virtual string Saat { get; set; }
        public virtual string Tarih { get; set; }
       
    }

    public class RandevularMap : ClassMapping<Randevular>
    {
        public RandevularMap()
        {
            Table("randevular");

            Id(x => x.Id, x => x.Generator(Generators.Identity));
            Property(x => x.hastaId, x => x.NotNullable(true));
            Property(x => x.hekimId, x => x.NotNullable(true));
            Property(x => x.klinikId, x => x.NotNullable(true));
            Property(x => x.Saat, x => x.NotNullable(true));
            Property(x => x.Tarih, x => x.NotNullable(true));
        }
    }
}