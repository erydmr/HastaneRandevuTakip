using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Migrations
{
    [Migration(1)]
    public class _001_Hastalar_Yoneticiler : Migration
    {
        public override void Down()
        {
            Delete.Table("hastalar");
            Delete.Table("yoneticiler");
            Delete.Table("iller");
            Delete.Table("ilceler");
        }

        public override void Up()
        {
            Create.Table("hastalar")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("adsoyad").AsString(128)
                .WithColumn("tckimlik").AsString(128)
                .WithColumn("dogumtarihi").AsDateTime()
                .WithColumn("email").AsCustom("VARCHAR(256)")
                .WithColumn("tel").AsString(128)
                .WithColumn("cinsiyet").AsString(2)
                .WithColumn("adres").AsCustom("VARCHAR(256)")
                .WithColumn("parola_hash").AsString(128);


            Create.Table("yoneticiler")
               .WithColumn("id").AsInt32().Identity().PrimaryKey()
               .WithColumn("adsoyad").AsString(128)
               .WithColumn("email").AsCustom("VARCHAR(256)")
               .WithColumn("rol").AsInt32()
               .WithColumn("password_hash").AsString(128);

            Create.Table("iller")
              .WithColumn("id").AsInt32().Identity().PrimaryKey()
              .WithColumn("iladi").AsString(128);

            Create.Table("ilceler")
             .WithColumn("id").AsInt32().Identity().PrimaryKey()
             .WithColumn("ilid").AsInt32()
             .WithColumn("ilceadi").AsString(128);
        }
    }
}