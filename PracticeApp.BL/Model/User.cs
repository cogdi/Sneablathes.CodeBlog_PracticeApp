using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.BL.Model
{
    [Serializable]
    public class User
    {
        #region Properties.
        public int Id { get; set; }

        /// <summary>
        /// User's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User's gender.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// User's date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        
        /// <summary>
        /// User's weight.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// User's height.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// User's age.
        /// </summary>
        public int Age { get { return DateTime.Now.Year - DateOfBirth.Year; } }

        #endregion

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="dateOfBirth">Date of birth.</param>
        /// <param name="weight">Weight.</param>
        /// <param name="height">Height.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User (string name, 
                     Gender gender, 
                     DateTime dateOfBirth, 
                     double weight, 
                     double height)
        {
            #region Null Checking.
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can't be equal to null.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Gender can't be equal to null.", nameof(gender));
            }

            if (dateOfBirth <= DateTime.Parse("01.01.1900") || dateOfBirth > DateTime.Now)
            {
                throw new ArgumentException("Not valid date of birth.", nameof(dateOfBirth));
            }

            if (weight <= 0)
            {
                throw new ArgumentNullException("Weight can't be equal or less than 0.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentNullException("Height can't be equal or less than 0.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Weight = weight;
            Height = height;
        }

        public User() { }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can't be equal to null.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
