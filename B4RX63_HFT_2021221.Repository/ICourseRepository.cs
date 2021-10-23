using B4RX63_HFT_2021221.Models;
using System.Linq;

namespace B4RX63_HFT_2021221.Repository
{
    interface ICourseRepository
    {
        void Create(Course course);
        void Delete(int id);
        Course Read(int id);
        IQueryable<Course> ReadAll();
        void Update(Course course);
    }
}