using HastaneRandevu.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Models
{
    public class Hekimler
    {
        public virtual int Id { get; set; }
        public virtual int hastaneID { get; set; }
        public virtual int klinikID { get; set; }
        public virtual string hekimAdi { get; set; }
        public virtual string Email { get; set; }
        public virtual string PasswordHash { get; set; }

        public virtual void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashString(password, 13);
        }

        public virtual bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }

        public static void FakeHash()
        {
            BCrypt.Net.BCrypt.HashPassword("", 13);
        }
    }
}

public class HekimlerMap : ClassMapping<Hekimler>
{
    public HekimlerMap()
    {
        Table("hekimler");

        Id(x => x.Id, x => x.Generator(Generators.Identity));
        Property(x => x.hastaneID, x => x.NotNullable(true));
        Property(x => x.klinikID, x => x.NotNullable(true));
        Property(x => x.hekimAdi, x => x.NotNullable(true));
        Property(x => x.Email, x => x.NotNullable(true));

        Property(x => x.PasswordHash, x =>
        {
            x.Column("password_hash");
            x.NotNullable(true);
        });
    }
}