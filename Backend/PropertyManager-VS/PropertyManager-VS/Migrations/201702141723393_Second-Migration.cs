namespace PropertyManager_VS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Properties", "Zip", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Properties", "ContactPhone", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Properties", "ContactPhone", c => c.Int(nullable: false));
            AlterColumn("dbo.Properties", "Zip", c => c.Int(nullable: false));
        }
    }
}
