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
        //legkisebb kutya
        //leggyakoribb kutyafajta
    }
}
