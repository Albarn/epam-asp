using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class Feedback
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20,ErrorMessage ="Name is too long")]
        [Display(Name = "Your Name")]
        public String Author { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(200)]
        [Display(Name ="Feedback")]
        public String Text { get; set; }
    }
}