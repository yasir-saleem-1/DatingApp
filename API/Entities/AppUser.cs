using API.Extensions;

namespace API.Entities;

public class AppUser
{
    public int Id { get; set; }
    public required string Password { get; set; } 
    public string UserName { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public string KnownAs { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
    public  string? Gender { get; set; }
    public string Introduction { get; set; } = string.Empty;
    public string LookingFor { get; set; } = string.Empty;
    public string Interests { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public List<Photo> Photos { get; set; } = new List<Photo>();

  
}

