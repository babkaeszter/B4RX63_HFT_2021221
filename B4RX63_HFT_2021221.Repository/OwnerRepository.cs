using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B4RX63_HFT_2021221.Data;
using B4RX63_HFT_2021221.Models;

namespace B4RX63_HFT_2021221.Repository
{
    //Adatbázissal dolgozó osztály
    public class OwnerRepository : IOwnerRepository
    {


        DogSchoolDBContext db;
        public OwnerRepository(DogSchoolDBContext db)
        {
            this.db = db;
        }
        public void Create(Owner owner)
        {
            db.Owners.Add(owner);
            db.SaveChanges();
        }
        public Owner Read(int id)
        {
            return db.Owners.FirstOrDefault(o => o.Id == id);
        }
        public IQueryable<Owner> ReadAll()
        {
            return db.Owners;
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
        public void Update(Owner owner)
        {
            var oldowner = Read(owner.Id);
            oldowner.Name = owner.Name;
            oldowner.Age = owner.Age;
            oldowner.Name = owner.Name;
            oldowner.Dogs = owner.Dogs;
            oldowner.CourseId = owner.CourseId;
            db.SaveChanges();
        }
    }
}
