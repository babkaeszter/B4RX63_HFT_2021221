using B4RX63_HFT_2021221.Models;
using System.Linq;

namespace B4RX63_HFT_2021221.Repository
{
    public interface IDogRepository
    {
        void Create(Dog dog);
        void Delete(int id);
        Dog Read(int id);
        IQueryable<Dog> ReadAll();
        void Update(Dog dog);
    }
}