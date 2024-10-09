using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagmentSystem
{
    public class OnPremiseCourse : Course
    {
        public string Schedule { get; set; }
        public int ClassroomCapacity { get; set; }

        public OnPremiseCourse( string title, string duration, decimal price, string schedule, int classroomCapacity)
            : base( title, duration, price)
        {
            Schedule = schedule;
            ClassroomCapacity = classroomCapacity;
        }

        public override string DisplayCourseInfo()
        {
            return $"{base.DisplayCourseInfo()}, Schedule: {Schedule}, Classroom Capacity: {ClassroomCapacity}";
        }
    }

}
