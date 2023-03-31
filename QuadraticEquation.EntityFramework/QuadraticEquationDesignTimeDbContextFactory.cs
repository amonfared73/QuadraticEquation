using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation.EntityFramework
{
    public class QuadraticEquationDesignTimeDbContextFactory : IDesignTimeDbContextFactory<QuadraticEquationDbContext>
    {
        public QuadraticEquationDbContext CreateDbContext(string[] args)
        {
            return new QuadraticEquationDbContext(new DbContextOptionsBuilder().UseSqlite("Data Source=QuadraticEquations.db").Options);
        }
    }
}
