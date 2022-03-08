namespace CodeFirstApproach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedBonusColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeModels", "Bonus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeModels", "Bonus");
        }
    }
}
