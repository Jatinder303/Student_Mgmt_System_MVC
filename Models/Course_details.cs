using System;
using System.ComponentModel.DataAnnotations;

namespace Student_Mgmt_System_MVC.Models
{
    public class Course_details
    {
        [Key]
        public int course_ID { get; set; }
        public string course_Name { get; set; }

        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string course_duration { get; set; }
    }
}
