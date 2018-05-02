namespace IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemberIds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstMemberId = c.Int(nullable: false),
                        SecondMemberId = c.Int(nullable: false),
                        ThridMemberId = c.Int(),
                        FourthMemberId = c.Int(),
                        FifthMemberId = c.Int(),
                        ProjectId = c.Int(nullable: false),
                        ProfessorLog_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProfessorLogs", t => t.ProfessorLog_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.ProfessorLog_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Professiors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Department = c.String(),
                        Description = c.String(),
                        Interests = c.String(),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfessorLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfId = c.Int(),
                        statues = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Professior_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professiors", t => t.Professior_Id)
                .Index(t => t.Professior_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        LeaderId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Description = c.String(),
                        Tools = c.String(),
                        State = c.Int(nullable: false),
                        ProjectName = c.String(),
                        TeamLeaderName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        professor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.TeamID)
                .ForeignKey("dbo.ProfessorLogs", t => t.professor_Id)
                .ForeignKey("dbo.Students", t => t.LeaderId, cascadeDelete: true)
                .Index(t => t.LeaderId)
                .Index(t => t.professor_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        level = c.Int(nullable: false),
                        Gpa = c.Single(nullable: false),
                        Skills = c.String(),
                        Transcrip = c.String(),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfIds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstProfId = c.Int(nullable: false),
                        SecondProfId = c.Int(),
                        ThridProfId = c.Int(),
                        ProjectId = c.Int(nullable: false),
                        Professior_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professiors", t => t.Professior_Id)
                .Index(t => t.Professior_Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sender = c.String(),
                        Reports = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfIds", "Professior_Id", "dbo.Professiors");
            DropForeignKey("dbo.ProfessorLogs", "Professior_Id", "dbo.Professiors");
            DropForeignKey("dbo.Teams", "LeaderId", "dbo.Students");
            DropForeignKey("dbo.MemberIds", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Teams", "professor_Id", "dbo.ProfessorLogs");
            DropForeignKey("dbo.MemberIds", "ProfessorLog_Id", "dbo.ProfessorLogs");
            DropIndex("dbo.ProfIds", new[] { "Professior_Id" });
            DropIndex("dbo.Teams", new[] { "professor_Id" });
            DropIndex("dbo.Teams", new[] { "LeaderId" });
            DropIndex("dbo.ProfessorLogs", new[] { "Professior_Id" });
            DropIndex("dbo.MemberIds", new[] { "Student_Id" });
            DropIndex("dbo.MemberIds", new[] { "ProfessorLog_Id" });
            DropTable("dbo.Reports");
            DropTable("dbo.ProfIds");
            DropTable("dbo.Students");
            DropTable("dbo.Teams");
            DropTable("dbo.ProfessorLogs");
            DropTable("dbo.Professiors");
            DropTable("dbo.MemberIds");
            DropTable("dbo.Admins");
        }
    }
}
