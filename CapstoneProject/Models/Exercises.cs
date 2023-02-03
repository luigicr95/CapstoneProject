namespace CapstoneProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Exercises
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exercises()
        {
            WorkoutExercise = new HashSet<WorkoutExercise>();
        }

        [Key]
        public int IDEsercizio { get; set; }

        [Required]
        public string NomeEsercizio { get; set; }

        [Required]
        public string DescrizioneEsercizio { get; set; }

        public bool StatoEsercizio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkoutExercise> WorkoutExercise { get; set; }
    }
}
