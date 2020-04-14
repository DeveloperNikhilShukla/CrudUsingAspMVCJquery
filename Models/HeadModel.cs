using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrudUsingAspMVCJquery.Models
{
    public class HeadModel
    {
        public List<StudentInfo> _StudentInfo { get; set; }

        public HeadModel()
        {
            _StudentInfo = new List<StudentInfo>();
        }
    }


    public class StudentInfo
    {


        public int id { get; set; }


        [Required(ErrorMessage = "Enter Your Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Enter Your Email")]
        [Display(Name = "Email")]
        [DataType(DataType.Text)]
        public string Email { get; set; }


        [RegularExpression(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        [Required(ErrorMessage = "Enter Your Mobile")]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Course")]
        [Required(ErrorMessage = "Enter Your Course")]
        [DataType(DataType.Text)]
        public string Course { get; set; }


        [Display(Name = "age")]
        [Required(ErrorMessage = "Enter Your Age")]
        [Range(18, 100)]
       
        public int age { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Enter Your Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
    }

}