using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B4RX63_HFT_2021221.Repository;
using B4RX63_HFT_2021221.Models;

namespace B4RX63_HFT_2021221.Logic
{
    //Az OwnerRepository-t elérő osztály
    public class OwnerLogic : IOwnerLogic
    {

        IOwnerRepository ownerRepo;

        public OwnerLogic(IOwnerRepository ownerRepo)
        {
            this.ownerRepo = ownerRepo;
        }

        public void Create(Owner owner)
        {

            ownerRepo.Create(owner);
        }
        public Owner Read(int id)
        {
            return ownerRepo.Read(id);
        }
        public IEnumerable<Owner> ReadAll()
        {
            return ownerRepo.ReadAll();
        }
        public void Delete(int id)
        {
            ownerRepo.Delete(id);
        }
        public void Update(Owner owner)
        {
            ownerRepo.Update(owner);
        }
        //Non-cruds
        //legidősebb gazdi
        public Owner OldestOwner()
        {
            var oldest = ownerRepo.ReadAll().OrderByDescending(o => o.Age).Select(o => o).FirstOrDefault();
            return oldest;
        }
        //legfiatalabb női gazdi kutyái
        public IEnumerable<string> YoungestFemalesDogs()
        {
            var list = ownerRepo.ReadAll().Where(o => o.Sex == Gender.female).OrderByDescending(o => o.Age).Select(l => l.Dogs);
            return list.FirstOrDefault().Select(d => d.Name).ToList<string>();
        }
        // 30 évnél fiatalabb gazdik kurzusainak neve
        public ICollection<string> YoungOwnersCourses()
        {
            var courses = ownerRepo.ReadAll().Where(o => o.Age < 25).Select(c => c.Course.Name).ToList<string>();
            return courses;
        }
    }
    }
