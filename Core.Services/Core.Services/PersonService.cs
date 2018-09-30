using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using System.Drawing;

namespace Core.Services
{
    public class PersonService : IPersonService
    {
        public IEnumerable<Person> GetPeople(int howMany)
        {
            List<Person> peopleToGet = new List<Person>();

            for (int x = 0; x < howMany; x++)
            {
                peopleToGet.Add(new Person(x, "Name " + x, 2 * x, Color.FromArgb(x + 10, x * 10 + 10, x * 10 + 100)));
            }

            return peopleToGet;

        }
    }
}
