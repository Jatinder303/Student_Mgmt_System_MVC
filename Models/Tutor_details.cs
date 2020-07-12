using System.ComponentModel.DataAnnotations;

namespace Student_Mgmt_System_MVC.Models
{
    public class Tutor_details
    {
        [Key]
        public int tutor_ID { get; set; }
        public string tutor_Name { get; set; }

        public string tutor_Email { get; set; }

        public string tutor_Mobile { get; set; }
        public string tutor_Address { get; set; }
    }
}
