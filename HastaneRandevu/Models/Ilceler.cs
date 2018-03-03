using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Models
{
    public class Ilceler
    {
        public virtual int Id { get; set; }
        public virtual int IlId { get; set; }
        public virtual string IlceAdi { get; set; }
        public virtual Iller iller { get; set; }
    }

    public class IlcelerMap : ClassMapping<Ilceler>
    {
        public IlcelerMap()
        {
            Table("ilceler");
            Id(x => x.Id, x => x.Generator(Generators.Identity));
            Property(x => x.IlId, x => x.NotNullable(true));
            Property(x => x.IlceAdi, x => x.NotNullable(true));
        }
    }
}