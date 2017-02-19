namespace PropertyManager_VS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "Rent", c => c.Int(nullable: false));
            AddColumn("dbo.Properties", "SqFt", c => c.Int(nullable: false));
            AddColumn("dbo.Properties", "Bedrooms", c => c.Int(nullable: false));
            AddColumn("dbo.Properties", "LeaseTerms", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "LeaseTerms");
            DropColumn("dbo.Properties", "Bedrooms");
            DropColumn("dbo.Properties", "SqFt");
            DropColumn("dbo.Properties", "Rent");
        }
    }
}
