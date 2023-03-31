using Microsoft.EntityFrameworkCore;
using QuadraticEquation.Domain.Queries;
using QuadraticEquation.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation.EntityFramework.Queries
{
    public class GetAllQuadraticEquationsQuery : IGetAllQuadraticEquationsQuery
    {
        private readonly QuadraticEquationDbContextFactory _contextFactory;

        public GetAllQuadraticEquationsQuery(QuadraticEquationDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Domain.Models.QuadraticEquation>> Execute()
        {
            using (QuadraticEquationDbContext context = _contextFactory.Create())
            {
                IEnumerable<QuadraticEquationDto> quadraticEquationDtos = await context.QuadraticEquations.ToListAsync();

                return quadraticEquationDtos.Select(y => new Domain.Models.QuadraticEquation(y.Id, y.A, y.B, y.C));
            }
        }
    }
}
