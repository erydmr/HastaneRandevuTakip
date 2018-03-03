using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Models
{
    public class Klinikler
    {
       
            public virtual int Id { get; set; }
            public virtual string klinikadi { get; set; }
            public virtual ICollection<Klinikler> klinikler { get; set; }
        }

        public class KliniklerMap : ClassMapping<Klinikler>
        {
            public KliniklerMap()
            {
                Table("klinikler");
                Id(x => x.Id, x => x.Generator(Generators.Identity));
                Property(x => x.klinikadi, x => x.NotNullable(true));
            }
        }
    }