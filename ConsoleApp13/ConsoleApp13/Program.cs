using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class People
    {
        private static int number = 0;
        private int id;
        private string _firstName;
        private string _lastName;

        public string _FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string this[string propname]
        {
            get
            {
                switch (propname)
                {
                    case "FirstName": return _firstName;
                    case "LastName": return _lastName;
                    default: return null;
                }
            }
            set
            {
                switch (propname)
                {
                    case "FirstName":
                        _firstName = value;
                        break;
                    case "LastName":
                        _lastName = value;
                        break;

                }
            }
        }

        public string _LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public People(string FirstName, string LastName)
        {
            number++;
            id = number;
            _firstName = FirstName;
            _lastName = LastName;
        }

        public virtual void Print()
        {
            Console.Write(id.ToString() + " " + _FirstName + " " + _LastName);
        }

        public void SetPeople(string FirstName, string LastName)
        {
            _FirstName=FirstName;
            _LastName=LastName;
        }
        public void SetPeople(string FirstName)
        {
            _FirstName = FirstName;
        }
    }
    class Sportsman : People
    {
        private string _nameSport;

        public virtual string _NameSport
        {
            get
            {
                return _nameSport;
            }
            set
            {
                _nameSport = value;
            }
        }

        public Sportsman(string FirstName, string LastName, string NameSport) : base(FirstName, LastName)
        {
            _nameSport = NameSport;
        }

        public override  void Print()
        {
            base.Print();
            Console.Write(" " + _NameSport);
        }

        public void SetPeople(string FirstName, string LastName, string NameSport)
        {
            SetPeople(FirstName, LastName);
            _nameSport = NameSport;
        }
    }
    class SpecialistsInSelectedSports : Sportsman
    {
        private string _nameSelectedSports;

        public SpecialistsInSelectedSports(string FirstName, string LastName, string NameSport, string NameSelectedSports)
            : base(FirstName, LastName, NameSport)
        {
            _nameSelectedSports = NameSelectedSports;
        }

        public virtual string _NameSelectedSports
        {
            get
            {
                return _nameSelectedSports;
            }
            set
            {
                _nameSelectedSports = value;
            }
        }

        public override void Print()
        {
            base.Print();
            Console.Write(" " + _NameSelectedSports);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<People> peoples = new List<People>();
            peoples.Add(new People("Артем", "Ермаков"));
            peoples.Add(new People("Виктория", "Панченко"));
            peoples.Add(new Sportsman("Мария", "Кухарева", "Теннис"));
            peoples.Add(new SpecialistsInSelectedSports("Константин", "Тишкевич", "Футбол", "Игровые"));     
            foreach(People p in peoples)
            {
                p.Print();
                Console.WriteLine();
            }
            peoples[2].SetPeople("Тиханов");
            peoples[2].Print();
            Console.WriteLine();
            peoples[2].SetPeople("Петренко", "Евгений");
            peoples[2].Print();
            Console.ReadKey();
        }
    }
}
