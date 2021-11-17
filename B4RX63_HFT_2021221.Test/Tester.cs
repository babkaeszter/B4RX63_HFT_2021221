using B4RX63_HFT_2021221.Logic;
using B4RX63_HFT_2021221.Models;
using B4RX63_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace B4RX63_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        DogLogic dl;
        OwnerLogic ol;
        CourseLogic cl;
        [SetUp]
        public void Init()
        {
            var gazdi1 = new Owner() { Id = 1, Name = "Kiss Tamás", Sex = Gender.male, Age = 34, CourseId = 1 };
            var gazdi2 = new Owner() { Id = 2, Name = "Szabó Enikő", Sex = Gender.female, Age = 22, CourseId = 1 };
            var gazdi3 = new Owner() { Id = 3, Name = "Varga István", Sex = Gender.male, Age = 29, CourseId = 2 };
            var gazdi4 = new Owner() { Id = 4, Name = "Nagy Dóra", Sex = Gender.female, Age = 43, CourseId = 2 };

            var dog1 = new Dog() { Id = 1, Name = "Buksi", Breed = "Német juhászkutya", Sex = Gender.male, Castrated = true, Weight = 13.4, Height = 42, OwnerId = 1, CourseId = 1 };
            var dog2 = new Dog() { Id = 2, Name = "Poppy", Breed = "Dalmata", Sex = Gender.female, Castrated = false, Weight = 20.3, Height = 56, OwnerId = 2, CourseId = 1 };
            var dog3 = new Dog() { Id = 3, Name = "Athos", Breed = "Német juhászkutya", Sex = Gender.male, Castrated = false, Weight = 39, Height = 62.5, OwnerId = 3, CourseId = 2 };
            var dog4 = new Dog() { Id = 4, Name = "Picúr", Breed = "Yorkshire terrier", Sex = Gender.female, Castrated = true, Weight = 2.8, Height = 20, OwnerId = 4, CourseId = 2 };

            var course1 = new Course { Id = 1, Name = "Alapozó tanfolyam", Organizer = "Fővárosi Kutyások Egyesülete", Trainer = "Szűcs Zoltán" };
            var course2 = new Course { Id = 2, Name = "Haladó tanfolyam", Organizer = "Kutyás Élet Kutyaiskola", Trainer = "Lengyel Pálné" };

            course1.ParticipantOwners = new List<Owner> { gazdi1, gazdi2 };
            course2.ParticipantOwners = new List<Owner> { gazdi3, gazdi4 };
            course1.ParticipantDogs = new List<Dog> { dog1, dog2 };
            course2.ParticipantDogs = new List<Dog> { dog3, dog4 };
            gazdi1.Dogs.Add(dog1);
            gazdi1.Course = course1;
            dog1.Owner = gazdi1;
            dog1.Course = course1;
            gazdi2.Dogs.Add(dog2);
            gazdi2.Course = course1;
            dog2.Owner = gazdi2;
            dog2.Course = course1;
            gazdi3.Dogs.Add(dog3);
            gazdi3.Course = course2;
            dog3.Owner = gazdi3;
            dog3.Course = course2;
            gazdi4.Dogs.Add(dog4);
            gazdi4.Course = course2;
            dog4.Owner = gazdi4;
            dog4.Course = course2;

            var dogs = new List<Dog> { dog1, dog2, dog3, dog4 }.AsQueryable();
            var owners = new List<Owner> { gazdi1, gazdi2, gazdi3, gazdi4 }.AsQueryable();
            var courses = new List<Course> { course1, course2 }.AsQueryable();

            var mockDogRepo = new Mock<IDogRepository>();
            var mockOwnerRepo = new Mock<IOwnerRepository>();
            var mockCourseRepo = new Mock<ICourseRepository>();
            mockDogRepo.Setup((d) => d.ReadAll()).Returns(dogs);
            mockOwnerRepo.Setup((o) => o.ReadAll()).Returns(owners);
            mockCourseRepo.Setup((c) => c.ReadAll()).Returns(courses);

            dl = new DogLogic(mockDogRepo.Object);
            ol = new OwnerLogic(mockOwnerRepo.Object);
            cl = new CourseLogic(mockCourseRepo.Object);
        }
        [Test]
        public void CreateDogTest()
        {
            var testdog = new Dog() { Id = 5, Name = "Baba", Breed = "Border collie", Sex = Gender.female, Castrated = false, Weight = -16.7, Height = 0, OwnerId = 5, CourseId = 1 };
            Assert.That(() => dl.Create(testdog), Throws.Exception);
        }

        [Test]
        public void LargestTest()
        {
            var result = dl.LargestDog();
            Assert.That(result.Name, Is.EqualTo("Athos"));
        }
        [Test]
        public void SmallestFemaleTest()
        {
            var result = dl.SmallestFemale();
            Assert.That(result, Is.EqualTo("Yorkshire terrier"));
        }
        [Test]
        public void MostCommonBreedTest()
        {
            var result = dl.MostCommonBreed();
            Assert.That(result, Is.EqualTo("Német juhászkutya"));
        }
        [Test]
        public void CastratedDogsOwnersTest()
        {
            var result = dl.CastratedDogssOwners();
            Assert.That(result.First().Name, Is.EqualTo("Kiss Tamás"));
        }
        [Test]
        public void OldestOwnerTest()
        {
            var result = ol.OldestOwner();
            Assert.That(result.Name, Is.EqualTo("Nagy Dóra"));
        }
        [Test]
        public void YoungestFemalesDogsTest()
        {
            var result = ol.YoungestFemalesDogs();
            Assert.That(result.First(), Is.EqualTo("Picúr"));
        }
        [Test]
        public void YoungOwnersCoursesTest()
        {
            var result = ol.YoungOwnersCourses();
            Assert.That(result.First(), Is.EqualTo("Alapozó tanfolyam"));
        }
        [Test]
        public void CourseGroupNumber()
        {
            var result = cl.CourseGroupNumber();
            Assert.That(result.First(), Is.EqualTo(new KeyValuePair<string, double>("Alapozó tanfolyam", 2)));
        }
        [Test]
        public void CourseAverageWeight()
        {
            var result = cl.CourseAverageWeight();
            Assert.That(result.First(), Is.EqualTo(new KeyValuePair<string, double>("Alapozó tanfolyam", 16.85)));
        }

    }
}
