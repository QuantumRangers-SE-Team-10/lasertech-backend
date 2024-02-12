using System.ComponentModel.DataAnnotations;

namespace lasertech_backend.Model;

public class Player
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Codename is required")]
    [MinLength(3, ErrorMessage = "Codename need to be more than 3 character")]
    [MaxLength(50, ErrorMessage = "Codename cannot be more than 50 character")]
    public string Codename { get; set; }

    [DataType(DataType.DateTime, ErrorMessage = "Invalid datatype for LastUpdated")]
    public DateTime LastUpdated { get; set; }
}