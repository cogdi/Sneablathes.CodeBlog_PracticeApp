using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.BL.Model
{
    /// <summary>
    /// Gender.
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Gender's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Create a new gender.
        /// </summary>
        /// <param name="name">Gender's name.</param>
        /// <exception cref="ArgumentNullException">Thrown when Name equals to null.</exception>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User's name can't be null", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return "Name: " + Name;
        }
    }
}
