using Microsoft.EntityFrameworkCore;

namespace HotelListingApp.Data;

public class DataBaseContext : DbContext
{
	public DataBaseContext(DbContextOptions options) : base(options)
	{}

	public DbSet<Country> Countries { get; set; }
	public DbSet<Hotel> Hotels { get; set; }
}
