using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation.EntityFramework
{
    public class QuadraticEquationDbContextFactory
    {
        private readonly DbContextOptions _options;

        public QuadraticEquationDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public QuadraticEquationDbContext Create()
        {
            return new QuadraticEquationDbContext(_options);
        }
    }
}
