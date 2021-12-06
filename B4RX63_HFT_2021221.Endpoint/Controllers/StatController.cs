using B4RX63_HFT_2021221.Logic;
using B4RX63_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace B4RX63_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IDogLogic dl; //DogLogic interface
        IOwnerLogic ol;
        ICourseLogic cl;

        public StatController(IDogLogic dl, IOwnerLogic ol, ICourseLogic cl)
        {
            this.dl = dl;
            this.ol = ol;
            this.cl = cl;
        }


        // GET: stat/largestdog
        [HttpGet]
        public Dog LargestDog()
        {
            return dl.LargestDog();
        }
        [HttpGet]
        public string SmallestFemale()
        {
            return dl.SmallestFemale();
        }
        [HttpGet]
        public string MostCommonBreed()
        {
            return dl.MostCommonBreed();
        }
        [HttpGet]
        public ICollection<Owner> CastratedDogssOwners()
        {
            return dl.CastratedDogssOwners();
        }
        [HttpGet]
        public Owner OldestOwner()
        {
            return ol.OldestOwner();
        }
        [HttpGet]
        public IEnumerable<string> YoungestFemalesDogs()
        {
            return ol.YoungestFemalesDogs();
        }
        [HttpGet]
        public ICollection<string> YoungOwnersCourses()
        {
            return ol.YoungOwnersCourses();
        }
        [HttpGet]
        public ICollection<KeyValuePair<string, int>> CourseGroupNumber()
        {
            return cl.CourseGroupNumber();
        }
        [HttpGet]
        public ICollection<KeyValuePair<string, double>> CourseAverageWeight()
        {
            return cl.CourseAverageWeight();
        }

    }
}
