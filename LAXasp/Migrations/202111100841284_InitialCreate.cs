namespace LAXasp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        FilmID = c.Int(nullable: false, identity: true),
                        Titel = c.String(),
                        Instruktør = c.String(),
                        Årstal = c.Int(nullable: false),
                        Længde = c.String(),
                        Rating = c.Int(nullable: false),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.FilmID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Films");
        }
    }
}
