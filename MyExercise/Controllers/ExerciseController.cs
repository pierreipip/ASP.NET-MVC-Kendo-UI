using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyExercise.Models;
using MyExercise.Models.ViewModels;
using MyExercise.Repository;
using PagedList;


namespace MyExercise.Controllers
{
    public class ExerciseController : Controller
    {

        private IExerciseRepository<ExerciseRecord> exeRepository = null;
        //public ExerciseController()
        //{
        //    this.exeRepository = new ExerciseRepository<ExerciseRecord>();
        //}
        // dependency injection
        public ExerciseController(ExerciseRepository<ExerciseRecord> exeRepository)
        {
            this.exeRepository = exeRepository;
        }

        // GET: Exercise
        public ActionResult Index(string thisFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = thisFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var exercises = from emp in exeRepository.GetAllData()
                            select emp;
            // IQueryable query = from x in appEntities
            //var sql = ((System.Data.Objects.ObjectQuery)exercises).ToTraceString();
            //var sql = ((System.Data.Entity.Core.Objects.ObjectQuery)exercises).ToTraceString();
            //Console.WriteLine(">>>> show sql " + sql);
            //var exercises = exeRepository.GetAllData().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                exercises = exercises.Where(emp => emp.ExerciseName.ToUpper().Contains(searchString.ToUpper()));
            }

            exercises = exercises.OrderByDescending(x => x.CreationDate);
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var exePagedList = exercises.ToPagedList(pageNumber, pageSize);
            var exercisesVM = new ExerciseVM();
            exercisesVM.ExePagedList = exePagedList;
            return View(exercisesVM);
        }

        [HttpPost]
        [HandleError]
        public ActionResult Index(ExerciseRecord exerciseRecord, string thisFilter, string searchString, int? page)
        {
            try
            {
                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = thisFilter;
                }

                ViewBag.CurrentFilter = searchString;
                var exercises = from emp in exeRepository.GetAllData()
                                select emp;
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(exerciseRecord.ExerciseName))
                    {
                        ModelState.AddModelError("", "Name is required");
                    }
                    if (exerciseRecord.ExerciseDate == DateTime.MinValue)
                    {
                        ModelState.AddModelError("", "Exercise Date is invalid");
                    }
                    if (exerciseRecord.DurationInMinutes < 1 || exerciseRecord.DurationInMinutes > 120)
                    {
                        ModelState.AddModelError("", "Duration In Minutes is out of the range (1-120)");
                    }

                    ExerciseRecord exerciseFound = exercises.FirstOrDefault(x => x.ExerciseName == exerciseRecord.ExerciseName
                                                                              && x.CreationDate == DateTime.Today);
                    if (exerciseFound == null)
                    {
                        exerciseRecord.CreationDate = DateTime.Now;
                        exeRepository.InsertRecord(exerciseRecord);
                        exeRepository.SaveRecord();
                        ViewBag.Message = "Sucess";
                        ModelState.Clear();
                        return Json(new { result = "OK" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Fail: " + exerciseRecord.ExerciseName + " is already in the system today.");
                    }
                }
                //Response.StatusCode = 400;
                exercises = exercises.OrderByDescending(x => x.CreationDate);
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                
                var exePagedList = exercises.ToPagedList(pageNumber, pageSize);
                var exercisesVM = new ExerciseVM();
                exercisesVM.ExePagedList = exePagedList;
                exercisesVM.ExerciseRecord = exerciseRecord;
                return PartialView("~/Views/Exercise/_CreateExe.cshtml", exercisesVM);
            } catch (Exception ex) {
                throw ex;
            }
        }


    }
}
