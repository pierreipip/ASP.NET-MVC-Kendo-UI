using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyExercise.Models
{
    public class ExerciseRecord
    {
        [Key]
        public long Id { get; set; }
        [Required, MaxLength(100)]
        [Display(Name = "Exercise Name")]
        public string ExerciseName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Exercise Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ExerciseDate { get; set; }
        [Required]
        [Range(1, 120)]
        [Display(Name = "Duration In Minutes")]
        public int DurationInMinutes { get; set; }
        public DateTime CreationDate { get; set; }
    }
}