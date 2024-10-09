using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagmentSystem
{
    public class DigitalCourse : Course
    {
        public string CourseLink { get; set; }
        public double FileSize { get; set; }

        public DigitalCourse( string title, string duration, decimal price, string courseLink, double fileSize)
            : base( title, duration, price)
        {
            CourseLink = courseLink;
            FileSize = fileSize;
        }

        public override string DisplayCourseInfo()
        {
            return $"{base.DisplayCourseInfo()}, Course Link: {CourseLink}, File Size: {FileSize}MB";
        }
    }

}
