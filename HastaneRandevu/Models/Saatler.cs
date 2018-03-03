using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Models
{
    public class Saatler
    {
        public virtual int Id { get; set; }
        public virtual string hekimId { get; set; }
        public virtual string doluSaat { get; set; }
        public virtual DateTime tarih { get; set; }
    }

    public class SaatlerMap : ClassMapping<Saatler>
    {
        public SaatlerMap()
        {
            Table("saatler");
            Id(x => x.Id, x => x.Generator(Generators.Identity));
            Property(x => x.hekimId, x => x.NotNullable(true));
            Property(x => x.doluSaat, x => x.NotNullable(true));
            Property(x => x.tarih, x => x.NotNullable(true));
        }
    }
}