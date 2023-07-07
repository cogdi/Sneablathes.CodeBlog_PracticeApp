using PracticeApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace PracticeApp.BL.Controller
{
    public class EatingController : BaseController
    {
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }


        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can't be null!", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);

            if (product == null)
            {
                // Creating a new product.
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }

            else
            {
                // The product already exists.
                Eating.Add(product, weight);
            }
        }
        private Eating GetEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }

        private void Save()
        {
            Save(Foods);
            Save(new List<Eating>() { Eating });
        }
    }
}
