using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            this.PersonsList = new List<Person>();
        }

        private List<Person> presonsList;

        public List<Person> PersonsList
        {
            get { return presonsList; }
            set { presonsList = value; }
        }


        public void AddMember(Person memmber)
        {
            presonsList.Add(memmber);
        }

        public List<Person> GetOldestMember()
        {
            int oldestValue = 30; //PersonsList.Max(p => p.Age);
            List<Person> oldestPersons = PersonsList.FindAll(x => x.Age > oldestValue);
            
           return oldestPersons;
        }

    }
}
