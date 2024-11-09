using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_BusinessObjects
{
    public class Enrollment : BaseEntity
    {

        [Required]
        public string UserId { get; set; }

        [Required]
        public string CourseId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Required]
        [MaxLength(50)]
        [EnumDataType(typeof(EnrollmentStatus))]
        public EnrollmentStatus Status { get; set; } 

        public User? User { get; set; }
        public Course? Course { get; set; }
    }
}
