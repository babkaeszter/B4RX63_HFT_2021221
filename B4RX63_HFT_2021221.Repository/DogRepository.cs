using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B4RX63_HFT_2021221.Data;
using B4RX63_HFT_2021221.Models;

namespace B4RX63_HFT_2021221.Repository
{
    public class DogRepository : IDogRepository
    {
        DogSchoolDBContext db;
        public DogRepository(DogSchoolDBContext db)
        {
            this.db = db;
        }
        public void Create(Dog dog)
        {
            db.Dogs.Add(dog);
            db.SaveChanges();
        }
        public Dog Read(int id)
        {
            return db.Dogs.FirstOrDefault(d => d.Id == id);
        }
        public IQueryable<Dog> ReadAll()
        {
            return db.Dogs;
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
        public void Update(Dog dog)
        {
            var olddog = Read(dog.Id);
            olddog.Name = dog.Name;
            olddog.Breed = dog.Breed;
            olddog.Castrated = dog.Castrated;
            olddog.Weight = dog.Weight;
            olddog.Height = dog.Height;
            olddog.CourseId = dog.CourseId;
            olddog.OwnerId = dog.OwnerId;
            db.SaveChanges();
        }
    }
}
