using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CapstoneProject
{
    public partial class ModelDBContext : DbContext
    {
        public ModelDBContext()
            : base("name=ModelDBContext")
        {
        }

        public virtual DbSet<Exercises> Exercises { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WorkoutExercise> WorkoutExercise { get; set; }
        public virtual DbSet<WorkoutPlan> WorkoutPlan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercises>()
                .HasMany(e => e.WorkoutExercise)
                .WithRequired(e => e.Exercises)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.WorkoutPlan)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkoutPlan>()
                .HasMany(e => e.WorkoutExercise)
                .WithRequired(e => e.WorkoutPlan)
                .WillCascadeOnDelete(false);
        }
    }
}
