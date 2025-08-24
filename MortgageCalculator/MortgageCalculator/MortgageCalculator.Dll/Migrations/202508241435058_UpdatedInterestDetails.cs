namespace MortgageCalculator.Dll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedInterestDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InterestDetails", "MortgageDetailsId", "dbo.Mortgages");
            RenameColumn(table: "dbo.InterestDetails", name: "MortgageDetailsId", newName: "MortgageId");
            RenameIndex(table: "dbo.InterestDetails", name: "IX_MortgageDetailsId", newName: "IX_MortgageId");
            DropPrimaryKey("dbo.InterestDetails");
            AddPrimaryKey("dbo.InterestDetails", "MortgageId");
            AddForeignKey("dbo.InterestDetails", "MortgageId", "dbo.Mortgages", "MortgageId");
            DropColumn("dbo.InterestDetails", "InterestID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InterestDetails", "InterestID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.InterestDetails", "MortgageId", "dbo.Mortgages");
            DropPrimaryKey("dbo.InterestDetails");
            AddPrimaryKey("dbo.InterestDetails", "InterestID");
            RenameIndex(table: "dbo.InterestDetails", name: "IX_MortgageId", newName: "IX_MortgageDetailsId");
            RenameColumn(table: "dbo.InterestDetails", name: "MortgageId", newName: "MortgageDetailsId");
            AddForeignKey("dbo.InterestDetails", "MortgageDetailsId", "dbo.Mortgages", "MortgageId", cascadeDelete: true);
        }
    }
}
