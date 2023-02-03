namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FitnessDBv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        IDEsercizio = c.Int(nullable: false, identity: true),
                        NomeEsercizio = c.String(nullable: false),
                        DescrizioneEsercizio = c.String(nullable: false),
                        StatoEsercizio = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IDEsercizio);
            
            CreateTable(
                "dbo.WorkoutExercise",
                c => new
                    {
                        IDEsercizioScheda = c.Int(nullable: false, identity: true),
                        IDEsercizio = c.Int(nullable: false),
                        IDScheda = c.Int(nullable: false),
                        SerieEsercizio = c.Int(nullable: false),
                        RipetizioniEsercizio = c.String(nullable: false, maxLength: 50),
                        NoteEsercizio = c.String(),
                    })
                .PrimaryKey(t => t.IDEsercizioScheda)
                .ForeignKey("dbo.WorkoutPlan", t => t.IDScheda)
                .ForeignKey("dbo.Exercises", t => t.IDEsercizio)
                .Index(t => t.IDEsercizio)
                .Index(t => t.IDScheda);
            
            CreateTable(
                "dbo.WorkoutPlan",
                c => new
                    {
                        IDScheda = c.Int(nullable: false, identity: true),
                        IDUtente = c.Int(nullable: false),
                        StatoScheda = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IDScheda)
                .ForeignKey("dbo.Users", t => t.IDUtente)
                .Index(t => t.IDUtente);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IDUtente = c.Int(nullable: false, identity: true),
                        NomeUtente = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 10),
                        Ruolo = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.IDUtente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkoutExercise", "IDEsercizio", "dbo.Exercises");
            DropForeignKey("dbo.WorkoutExercise", "IDScheda", "dbo.WorkoutPlan");
            DropForeignKey("dbo.WorkoutPlan", "IDUtente", "dbo.Users");
            DropIndex("dbo.WorkoutPlan", new[] { "IDUtente" });
            DropIndex("dbo.WorkoutExercise", new[] { "IDScheda" });
            DropIndex("dbo.WorkoutExercise", new[] { "IDEsercizio" });
            DropTable("dbo.Users");
            DropTable("dbo.WorkoutPlan");
            DropTable("dbo.WorkoutExercise");
            DropTable("dbo.Exercises");
        }
    }
}
