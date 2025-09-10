using System.ComponentModel.DataAnnotations;

namespace ph.DTOs;

public class CreateOrUpdatePersonRequestDto
{
 [Required]
 [MinLength(3)]
 public   String Name { get; set; }
 
 [Range(0,120)]
 public int Age { get; set; }
}