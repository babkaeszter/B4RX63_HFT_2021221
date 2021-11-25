using B4RX63_HFT_2021221.Models;
using System.Collections.Generic;

namespace B4RX63_HFT_2021221.Logic
{
    public interface ICourseLogic
    {
        void Create(Course course);
        void Delete(int id);
        Course Read(int id);
        IEnumerable<Course> ReadAll();
        void Update(Course course);
        ICollection<KeyValuePair<string, int>> CourseGroupNumber();
        ICollection<KeyValuePair<string, double>> CourseAverageWeight();

    }
}