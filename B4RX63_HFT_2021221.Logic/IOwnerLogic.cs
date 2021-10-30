using B4RX63_HFT_2021221.Models;
using System.Collections.Generic;

namespace B4RX63_HFT_2021221.Logic
{
    public interface IOwnerLogic
    {
        void Create(Owner owner);
        void Delete(int id);
        Owner Read(int id);
        IEnumerable<Owner> ReadAll();
        void Update(Owner owner);
    }
}