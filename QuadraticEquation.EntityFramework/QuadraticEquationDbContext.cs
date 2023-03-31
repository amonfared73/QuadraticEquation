using Microsoft.EntityFrameworkCore;
using QuadraticEquation.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation.EntityFramework
{
    public class QuadraticEquationDbContext : DbContext
    {
        public QuadraticEquationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<QuadraticEquationDto> QuadraticEquations { get; set; }
    }
}
