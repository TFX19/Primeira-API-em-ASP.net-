using Microsoft.EntityFrameworkCore;
using tentativa1.Models;
namespace tentativa1.Data
{
    public class apiContext : DbContext
    {

        public DbSet<InfoWebsite> InformacaoWeb { get; set; }
        public apiContext(DbContextOptions<apiContext> options)
            :base(options)
        {   
        
        }

    }
}
