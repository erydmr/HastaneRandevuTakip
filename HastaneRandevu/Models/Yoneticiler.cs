using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Models
{
    public class Yoneticiler
    {
        public virtual int Id { get; set; }
        public virtual string AdSoyad { get; set; }
        public virtual string Email { get; set; }
        public virtual string Rol { get; set; }
        public virtual string Password_Hash { get; set; }

        public virtual void SetPassword(string password)
        {
            Password_Hash = BCrypt.Net.BCrypt.HashString(password, 13);
        }

        public virtual bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password_Hash);
        }

        public static void FakeHash()
        {
            BCrypt.Net.BCrypt.HashPassword("", 13);
        }
    }




    public class YoneticilerMap : ClassMapping<Yoneticiler>
    {
        public YoneticilerMap()
        {
            Table("yoneticiler");

            Id(x => x.Id, x => x.Generator(Generators.Identity));

            Property(x => x.AdSoyad, x => x.NotNullable(true));
            Property(x => x.Email, x => x.NotNullable(true));
            Property(x => x.Rol, x => x.NotNullable(true));
            Property(x => x.Password_Hash, x =>
            {
                x.Column("password_hash");
                x.NotNullable(true);
            });
        }
    }
}