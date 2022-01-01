using B4RX63_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4RX63_HFT_2021221.Client
{
    public class CreateMethods
    {
        public RestService rest;
        public CreateMethods(RestService rest)
        {
            this.rest = rest;
        }

        public void CreateDog()
        {
            Dog newDog = new Dog();

            string name = "";

            do
            {
                Console.WriteLine("Dog's name:");
                name = Console.ReadLine();
            } while (name.Length < 1);
            string breed = "";
            do
            {
                Console.WriteLine("Dog's breed:");
                breed = Console.ReadLine();
            } while (breed.Length < 1);

            int age;
            do
            {
                Console.WriteLine("Dogs's age:");
                age = int.Parse(Console.ReadLine());
            } while (age < 1); 

            string sex = "";
            Gender dog;
            do
            {
                Console.WriteLine("Dog's sex (m=male f=female): ");
                sex = Console.ReadLine();
            } while (!(sex.Equals("m")) && !(sex.Equals("f")));
            if (sex.Equals("m"))
            {
                dog = Gender.male;
            }
            else
            {
                dog = Gender.female;
            }
            int cast;
            bool castrated;
            do
            {
                Console.WriteLine("Is the dog castrated: (0=false, 1=true)");
                cast = int.Parse(Console.ReadLine());
            } while ((cast != 0) && (cast != 1));
            if (cast == 0)
            {
                castrated = false;
            }
            else
            {
                castrated = true;
            }
            double weight;
            do
            {
                Console.WriteLine("Dog's weight:");
                weight = double.Parse(Console.ReadLine());
            } while (weight < 1);
            double height;
            do
            {
                Console.WriteLine("Dog's weight:");
                height = double.Parse(Console.ReadLine());
            } while (height < 1);

            int oID;
            do
            {
                Console.WriteLine("Owner's ID:");
                oID = int.Parse(Console.ReadLine());
            } while ((rest.Get<Owner>(oID, "http://localhost:25294/owner").Equals(null)));

            int cID;
            do
            {
                Console.WriteLine("Course's ID:");
                cID = int.Parse(Console.ReadLine());
            } while ((rest.Get<Course>(cID, "http://localhost:25294/course").Equals(null))); ;

            newDog.Name = name;
            newDog.Breed = breed;
            newDog.Age = age;
            newDog.Sex = dog;
            newDog.Castrated = castrated;
            newDog.Weight = weight;
            newDog.Height = height;
            newDog.OwnerId = oID;
            newDog.CourseId = cID;

            try
            {
                rest.Post<Dog>(newDog, "http://localhost:25294/dog");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Something went wrong, please try again");
            }
            Console.WriteLine("Successful create!");
        }
        public void CreateOwner()
        {
            Owner newOwner = new Owner();

            string name = "";

            do
            {
                Console.WriteLine("Owner's name:");
                name = Console.ReadLine();
            } while (name.Length < 1);

            string sex = "";
            Gender gender;
            do
            {
                Console.WriteLine("Owner's gender (m=male f=female): ");
                sex = Console.ReadLine();
            } while (!(sex.Equals("m")) && !(sex.Equals("f")));
            if (sex.Equals("m"))
            {
                gender = Gender.male;
            }
            else
            {
                gender = Gender.female;
            }


            int age;
            do
            {
                Console.WriteLine("Owner's age:");
                age = int.Parse(Console.ReadLine());
            } while (age < 18);

            int cID;
            do
            {
                Console.WriteLine("Course's ID:");
                cID = int.Parse(Console.ReadLine());
            } while ((rest.Get<Course>(cID, "http://localhost:25294/course").Equals(null))); ;

            newOwner.Name = name;
            newOwner.Sex = gender;
            newOwner.Age = age;
            newOwner.CourseId = cID;

            try
            {
                rest.Post<Owner>(newOwner, "http://localhost:25294/owner");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Something went wrong, please try again");
            }
            Console.WriteLine("Successful create!");
        }

        public void CreateCourse()
        {
            Course newCourse = new Course();

            string name = "";

            do
            {
                Console.WriteLine("Course's name:");
                name = Console.ReadLine();
            } while (name.Length < 1);

            string organizer = "";

            do
            {
                Console.WriteLine("Course's organizer:");
                organizer = Console.ReadLine();
            } while (organizer.Length < 1);

            string trainer = "";

            do
            {
                Console.WriteLine("Course's trainer:");
                trainer = Console.ReadLine();
            } while (trainer.Length < 1);



            newCourse.Name = name;
            newCourse.Organizer = organizer;
            newCourse.Trainer = trainer;

            try
            {
                rest.Post<Course>(newCourse, "http://localhost:25294/course");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Something went wrong, please try again");
            }
            Console.WriteLine("Successful create!");
        }



    }
}
