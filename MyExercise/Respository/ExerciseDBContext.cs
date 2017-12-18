using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MyExercise.Models;

namespace MyExercise.Repository
{
    public class ExerciseDBContext : DbContext
    {
        public ExerciseDBContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<ExerciseRecord> ExerciseRecord { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

    }
}