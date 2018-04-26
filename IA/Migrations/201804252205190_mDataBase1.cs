namespace IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mDataBase1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProfessorLogs", "ProfId", "dbo.Professiors");
            DropForeignKey("dbo.ProfIds", "ProfIds", "dbo.Professiors");
            DropIndex("dbo.ProfessorLogs", new[] { "ProfId" });
            DropIndex("dbo.ProfIds", new[] { "ProfIds" });
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sender = c.String(),
                        Reports = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Admins", "Email", c => c.String());
            AddColumn("dbo.Professiors", "UserName", c => c.String());
            AddColumn("dbo.Professiors", "Email", c => c.String());
            AddColumn("dbo.Students", "UserName", c => c.String());
            AddColumn("dbo.Students", "Email", c => c.String());
            AddColumn("dbo.Students", "Password", c => c.String());
            AlterColumn("dbo.ProfessorLogs", "ProfId", c => c.Int());
            AlterColumn("dbo.ProfIds", "ProfIds", c => c.Int());
            CreateIndex("dbo.ProfessorLogs", "ProfId");
            CreateIndex("dbo.ProfIds", "ProfIds");
            AddForeignKey("dbo.ProfessorLogs", "ProfId", "dbo.Professiors", "Id");
            AddForeignKey("dbo.ProfIds", "ProfIds", "dbo.Professiors", "Id");
            DropColumn("dbo.Professiors", "Name");
            DropColumn("dbo.Students", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Name", c => c.String());
            AddColumn("dbo.Professiors", "Name", c => c.String());
            DropForeignKey("dbo.ProfIds", "ProfIds", "dbo.Professiors");
            DropForeignKey("dbo.ProfessorLogs", "ProfId", "dbo.Professiors");
            DropIndex("dbo.ProfIds", new[] { "ProfIds" });
            DropIndex("dbo.ProfessorLogs", new[] { "ProfId" });
            AlterColumn("dbo.ProfIds", "ProfIds", c => c.Int(nullable: false));
            AlterColumn("dbo.ProfessorLogs", "ProfId", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "Password");
            DropColumn("dbo.Students", "Email");
            DropColumn("dbo.Students", "UserName");
            DropColumn("dbo.Professiors", "Email");
            DropColumn("dbo.Professiors", "UserName");
            DropColumn("dbo.Admins", "Email");
            DropTable("dbo.Reports");
            CreateIndex("dbo.ProfIds", "ProfIds");
            CreateIndex("dbo.ProfessorLogs", "ProfId");
            AddForeignKey("dbo.ProfIds", "ProfIds", "dbo.Professiors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProfessorLogs", "ProfId", "dbo.Professiors", "Id", cascadeDelete: true);
        }
    }
}
