using B4RX63_HFT_2021221.Models;
using System.Collections.Generic;

namespace B4RX63_HFT_2021221.Logic
{
    //OwnerLogic interfésze
    public interface IOwnerLogic
    {
        void Create(Owner owner);
        void Delete(int id);
        Owner Read(int id);
        IEnumerable<Owner> ReadAll();
        void Update(Owner owner);
        Owner OldestOwner();
        IEnumerable<string> YoungestFemalesDogs();
        ICollection<string> YoungOwnersCourses();
    }
}