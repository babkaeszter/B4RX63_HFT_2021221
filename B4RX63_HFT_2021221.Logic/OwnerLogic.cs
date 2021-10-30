using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B4RX63_HFT_2021221.Repository;
using B4RX63_HFT_2021221.Models;

namespace B4RX63_HFT_2021221.Logic
{
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
        //legnagyobb kutya gazdija
    }
}
