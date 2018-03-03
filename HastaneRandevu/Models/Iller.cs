using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Models
{
    public class Iller
    {
        public virtual int Id { get; set; }
        public virtual string IlAdi { get; set; }
        public virtual ICollection<Ilceler> ilceler { get; set; }
    }

    public class IllerMap : ClassMapping<Iller>
    {
        public IllerMap()
        {
            Table("iller");
            Id(x => x.Id, x => x.Generator(Generators.Identity));
            Property(x => x.IlAdi, x => x.NotNullable(true));
        }
    }
}