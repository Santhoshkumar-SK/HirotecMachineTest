namespace MortgageCalculator.Dll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDbSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InterestDetails",
                c => new
                    {
                        InterestID = c.Int(nullable: false, identity: true),
                        EffectiveStartDate = c.DateTime(nullable: false),
                        EffectiveEndDate = c.DateTime(nullable: false),
                        MortgageType = c.Int(nullable: false),
                        InterestRepayment = c.Int(nullable: false),
                        MortgageDetailsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InterestID)
                .ForeignKey("dbo.Mortgages", t => t.MortgageDetailsId, cascadeDelete: true)
                .Index(t => t.MortgageDetailsId);
            
            CreateTable(
                "dbo.Mortgages",
                c => new
                    {
                        MortgageId = c.Int(nullable: false, identity: true),
                        MortgageName = c.String(nullable: false, maxLength: 50),
                        PrincipalAmount = c.Int(nullable: false),
                        RateofInterest = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TermsInMonths = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalInterest = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MortgageId);
            
            CreateTable(
                "dbo.MortgageFees",
                c => new
                    {
                        FeesID = c.Int(nullable: false, identity: true),
                        FeesName = c.String(),
                        FeesAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MortgageDetailsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FeesID)
                .ForeignKey("dbo.Mortgages", t => t.MortgageDetailsId, cascadeDelete: true)
                .Index(t => t.MortgageDetailsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InterestDetails", "MortgageDetailsId", "dbo.Mortgages");
            DropForeignKey("dbo.MortgageFees", "MortgageDetailsId", "dbo.Mortgages");
            DropIndex("dbo.MortgageFees", new[] { "MortgageDetailsId" });
            DropIndex("dbo.InterestDetails", new[] { "MortgageDetailsId" });
            DropTable("dbo.MortgageFees");
            DropTable("dbo.Mortgages");
            DropTable("dbo.InterestDetails");
        }
    }
}
