using PracticeApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.BL.Controller
{
    /// <summary>
    /// User's controller.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// User of the app.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Creating a new controller of the user.
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController (string userName, string genderName, DateTime dateOfBirth, double weight, double height)
        {
            // TODO: Checking

            var gender = new Gender(genderName);
            User = new User(userName, gender, dateOfBirth, weight, height);
        }

        /// <summary>
        /// Get user's data.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException"></exception>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

            // TODO: What to do if we couldn't read the user?
        }

        /// <summary>
        /// Save user's data.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
    }
}
