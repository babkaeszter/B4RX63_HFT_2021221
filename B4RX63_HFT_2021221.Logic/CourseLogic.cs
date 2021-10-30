using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B4RX63_HFT_2021221.Repository;
using B4RX63_HFT_2021221.Models;


namespace B4RX63_HFT_2021221.Logic
{
    public class CourseLogic : ICourseLogic
    {
        ICourseRepository courseRepo;

        public CourseLogic(ICourseRepository courseRepo)
        {
            this.courseRepo = courseRepo;
        }

        public void Create(Course course)
        {

            courseRepo.Create(course);
        }
        public Course Read(int id)
        {
            return courseRepo.Read(id);
        }
        public IEnumerable<Course> ReadAll()
        {
            return courseRepo.ReadAll();
        }
        public void Delete(int id)
        {
            courseRepo.Delete(id);
        }
        public void Update(Course course)
        {
            courseRepo.Update(course);
        }
        //Non-cruds
        //csoportok létszáma
        //legnagyobb kutya csoportja
        //csoportok átlagos testsúly
    }
}
