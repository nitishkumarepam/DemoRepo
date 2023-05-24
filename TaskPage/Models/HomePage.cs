using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskPage.Models
{
    public class HomePage
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("User Name  ")]
        public String UserName { get; set; }


        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [DisplayName("Date & Time")]
        public DateTime Date_Time { get; set; }

        [Required(ErrorMessage = "Required")]
        public String PhoneNumber { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Email     ")]
        public string EMail { get; set; }
    }
}