using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagmentSystem
{
    public class CourseManager
    {
        private List<Course> courses = new List<Course>();

        public void CreateCourse(Course course)
        {
            courses.Add(course);
        }

        public List<Course> ReadCourses()
        {
            return courses;
        }

        public void UpdateCourse(int courseId, Course updatedCourse)
        {
            var course = courses.Find(c => c.CourseId == courseId);
            if (course != null)
            {
                course.Title = updatedCourse.Title;
                course.Duration = updatedCourse.Duration;
                course.Price = updatedCourse.Price;
            }
        }

        public void DeleteCourse(int courseId)
        {
            var course = courses.Find(c => c.CourseId == courseId);
            if (course != null)
            {
                courses.Remove(course);
            }
        }

        public decimal ValidateCoursePrice(decimal price)
        {
            while (price <= 0)
            {
                Console.WriteLine("Price must be positive. Please enter a valid price:");
                price = Convert.ToDecimal(Console.ReadLine());
            }
            return price;
        }
    }
}

