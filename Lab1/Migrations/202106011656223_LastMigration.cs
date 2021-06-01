namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaveRooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NumberRoom = c.Int(nullable: false),
                        NumberFloor = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LeaveRooms");
        }
    }
}
