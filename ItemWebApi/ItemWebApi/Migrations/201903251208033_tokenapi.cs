namespace ItemWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tokenapi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
    "dbo.People",   // название таблицы
    c => new    // столбцы
    {
        Id = c.Int(nullable: false, identity: true),
        Email = c.String(),
        Token = c.String(),
        ApiToken = c.String(),
    })
    .PrimaryKey(t => t.Id); // первичный ключ
        }
        
        public override void Down()
        {
            DropTable("dbo.people");
        }
    }
}
