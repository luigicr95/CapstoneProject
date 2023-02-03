namespace CapstoneProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkoutExercise")]
    public partial class WorkoutExercise
    {
        [Key]
        public int IDEsercizioScheda { get; set; }

        public int IDEsercizio { get; set; }

        public int IDScheda { get; set; }

        public int SerieEsercizio { get; set; }

        [Required]
        [StringLength(50)]
        public string RipetizioniEsercizio { get; set; }

        public string NoteEsercizio { get; set; }

        public virtual Exercises Exercises { get; set; }

        public virtual WorkoutPlan WorkoutPlan { get; set; }
    }
}
