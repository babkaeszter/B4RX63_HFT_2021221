using B4RX63_HFT_2021221.Models;
using System.Linq;

namespace B4RX63_HFT_2021221.Repository
{
    //Adatbázissal dolgozó osztály interfésze
    public interface IOwnerRepository
    {
        void Create(Owner owner);
        void Delete(int id);
        Owner Read(int id);
        IQueryable<Owner> ReadAll();
        void Update(Owner owner);
    }
}