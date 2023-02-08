using HotelListingApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListingApp.Models;


public class CreateHotelDTO
{
    [Required, MaxLength(50)]
    public string Name { get; set; }
    [Required, MaxLength(255)]
    public string Address { get; set; }
    [Required]
    public double Rating { get; set; }


    [ForeignKey(nameof(Country))]
    public int CountryId { get; set; }
    public Country Country { get; set; }
}

public class HotelDTO : CreateHotelDTO
{
    public int Id { get; set; }
}