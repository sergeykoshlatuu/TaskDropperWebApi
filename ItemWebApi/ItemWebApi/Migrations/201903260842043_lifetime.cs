namespace ItemWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lifetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "TokenLifeTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "TokenLifeTime");
        }
    }
}
