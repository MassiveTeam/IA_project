namespace IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberIds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberIds = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProfessorLogs", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.MemberIds, cascadeDelete: true)
                .Index(t => t.MemberIds)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.ProfessorLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        statues = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professiors", t => t.ProfId, cascadeDelete: true)
                .Index(t => t.ProfId);
            
            CreateTable(
                "dbo.Professiors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Department = c.String(),
                        Description = c.String(),
                        Password = c.String(),
                        Interests = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfIds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfIds = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professiors", t => t.ProfIds, cascadeDelete: true)
                .ForeignKey("dbo.ProfessorLogs", t => t.ProjectId, cascadeDelete: false)
                .Index(t => t.ProfIds)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        level = c.Int(nullable: false),
                        Gpa = c.Single(nullable: false),
                        Skills = c.String(),
                        Transcrip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        LeaderId = c.Int(nullable: false),
                        ProjectId = c.String(),
                        Description = c.String(),
                        Tools = c.String(),
                        State = c.Int(nullable: false),
                        ProjectName = c.String(),
                    })
                .PrimaryKey(t => t.TeamID)
                .ForeignKey("dbo.Students", t => t.LeaderId, cascadeDelete: true)
                .Index(t => t.LeaderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "LeaderId", "dbo.Students");
            DropForeignKey("dbo.MemberIds", "MemberIds", "dbo.Students");
            DropForeignKey("dbo.ProfIds", "ProjectId", "dbo.ProfessorLogs");
            DropForeignKey("dbo.ProfIds", "ProfIds", "dbo.Professiors");
            DropForeignKey("dbo.ProfessorLogs", "ProfId", "dbo.Professiors");
            DropForeignKey("dbo.MemberIds", "ProjectId", "dbo.ProfessorLogs");
            DropIndex("dbo.Teams", new[] { "LeaderId" });
            DropIndex("dbo.ProfIds", new[] { "ProjectId" });
            DropIndex("dbo.ProfIds", new[] { "ProfIds" });
            DropIndex("dbo.ProfessorLogs", new[] { "ProfId" });
            DropIndex("dbo.MemberIds", new[] { "ProjectId" });
            DropIndex("dbo.MemberIds", new[] { "MemberIds" });
            DropTable("dbo.Teams");
            DropTable("dbo.Students");
            DropTable("dbo.ProfIds");
            DropTable("dbo.Professiors");
            DropTable("dbo.ProfessorLogs");
            DropTable("dbo.MemberIds");
        }
    }
}
