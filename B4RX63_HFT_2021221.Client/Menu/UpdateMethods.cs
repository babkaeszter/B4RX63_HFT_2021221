using B4RX63_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4RX63_HFT_2021221.Client
{
    public class UpdateMethods
    {
        public RestService rest;
        public UpdateMethods(RestService rest)
        {
            this.rest = rest;
        }

        public void UpdateDog()
        {
            Console.WriteLine("Enter the dog's ID:");
            int id = int.Parse(Console.ReadLine());

            if ((rest.Get<Dog>(id, "http://localhost:25294/dog").Equals(null)))
            {
                throw new ArgumentException("ID not found");
            }
            else
            {
                Dog updatedDog = new Dog();



                string name = "";

                do
                {
                    Console.WriteLine("Dog's new name:");
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
                    Console.WriteLine("Dogs's new age:");
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
                    Console.WriteLine("Dog's new weight:");
                    weight = double.Parse(Console.ReadLine());
                } while (weight < 1);
                double height;
                do
                {
                    Console.WriteLine("Dog's new height:");
                    height = double.Parse(Console.ReadLine());
                } while (height < 1);

                int oID;
                do
                {
                    Console.WriteLine("New Owner's ID:");
                    oID = int.Parse(Console.ReadLine());
                } while ((rest.Get<Owner>(oID, "http://localhost:25294/owner").Equals(null)));

                int cID;
                do
                {
                    Console.WriteLine("New Course's ID:");
                    cID = int.Parse(Console.ReadLine());
                } while ((rest.Get<Course>(cID, "http://localhost:25294/course").Equals(null))); ;
                updatedDog.Id = id;
                updatedDog.Name = name;
                updatedDog.Breed = breed;
                updatedDog.Age = age;
                updatedDog.Sex = dog;
                updatedDog.Castrated = castrated;
                updatedDog.Weight = weight;
                updatedDog.Height = height;
                updatedDog.OwnerId = oID;
                updatedDog.CourseId = cID;

                try
                {
                    rest.Put<Dog>(updatedDog, "http://localhost:25294/dog");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Something went wrong, please try again");
                }
                Console.WriteLine("Successful update!");
            }
        }
        public void UpdateOwner()
        {
            Console.WriteLine("Enter the owner's ID:");
            int id = int.Parse(Console.ReadLine());

            if ((rest.Get<Dog>(id, "http://localhost:25294/owner").Equals(null)))
            {
                throw new ArgumentException("ID not found");
            }
            else
            {
                Owner updatedOwner = new Owner();

                string name = "";

                do
                {
                    Console.WriteLine("Owner's new name:");
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
                    Console.WriteLine("Owner's new age:");
                    age = int.Parse(Console.ReadLine());
                } while (age < 18);

                int cID;
                do
                {
                    Console.WriteLine("Course's new ID:");
                    cID = int.Parse(Console.ReadLine());
                } while ((rest.Get<Course>(cID, "http://localhost:25294/course").Equals(null))); ;
                updatedOwner.Id = id;
                updatedOwner.Name = name;
                updatedOwner.Sex = gender;
                updatedOwner.Age = age;
                updatedOwner.CourseId = cID;

                try
                {
                    rest.Put<Owner>(updatedOwner, "http://localhost:25294/owner");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Something went wrong, please try again");
                }
                Console.WriteLine("Successful update!");
            }
        }

        public void UpdateCourse()
        {
            Console.WriteLine("Enter the course's ID:");
            int id = int.Parse(Console.ReadLine());

            if ((rest.Get<Dog>(id, "http://localhost:25294/course").Equals(null)))
            {
                throw new ArgumentException("ID not found");
            }
            else
            {
                Course updatedCourse = new Course();

                string name = "";

                do
                {
                    Console.WriteLine("Course's new name:");
                    name = Console.ReadLine();
                } while (name.Length < 1);

                string organizer = "";

                do
                {
                    Console.WriteLine("Course's new organizer:");
                    organizer = Console.ReadLine();
                } while (organizer.Length < 1);

                string trainer = "";

                do
                {
                    Console.WriteLine("Course's new trainer:");
                    trainer = Console.ReadLine();
                } while (trainer.Length < 1);


                updatedCourse.Id = id;
                updatedCourse.Name = name;
                updatedCourse.Organizer = organizer;
                updatedCourse.Trainer = trainer;

                try
                {
                    rest.Put<Course>(updatedCourse, "http://localhost:25294/course");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Something went wrong, please try again");
                }
                Console.WriteLine("Successful update!");
            }
        }
    }
}
