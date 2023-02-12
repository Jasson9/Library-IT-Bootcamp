using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Library.Model;
namespace Library
{
    public class LibraryDBContext : DbContext
    {
        public DbSet<MsBook>? MsBook { get; set; }
        public DbSet<MsStaff>? MsStaff { get; set; }
        public DbSet<MsStudent>? MsStudent { get; set; }

        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options)
        {

        }

        //image
    }
}