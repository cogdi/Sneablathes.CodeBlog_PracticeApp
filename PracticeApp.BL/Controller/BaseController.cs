using System.Collections.Generic;

namespace PracticeApp.BL.Controller
{
    public abstract class BaseController
    {
        private readonly IDataSaver manager = new DataSaverDatabase();

        protected void Save<T>(List<T> item) where T: class
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}
