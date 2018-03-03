using HastaneRandevu.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Models
{
    public class Hastaneler
    {

        public virtual int Id { get; set; }
        public virtual int IlceID { get; set; }
        public virtual string HastaneAdi { get; set; }
    }
}

public class HastanelerMap : ClassMapping<Hastaneler>
{
    public HastanelerMap()
    {
        Table("hastaneler");

        Id(x => x.Id, x => x.Generator(Generators.Identity));
        Property(x => x.IlceID, x => x.NotNullable(true));
        Property(x => x.HastaneAdi, x => x.NotNullable(true));

    }
}