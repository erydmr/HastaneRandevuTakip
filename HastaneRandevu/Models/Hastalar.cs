using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Models
{
    public class Hastalar
    {
        public virtual int Id { get; set; }
        public virtual string AdSoyad { get; set; }
        public virtual string TcKimlik { get; set; }
        public virtual DateTime DogumTarihi { get; set; }
        public virtual string Email { get; set; }
        public virtual string Tel { get; set; }
        public virtual string Cinsiyet { get; set; }
        public virtual string Adres { get; set; }
        public virtual string Parola_Hash { get; set; }


        public virtual void SetPassword(string password)
        {
            Parola_Hash = BCrypt.Net.BCrypt.HashString(password, 13);
        }

        public virtual bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Parola_Hash);
        }

        public static void FakeHash()
        {
            BCrypt.Net.BCrypt.HashPassword("", 13);
        }
    }

    public class HastalarMap : ClassMapping<Hastalar>
    {
        public HastalarMap()
        {
            Table("hastalar");

            Id(x => x.Id, x => x.Generator(Generators.Identity));

            Property(x => x.AdSoyad, x => x.NotNullable(true));
            Property(x => x.TcKimlik, x => x.NotNullable(true));
            Property(x => x.DogumTarihi, x => x.NotNullable(true));
            Property(x => x.Email, x => x.NotNullable(true));
            Property(x => x.Tel, x => x.NotNullable(true));
            Property(x => x.Cinsiyet, x => x.NotNullable(true));
            Property(x => x.Adres, x => x.NotNullable(true));

            Property(x => x.Parola_Hash, x =>
            {
                x.Column("parola_hash");
                x.NotNullable(true);
            });
        }
    }
}