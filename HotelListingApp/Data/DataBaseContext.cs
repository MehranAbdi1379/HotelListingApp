using Microsoft.EntityFrameworkCore;

namespace HotelListingApp.Data;

public class DataBaseContext : DbContext
{
	public DataBaseContext(DbContextOptions options) : base(options)
	{}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<Country>().HasData(
			new Country()
			{
				Id = 1,
				Name = "Jamaica",
				ShortName = "JM"
			},
			new Country()
			{
				Id = 2,
				Name = "Bahamas",
				ShortName = "BS"
			}, new Country()
			{
				Id = 3,
				Name = "Cayman Island",
				ShortName = "CI"
			}
			);

        builder.Entity<Hotel>().HasData(
            new Hotel()
            {
                Id = 1,
                Name = "Sandals Resort And Spa",
				Address = "Negril",
                CountryId = 1,
				Rating = 4.5
            },
            new Hotel()
            {
                Id = 2,
                Name = "Comfort Suites",
				Address = "George Town",
                CountryId = 2,
                Rating = 4.3
            }, new Hotel()
            {
                Id = 3,
                Name = "Grand Palldium",
				Address= "Nassua",
                CountryId = 3,
                Rating = 4
            }
            );
    }

	public DbSet<Country> Countries { get; set; }
	public DbSet<Hotel> Hotels { get; set; }
}
