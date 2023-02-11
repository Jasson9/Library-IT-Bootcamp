using System.ComponentModel.DataAnnotations;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using Library.Model;
namespace backend
{
    public class LibraryDBContext : DbContext
    {
        public DbSet<MsStudent>? MsStudent { get; set; }

        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options)
        {

        }

        //image
    }
}