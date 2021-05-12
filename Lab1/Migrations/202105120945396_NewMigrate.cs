namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        number = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        DateOut = c.DateTime(nullable: false),
                        Cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NewStudents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Otch = c.String(),
                        PasportSer = c.Int(nullable: false),
                        PasportNumber = c.Int(nullable: false),
                        ZachetNumber = c.Int(nullable: false),
                        Sex = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Town = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ViolationContents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        Penalties = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Violations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        category = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Violations");
            DropTable("dbo.ViolationContents");
            DropTable("dbo.NewStudents");
            DropTable("dbo.Contracts");
        }
    }
}
