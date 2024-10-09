using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagmentSystem
{
    public class CourseRepository
    {
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CourseManagement;";

        public void AddCourse(Course course)
        {
            string query = "INSERT INTO Courses (Title, Duration, Price) VALUES (@Title, @Duration, @Price)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", CapitalizeTitle(course.Title));
                    command.Parameters.AddWithValue("@Duration", course.Duration);
                    command.Parameters.AddWithValue("@Price", course.Price);

                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Successfully added course: {course.Title}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error adding course: {ex.Message}");
                    }
                }
            }
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            string query = "SELECT * FROM Courses";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Course course = new Course(
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDecimal(3)
                        )
                        {
                            CourseId = reader.GetInt32(0)
                        };
                        courses.Add(course);
                    }
                }
            }
            return courses;
        }

        public void UpdateCourse(Course course)
        {
            string query = "UPDATE Courses SET Title = @Title, Duration = @Duration, Price = @Price WHERE CourseId = @CourseId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseId", course.CourseId);
                    command.Parameters.AddWithValue("@Title", CapitalizeTitle(course.Title));
                    command.Parameters.AddWithValue("@Duration", course.Duration);
                    command.Parameters.AddWithValue("@Price", course.Price);

                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error updating course: {ex.Message}");
                    }
                }
            }
        }

        public void DeleteCourse(int courseId)
        {
            string query = "DELETE FROM Courses WHERE CourseId = @CourseId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseId", courseId);

                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Successfully deleted course with ID: {courseId}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deleting course: {ex.Message}");
                    }
                }
            }
        }

        public decimal ValidateCoursePrice(decimal price)
        {
            while (price <= 0)
            {
                Console.WriteLine("Price must be a positive value. Please enter a valid price: ");
                price = Convert.ToDecimal(Console.ReadLine());
            }
            return price;
        }

        public string CapitalizeTitle(string title)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
        }
    }
}


