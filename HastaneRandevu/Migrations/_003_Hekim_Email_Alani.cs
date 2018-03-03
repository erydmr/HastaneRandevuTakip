using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Migrations
{
    [Migration(3)]
    public class _003_Hekim_Email_Alani : Migration
    {
        public override void Down()
        {
            Delete.Column("email").FromTable("hekimler");
        }

        public override void Up()
        {
            Create.Column("email").OnTable("hekimler").AsString(128);
        }
    }
}