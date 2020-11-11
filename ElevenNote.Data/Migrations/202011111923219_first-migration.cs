namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Notes");
            DropColumn("dbo.Notes", "NotedId");
            AddColumn("dbo.Notes", "NoteId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Notes", "NoteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "NotedId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Notes");
            DropColumn("dbo.Notes", "NoteId");
            AddPrimaryKey("dbo.Notes", "NotedId");
        }
    }
}
