using System.ComponentModel.DataAnnotations;

namespace HotelListingApp.Models;



public class CreateCountryDTO
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required, MaxLength(2) , MinLength(1)]
    public string ShortName { get; set; }
}

public class CountryDTO : CreateCountryDTO
{
    public int Id { get; set; }
    public IList<HotelDTO> Hotels { get; set; }
}