using PracticeApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.BL.Controller
{
    public class ExerciseController : BaseController
    {
        private readonly User user;

        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can't be null!", nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime start, DateTime finish)
        {
            var act = Activities.FirstOrDefault(a => a.Name == activity.Name);

            if (act == null)
            {
                // Activity is not in the list.
                Activities.Add(activity);

                var exercise = new Exercise(start, finish, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(start, finish, act, user);
                Exercises.Add(exercise);
            }
            Save();
        }

        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }
    }
}
