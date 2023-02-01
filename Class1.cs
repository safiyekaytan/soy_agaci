using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WinFormsApp7
{
    public class Person
    {
        String name;
        String surname;
        String olderSurname;
        String mom;
        String dad;
        String spouse;
        String gender;
        String blood;
        String dateOfBirth;
        String job;
        String martial;
        String Id;
        String esId;

        

        // Person es;
        public List<Person> children = new List<Person>();
        public Person partner;
        public Person(string id, string name, string surname, string dateOfBirth, string spouse, string esId, string mom, string dad, string blood, string job, string martial, string olderSurname, string gender)
        {
            this.Name = name;
            this.Surname = surname;
            this.OlderSurname = olderSurname;
            this.Mom = mom;
            this.Dad = dad;
            this.Spouse = spouse;
            this.Gender = gender;
            this.Blood = blood;
            this.DateOfBirth = dateOfBirth;
            this.Job = job;
            this.Id = id;
            this.esId = esId;
            this.martial = martial;
            
            if(spouse != "")
            {
                partner = new Person("", spouse, "", "", "", "", "", "", "", "", "", "", "");
                if (gender != "Erkek")
                    partner.Gender = "Kadın";
                else
                    partner.Gender = "Erkek";
            }
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string OlderSurname { get => olderSurname; set => olderSurname = value; }
        public string Mom { get => mom; set => mom = value; }
        public string Dad { get => dad; set => dad = value; }
        public string Spouse { get => spouse; set => spouse = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Blood { get => blood; set => blood = value; }
        public string DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Job { get => job; set => job = value; }
        public string Martial { get => martial; set => martial = value; }
        public string Id1 { get => Id; set => Id = value; }
        public string EsId { get => esId; set => esId = value; }


        public void ToPlace(Person person)
        {
            if (person.spouse.Contains(name))
            {
                partner = null;
                partner = person;
            }
            else if (person.dad == name || person.mom == name)
            {
                if (children.Contains(person) == false)
                    children.Add(person);
            }
            else
            {
                foreach (Person child in children)
                {
                    child.ToPlace(person);
                }
            }

        }

        public void ToPlaceNew(Person person)
        {

            if (person.spouse.Contains(name))
            {
                partner = null;
                partner = person;
            }
            else
            {
                foreach (Person child in children)
                {
                    child.ToPlaceNew(person);
                }
            }
        }

        public int Yas()
        {
            int yas;
            String[] yasArray = dateOfBirth.Split("/");
            yas = 2022 - Convert.ToInt32(yasArray[2]);

            return yas; 
        }
        
    }
}
