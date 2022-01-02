using B4RX63_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4RX63_HFT_2021221.Client
{
    public class DeleteMethods
    {
        public RestService rest;

        public DeleteMethods(RestService rest)
        {
            this.rest = rest;
        }

        public void DeleteDog()
        {
            Console.WriteLine("Enter the dog's id: ");
            int id = int.Parse(Console.ReadLine());
            if (rest.Get<Dog>(id, "dog").Equals(null))
            { throw new ArgumentException("ID not found"); }
            else
            {
                char answer;
                do
                {
                    Console.WriteLine("Are you sure, delete dog with id " + id + " ? (y/n)");
                    answer = char.Parse(Console.ReadLine());
                } while (!(answer.Equals('y')) && !(answer.Equals('n')));
                if (answer.Equals("y"))
                {
                    rest.Delete(id, "dog");
                }
            }

        }
        public void DeleteOwner()
        {
            Console.WriteLine("Enter the owner's id: ");
            int id = int.Parse(Console.ReadLine());
            if (rest.Get<Owner>(id, "owner").Equals(null))
            { throw new ArgumentException("ID not found"); }
            else
            {
                char answer;
                do
                {
                    Console.WriteLine("Are you sure, delete owner with id " + id + " ? (y/n)");
                    answer = char.Parse(Console.ReadLine());
                } while (!(answer.Equals('y')) && !(answer.Equals('n')));
                if (answer.Equals("y"))
                {
                    rest.Delete(id, "owner");
                }
            }

        }
        public void DeleteCourse()
        {
            Console.WriteLine("Enter the course's id: ");
            int id = int.Parse(Console.ReadLine());
            if (rest.Get<Course>(id, "course").Equals(null))
            { throw new ArgumentException("ID not found"); }
            else
            {
                char answer;
                do
                {
                    Console.WriteLine("Are you sure, delete course with id " + id + " ? (y/n)");
                    answer = char.Parse(Console.ReadLine());
                } while (!(answer.Equals('y')) && !(answer.Equals('n')));
                if (answer.Equals("y"))
                {
                    rest.Delete(id, "course");
                }
            }

        }
    }
}

