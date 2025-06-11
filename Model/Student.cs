using System.ComponentModel.DataAnnotations;
namespace crud.Model;

public class Student
{
    [Key]
    public long Id { get; set; }
    
    public string Name { get; set; }
}