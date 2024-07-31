using Contact_api_asp.net.Classes;
using Microsoft.EntityFrameworkCore;

namespace Contact_api_asp.net
{
    public class DataBaseContexteClasse : DbContext
    {
        public DataBaseContexteClasse(DbContextOptions<DataBaseContexteClasse> options) : base(options)
        {
        }
        public DbSet<Contact> Contact { get; set; }
    }
}
