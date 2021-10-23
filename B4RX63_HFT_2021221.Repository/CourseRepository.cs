using System;
using System.Linq;
using B4RX63_HFT_2021221.Data;
using B4RX63_HFT_2021221.Models;

namespace B4RX63_HFT_2021221.Repository
{
    public class CourseRepository : ICourseRepository
    {
        DogSchoolDBContext db;
        public CourseRepository(DogSchoolDBContext db)
        {
            this.db = db;
        }
        public void Create(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }
        public Course Read(int id)
        {
            return db.Courses.FirstOrDefault(c => c.Id == id);
        }
        public IQueryable<Course> ReadAll()
        {
            return db.Courses;
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
        public void Update(Course course)
        {
            var oldcourse = Read(course.Id);
            oldcourse.Name = course.Name;
            oldcourse.Organizer = course.Organizer;
            oldcourse.Trainer = course.Trainer;
            db.SaveChanges();
        }
    }
}
