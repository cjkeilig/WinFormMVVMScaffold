using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using System.Drawing;

namespace Core.Repositories
{
    public class PersonManager : IPersonRepository
    {
        private List<Person> people;

        public PersonManager()
        {
            LoadPeople(10);
        }
        private void LoadPeople(int howMany)
        {
            people = new List<Person>();

            for (int x = 0; x < howMany; x++)
            {
                people.Add(new Person(x, "Name " + x, 2 * x, Color.FromArgb(x + 10, x * 10 + 10, x * 10 + 100), DateTime.Today));
            }

        }

        public IEnumerable<Person> GetPeople()
        {
            return people;
        }


    }
}
