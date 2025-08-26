namespace MortgageCalculator.Dll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMonthlyAmortizations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonthlyAmortizations",
                c => new
                    {
                        PaymentId = c.Long(nullable: false, identity: true),
                        PaymentCount = c.Int(nullable: false),
                        OpeningBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmiAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MonthlyPrincipal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MonthlyInterest = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OutStandingPrincipal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MortgageDetailsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Mortgages", t => t.MortgageDetailsId, cascadeDelete: true)
                .Index(t => t.MortgageDetailsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonthlyAmortizations", "MortgageDetailsId", "dbo.Mortgages");
            DropIndex("dbo.MonthlyAmortizations", new[] { "MortgageDetailsId" });
            DropTable("dbo.MonthlyAmortizations");
        }
    }
}
