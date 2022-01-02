using B4RX63_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4RX63_HFT_2021221.Client
{
    public class ReadMethods
    {
        public RestService rest;

        public ReadMethods(RestService rest)
        {
            this.rest = rest;
        }

        public void ReadDog()
        {
            Console.WriteLine("Enter the dog's id:");
            int id = int.Parse(Console.ReadLine());
            try
            {
                var dog = rest.Get<Dog>(id, "dog");
                Console.WriteLine("Name: " + dog.Name);
                Console.WriteLine("Breed: " + dog.Breed);
                Console.WriteLine("Sex: " + dog.Sex);
                Console.WriteLine("Is castrated: " + dog.Castrated);
                Console.WriteLine("Weight: " + dog.Weight);
                Console.WriteLine("Height: " + dog.Height);
                Console.WriteLine("Owner's ID: " + dog.Owner.Name);
                Console.WriteLine("Course: " + dog.Course.Name);
                Console.ReadKey();
            }
            catch (NullReferenceException)
            { Console.WriteLine("There's no dog with this ID");
                Console.ReadKey();
                    }
            
        }
        public void ReadOwner()
        {
            Console.WriteLine("Enter the owner's id:");
            int id = int.Parse(Console.ReadLine());
            try
            {
                var owner = rest.Get<Owner>(id, "owner");
                Console.WriteLine("Name: " + owner.Name);
                Console.WriteLine("Age: " + owner.Age);
                Console.WriteLine("Sex: " + owner.Sex);
                Console.WriteLine("Course: " + owner.Course.Name);
                Console.ReadKey();
            }
            catch (NullReferenceException)
            { Console.WriteLine("There's no owner with this ID");
                Console.ReadKey();
            }
            
        }
        public void ReadCourse()
        {
            Console.WriteLine("Enter the course's id:");
            int id = int.Parse(Console.ReadLine());
            Course course;

            try
            {
                course = rest.Get<Course>(id, "course");
                Console.WriteLine("Name: " + course.Name);
                Console.WriteLine("Organizer: " + course.Organizer);
                Console.WriteLine("Traier: " + course.Trainer);
                Console.ReadKey();

            }
            catch (NullReferenceException)
            { Console.WriteLine("There's no course with this ID");
                Console.ReadKey();
            }
            
               
            
            
        }
        public void ReadAllDogs()
        {
            try
            {
                var result = rest.GetSingle<List<Dog>>("dog");
                Console.WriteLine("List of the dogs:");
                foreach (var d in result)
                {
                    Console.WriteLine("ID: " + d.Id + " Name: " + d.Name);

                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Something went wrong. Try again.");
                Console.ReadKey();
            }
            Console.ReadKey();
        }
        public void ReadAllOwners()
        {
            try
            {
                var result = rest.GetSingle<List<Owner>>("owner");
                Console.WriteLine("List of the owners:");
                foreach (var o in result)
                {
                    Console.WriteLine("ID: " + o.Id + " Name: " + o.Name);

                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Something went wrong. Try again.");
                Console.ReadKey();
            }
            Console.ReadKey();
        }
        public void ReadAllCourses()
        {
            try
            {
                var result = rest.GetSingle<List<Course>>("course");
                Console.WriteLine("List of the courses:");
                foreach (var c in result)
                {
                    Console.WriteLine("ID: " + c.Id + " Name: " + c.Name);

                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Something went wrong. Try again.");
                Console.ReadKey();
            }
            Console.ReadKey();
        }

    }
}

