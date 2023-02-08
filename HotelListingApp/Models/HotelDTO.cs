using HotelListingApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListingApp.Models;


public class CreateHotelDTO
{
    [Required, MaxLength(150)]
    public string Name { get; set; }
    [Required, MaxLength(255)]
    public string Address { get; set; }
    [Required , Range(1,5)]
    public double Rating { get; set; }


    [Required]
    public int CountryId { get; set; }
}

public class HotelDTO : CreateHotelDTO
{
    public int Id { get; set; }
    public CountryDTO Country { get; set; }
}