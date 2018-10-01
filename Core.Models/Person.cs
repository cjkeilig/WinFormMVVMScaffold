using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Person
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }

        public Int32 Age { get; set; }

        public Color Color { get; set; }

        public DateTime Birthday { get; set; }

        public Person(Int32 Id, String Name, Int32 Age, Color c, DateTime Birthday)
        {
            this.Id = Id;
            this.Name = Name;
            this.Age = Age;
            this.Color = c;
            this.Birthday = Birthday;
        }
    }
}
