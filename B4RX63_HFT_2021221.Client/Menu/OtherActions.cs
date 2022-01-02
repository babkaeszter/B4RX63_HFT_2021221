using B4RX63_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4RX63_HFT_2021221.Client
{
    public class OtherActions
    {
       
            public RestService rest;

            public OtherActions(RestService rest)
            {
                this.rest = rest;
            }

            public void LargestDog()
            {
                try
                {
                    var dog = rest.GetSingle<Dog>("stat/LargestDog");
                    Console.WriteLine("The largest dog:");
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
                {
                    Console.WriteLine("Something went wrong. Try again.");
                    Console.ReadKey();
                }
            }
            public void SmallestFemale()
            {
                try
                {
                    var result = rest.GetSingle<string>("stat/smallestfemale");
                    Console.WriteLine("The smallest female dog's breed: " + result);
                    Console.ReadKey();
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Something went wrong. Try again.");
                    Console.ReadKey();
                }
            }
            public void MostCommonBreed()
            {
                try
                {
                    var result = rest.GetSingle<string>("stat/mostcommonbreed");
                    Console.WriteLine("The most common breed: " + result);
                    Console.ReadKey();
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Something went wrong. Try again.");
                    Console.ReadKey();
                }
            }
            public void CastratedDogssOwners()
            {
                try
                {
                    var result = rest.GetSingle<ICollection<Owner>>("stat/CastratedDogssOwners");
                    Console.WriteLine("The castrated dog's owners:");
                    foreach (var o in result)
                    {

                        Console.WriteLine(o.Name);
                    }

                    Console.ReadKey();

                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Something went wrong. Try again.");
                    Console.ReadKey();
                }

            }
            public void OldestOwner()
            {
                try
                {
                    var result = rest.GetSingle<Owner>("stat/oldestowner");
                    Console.WriteLine("The oldest owner:");
                    Console.WriteLine("Name: " + result.Name);
                    Console.WriteLine("Age: " + result.Age);
                    Console.WriteLine("Sex: " + result.Sex);
                    Console.WriteLine("Course: " + result.Course.Name);
                    Console.ReadKey();
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Something went wrong. Try again.");
                    Console.ReadKey();
                }
            }
            public void YoungestFemalesDogs()
            {
                try
                {
                    var result = rest.GetSingle<IEnumerable<string>>("stat/YoungestFemalesDogs");
                    Console.WriteLine("The youngest female owner's dogs:");
                    foreach (var o in result)
                    {

                        Console.WriteLine(o);
                    }

                    Console.ReadKey();

                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Something went wrong. Try again.");
                    Console.ReadKey();
                }



            }
            public void YoungOwnersCourses()
            {
                try
                {
                    var result = rest.GetSingle<ICollection<string>>("stat/YoungOwnersCourses");
                    Console.WriteLine("The young owner's courses:");
                    foreach (var o in result)
                    {

                        Console.WriteLine(o);
                    }

                    Console.ReadKey();

                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Something went wrong. Try again.");
                    Console.ReadKey();
                }



            }
            public void CourseGroupNumber()
            {
                try
                {
                    var result = rest.GetSingle<ICollection<KeyValuePair<string, int>>>("stat/CourseGroupNumber");
                    Console.WriteLine("The group number in courses:");
                    foreach (var o in result)
                    {

                        Console.WriteLine(o);
                    }

                    Console.ReadKey();

                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Something went wrong. Try again.");
                    Console.ReadKey();
                }



            }
            public void CourseAverageWeight()
            {
                try
                {
                    var result = rest.GetSingle<ICollection<KeyValuePair<string, double>>>("stat/CourseAverageWeight");
                    Console.WriteLine("The average dog weight in courses:");
                    foreach (var o in result)
                    {

                        Console.WriteLine(o);
                    }

                    Console.ReadKey();

                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Something went wrong. Try again.");
                    Console.ReadKey();
                }



            }
        }
    }


