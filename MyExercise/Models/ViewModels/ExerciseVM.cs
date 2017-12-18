using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;

namespace MyExercise.Models.ViewModels
{
    public class ExerciseVM
    {
        public ExerciseVM() { }
        public ExerciseRecord ExerciseRecord { get; set; }
        public IQueryable<ExerciseRecord> ExerciseRecords { get; set; }
        public PagedList.IPagedList<ExerciseRecord> ExePagedList { get; set; }
    }
}