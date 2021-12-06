using B4RX63_HFT_2021221.Models;
using System.Collections.Generic;

namespace B4RX63_HFT_2021221.Logic
{
    //DogLogic interfésze 
    public interface IDogLogic
    {
        void Create(Dog dog);
        void Delete(int id);
        Dog Read(int id);
        IEnumerable<Dog> ReadAll();
        void Update(Dog dog);
        Dog LargestDog();
        string SmallestFemale();
        string MostCommonBreed();
        ICollection<Owner> CastratedDogssOwners();
    }
}