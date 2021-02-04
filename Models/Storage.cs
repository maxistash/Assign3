using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assign3.Models
{
    public class Storage
    {
        private static List<MovieForm> mForm = new List<MovieForm>();

        public static IEnumerable<MovieForm> mForms => mForm;

        public static void addForm(MovieForm newForm)
        {
            mForm.Add(newForm);
        }
    }
}
