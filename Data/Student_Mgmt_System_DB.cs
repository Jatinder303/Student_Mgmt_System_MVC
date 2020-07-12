using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_Mgmt_System_MVC.Models;

namespace Student_Mgmt_System_MVC.Data
{
    public class Student_Mgmt_System_DB : DbContext
    {
        public Student_Mgmt_System_DB (DbContextOptions<Student_Mgmt_System_DB> options)
            : base(options)
        {
        }

        public DbSet<Student_Mgmt_System_MVC.Models.Course_details> Course_details { get; set; }

        public DbSet<Student_Mgmt_System_MVC.Models.student_Details> student_Details { get; set; }

        public DbSet<Student_Mgmt_System_MVC.Models.Tutor_details> Tutor_details { get; set; }

        public DbSet<Student_Mgmt_System_MVC.Models.Student_enrollment> Student_enrollment { get; set; }
    }
}
