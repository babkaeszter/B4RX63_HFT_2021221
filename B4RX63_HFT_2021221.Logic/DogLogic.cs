using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B4RX63_HFT_2021221.Repository;
using B4RX63_HFT_2021221.Models;

namespace B4RX63_HFT_2021221.Logic
{
    public class DogLogic : IDogLogic
    {
        IDogRepository dogRepo;

        public DogLogic(IDogRepository dogrepo)
        {
            this.dogRepo = dogrepo;
        }

        public void Create(Dog dog)
        {

            dogRepo.Create(dog);
        }
        public Dog Read(int id)
        {
            return dogRepo.Read(id);
        }
        public IEnumerable<Dog> ReadAll()
        {
            return dogRepo.ReadAll();
        }
        public void Delete(int id)
        {
            dogRepo.Delete(id);
        }
        public void Update(Dog dog)
        {
            dogRepo.Update(dog);
        }
        //Non-cruds
        //legnagyobb kutya
        public Dog LargestDog()
        {
            var largest = dogRepo.ReadAll().OrderByDescending(d => d.Weight).Select(d => d.Id).Take(1);
            return dogRepo.Read(largest.FirstOrDefault());
        }
        //legkisebb szuka kutya fajtája
        public string SmallestFemale()
        {
            var sfd = dogRepo.ReadAll().Where(d => d.Sex == Gender.female).OrderBy(d => d.Height).Select(d => d.Id).Take(1);
            return dogRepo.Read(sfd.First()).Breed;
        }
        //leggyakoribb kutyafajta
        public string MostCommonBreed()
        {
            var breed = dogRepo.ReadAll().GroupBy(b => b.Breed).OrderByDescending(b => b.Count()).Select(b => b.Key).FirstOrDefault();

            return breed;
        }
        // Ivartalanított kutyák gazdái
        public ICollection<Owner> CastratedDogssOwners()
        {
            var owners = dogRepo.ReadAll().Where(d => d.Castrated == true).Select(o => o.Owner).ToList<Owner>();
            return owners;
        }
    }
}
