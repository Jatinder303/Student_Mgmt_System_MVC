using System.ComponentModel.DataAnnotations;

namespace Student_Mgmt_System_MVC.Models
{
    public class Student_enrollment
    {
        [Key]

        public int Student_Enrollment_ID { get; set; }

        public int student_ID { get; set; }
        public student_Details student_Details { get; set; }


        public int course_ID { get; set; }
        public Course_details Course_Details { get; set; }

        public int tutor_ID { get; set; }
        public Tutor_details tutor_Details { get; set; }

    }
}
