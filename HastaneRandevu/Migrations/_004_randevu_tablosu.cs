using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Migrations
{
    [Migration(4)]
    public class _004_randevu_tablosu : Migration
    {
        public override void Down()
        {
            Delete.Table("randevular");
        }

        public override void Up()
        {
            Create.Table("randevular")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("hastaid").AsInt32().ForeignKey("hastalar", "id").OnDelete(Rule.Cascade)
                .WithColumn("hekimid").AsInt32().ForeignKey("hekimler", "id").OnDelete(Rule.Cascade)
                .WithColumn("klinikid").AsInt32().ForeignKey("klinikler", "id").OnDelete(Rule.Cascade)
                .WithColumn("saat").AsInt32()
                .WithColumn("tarih").AsDateTime()
                .WithColumn("randevudurumu").AsBoolean();
        }
    }
}