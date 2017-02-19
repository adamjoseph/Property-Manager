namespace PropertyManager_VS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForthMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Properties", "PropertyImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Properties", "PropertyImage", c => c.Binary());
        }
    }
}
