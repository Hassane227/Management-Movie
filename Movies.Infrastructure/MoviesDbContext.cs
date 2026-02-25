using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;

namespace Movies.Infrastructure
{
    public  class MoviesDbContext: DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } 


    }
}
