namespace CapstoneProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkoutPlan")]
    public partial class WorkoutPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkoutPlan()
        {
            WorkoutExercise = new HashSet<WorkoutExercise>();
        }

        [Key]
        public int IDScheda { get; set; }

        public int IDUtente { get; set; }

        public bool StatoScheda { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkoutExercise> WorkoutExercise { get; set; }
    }
}
