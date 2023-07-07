using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.BL.Model
{
    /// <summary>
    /// Eating.
    /// </summary>
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
        public Dictionary<Food, double> Foods { get; set; }
        public DateTime LastMealTime { get; set; }

        public Eating() { }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("User can't be null!", nameof(user));
            LastMealTime = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name == food.Name);

            if (product == null)
            {
                // Creating a new product.
                Foods.Add(food, weight);
            }

            else
            {
                // The product already exists. 
                Foods[product] += weight;
            }
        }
    }
}
