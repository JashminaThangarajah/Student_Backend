using System.ComponentModel.DataAnnotations;

namespace StudentRegisterFormAPI.Models
{
    public class Student
    {
      

        [Key]
        public int id { get; set; }
        public string? profileimage { get; set; }
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? address { get; set; }
        public string? gender { get; set; }
        public DateTime? dob { get; set; }

    }
}
