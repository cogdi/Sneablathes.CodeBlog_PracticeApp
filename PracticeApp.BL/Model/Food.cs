using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.BL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Proteins.
        /// </summary>
        public double Proteins { get; set; }
        
        /// <summary>
        /// Fats.
        /// </summary>
        public double Fats { get; set; }
        
        /// <summary>
        /// Carbohydrates.
        /// </summary>
        public double Carbs { get; set; }
        
        /// <summary>
        /// Calories.
        /// </summary>
        public double Calories { get; set; }

        private double ProteinsPerOneGram { get { return Proteins / 100.0; } }
        private double FatsPerOneGram { get { return Fats / 100.0; } }
        private double CarbsPerOneGram { get { return Carbs / 100.0; } }
        private double CaloriesPerOneGram { get { return Calories / 100.0; } }

        public Food() { }

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double proteins, double fats, double carbs, double calories)
        {
            // TODO: Null Checking.
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbs = carbs / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
