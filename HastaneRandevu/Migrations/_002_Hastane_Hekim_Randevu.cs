using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Migrations
{
    [Migration (2)]
    public class _002_Hastane_Hekim_Randevu : Migration
    {
        public override void Down()
        {
            Delete.Table("hastaneler");
            Delete.Table("klinikler");
            Delete.Table("hekimler");
            Delete.Table("saatler");
        }

        public override void Up()
        {
            Create.Table("hastaneler")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("ilceid").AsInt32().ForeignKey("ilceler", "id").OnDelete(Rule.Cascade)
                .WithColumn("hastaneadi").AsString(128);

            Create.Table("klinikler")
               .WithColumn("id").AsInt32().Identity().PrimaryKey()
               .WithColumn("klinikadi").AsString(128);

            Create.Table("hekimler")
              .WithColumn("id").AsInt32().Identity().PrimaryKey()
              .WithColumn("hastaneid").AsInt32()
              .WithColumn("klinikid").AsInt32()
              .WithColumn("hekimadi").AsString(128)
              .WithColumn("password_hash").AsString(128);

            Create.Table("saatler")
             .WithColumn("id").AsInt32().Identity().PrimaryKey()
             .WithColumn("hekimid").AsInt32().ForeignKey("hekimler", "id").OnDelete(Rule.Cascade)
             .WithColumn("bossaat").AsInt32()
             .WithColumn("dolusaat").AsInt32()
             .WithColumn("tarih").AsDateTime();
        }
    }
}