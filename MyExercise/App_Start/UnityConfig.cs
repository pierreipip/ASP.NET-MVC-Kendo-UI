using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using MyExercise.Repository;
using MyExercise.Models;

namespace MyExercise
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            // dependency injection added
            container.RegisterType<IExerciseRepository<ExerciseRecord>, ExerciseRepository<ExerciseRecord>>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}