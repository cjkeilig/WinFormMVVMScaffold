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
            LoadPeople(20);
        }
        private void LoadPeople(int howMany)
        {
            people = new List<Person>();

            for (int x = 0; x < howMany; x++)
            {
                people.Add(new Person(x, "Name " + x, 2 * x, Color.FromArgb(200,100,200), DateTime.Today));
            }

        }

        public IEnumerable<Person> GetPeople()
        {
            return people;
        }


    }
}
