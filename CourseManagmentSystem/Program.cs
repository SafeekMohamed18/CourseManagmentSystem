using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagmentSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            CourseRepository courseRepository = new CourseRepository();
            int option = 0;

            while (true) // Use a while loop to keep the menu active
            {
                try
                {
                    Console.WriteLine("\nCourse Management System:");
                    Console.WriteLine("1. Add a Course");
                    Console.WriteLine("2. View All Courses");
                    Console.WriteLine("3. Update a Course");
                    Console.WriteLine("4. Delete a Course");
                    Console.WriteLine("5. Exit");
                    Console.Write("Choose an option: ");

                    // Read user input
                    option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            // Add Course
                            Console.Write("Enter Course Title: ");
                            string title = Console.ReadLine();
                            Console.Write("Enter Course Duration: ");
                            string duration = Console.ReadLine();
                            Console.Write("Enter Course Price: ");
                            decimal price = Convert.ToDecimal(Console.ReadLine());
                            price = courseRepository.ValidateCoursePrice(price);
                            Course newCourse = new Course(title, duration, price);
                            courseRepository.AddCourse(newCourse);
                            break;

                        case 2:
                            // View All Courses
                            var courses = courseRepository.GetAllCourses();
                            foreach (var course in courses)
                            {
                                Console.WriteLine(course);
                            }
                            break;

                        case 3:
                            // Update Course
                            Console.Write("Enter Course ID to Update: ");
                            int updateId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter New Title: ");
                            string newTitle = Console.ReadLine();
                            Console.Write("Enter New Duration: ");
                            string newDuration = Console.ReadLine();
                            Console.Write("Enter New Price: ");
                            decimal newPrice = Convert.ToDecimal(Console.ReadLine());
                            newPrice = courseRepository.ValidateCoursePrice(newPrice);
                            Course updatedCourse = new Course(newTitle, newDuration, newPrice) { CourseId = updateId };
                            courseRepository.UpdateCourse(updatedCourse);
                            break;

                        case 4:
                            // Delete Course
                            Console.Write("Enter Course ID to Delete: ");
                            int deleteId = Convert.ToInt32(Console.ReadLine());
                            courseRepository.DeleteCourse(deleteId);
                            break;

                        case 5:
                            Console.WriteLine("Exiting the application...");
                            return; // Exit the program

                        default:
                            Console.WriteLine("Invalid option. Please select a valid option.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
    }
