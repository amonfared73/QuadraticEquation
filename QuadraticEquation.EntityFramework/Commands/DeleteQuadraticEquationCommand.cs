using QuadraticEquation.Domain.Commands;
using QuadraticEquation.Domain.Models;
using QuadraticEquation.Domain.Queries;
using QuadraticEquation.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuadraticEquation.EntityFramework.Commands
{
    public class DeleteQuadraticEquationCommand : IDeleteQuadraticEquationCommand
    {
        private readonly QuadraticEquationDbContextFactory _contextFactory;

        public DeleteQuadraticEquationCommand(QuadraticEquationDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {
            using (QuadraticEquationDbContext context = _contextFactory.Create())
            {
                QuadraticEquationDto quadraticEquationDto = new QuadraticEquationDto()
                {
                    Id = id
                };
                context.QuadraticEquations.Remove(quadraticEquationDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
