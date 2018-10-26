using System;

namespace UnitTests.NUnit.HolisticWare.Core
{
    public class Person
    {
        public Person()
        {
        }

        public string NameFirst
        {
            get;
            set;
        }

        public string NameLast
        {
            get;
            set;
        }

        public DateTime DateOfBirth
        {
            get;
            set;
        }

        public TimeSpan Age
        {
            get
            {
                return DateTime.Now - DateOfBirth;
            }
        }
    }
}
