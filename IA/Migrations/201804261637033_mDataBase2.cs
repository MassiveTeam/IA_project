namespace IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mDataBase2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MemberIds", "MemberIds", "dbo.Students");
            DropIndex("dbo.MemberIds", new[] { "MemberIds" });
            RenameColumn(table: "dbo.ProfIds", name: "ProfIds", newName: "Professior_Id");
            RenameColumn(table: "dbo.MemberIds", name: "MemberIds", newName: "Student_Id");
            RenameIndex(table: "dbo.ProfIds", name: "IX_ProfIds", newName: "IX_Professior_Id");
            AddColumn("dbo.MemberIds", "FirstMemberId", c => c.Int(nullable: false));
            AddColumn("dbo.MemberIds", "SecondMemberId", c => c.Int(nullable: false));
            AddColumn("dbo.MemberIds", "ThridMemberId", c => c.Int());
            AddColumn("dbo.MemberIds", "FourthMemberId", c => c.Int());
            AddColumn("dbo.MemberIds", "FifthMemberId", c => c.Int());
            AddColumn("dbo.ProfIds", "FirstProfId", c => c.Int(nullable: false));
            AddColumn("dbo.ProfIds", "SecondProfId", c => c.Int());
            AddColumn("dbo.ProfIds", "ThridProfId", c => c.Int());
            AlterColumn("dbo.MemberIds", "Student_Id", c => c.Int());
            AlterColumn("dbo.Teams", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.MemberIds", "Student_Id");
            AddForeignKey("dbo.MemberIds", "Student_Id", "dbo.Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberIds", "Student_Id", "dbo.Students");
            DropIndex("dbo.MemberIds", new[] { "Student_Id" });
            AlterColumn("dbo.Teams", "ProjectId", c => c.String());
            AlterColumn("dbo.MemberIds", "Student_Id", c => c.Int(nullable: false));
            DropColumn("dbo.ProfIds", "ThridProfId");
            DropColumn("dbo.ProfIds", "SecondProfId");
            DropColumn("dbo.ProfIds", "FirstProfId");
            DropColumn("dbo.MemberIds", "FifthMemberId");
            DropColumn("dbo.MemberIds", "FourthMemberId");
            DropColumn("dbo.MemberIds", "ThridMemberId");
            DropColumn("dbo.MemberIds", "SecondMemberId");
            DropColumn("dbo.MemberIds", "FirstMemberId");
            RenameIndex(table: "dbo.ProfIds", name: "IX_Professior_Id", newName: "IX_ProfIds");
            RenameColumn(table: "dbo.MemberIds", name: "Student_Id", newName: "MemberIds");
            RenameColumn(table: "dbo.ProfIds", name: "Professior_Id", newName: "ProfIds");
            CreateIndex("dbo.MemberIds", "MemberIds");
            AddForeignKey("dbo.MemberIds", "MemberIds", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
