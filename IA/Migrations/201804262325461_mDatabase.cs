namespace IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "TeamLeaderName", c => c.String());
            AddColumn("dbo.Teams", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddForeignKey("dbo.Teams", "LeaderId", "dbo.ProfessorLogs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "LeaderId", "dbo.ProfessorLogs");
            DropColumn("dbo.Teams", "Discriminator");
            DropColumn("dbo.Teams", "TeamLeaderName");
        }
    }
}
