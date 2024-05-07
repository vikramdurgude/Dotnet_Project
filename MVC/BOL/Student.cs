using System.ComponentModel.DataAnnotations;

namespace BOL;

public class Student
{
    public int id { get; set; }

    [Required]
    public string name { get; set; }
    public string qual { get; set; }
}