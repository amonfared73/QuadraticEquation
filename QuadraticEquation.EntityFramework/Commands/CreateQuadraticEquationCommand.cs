using Microsoft.EntityFrameworkCore;
using QuadraticEquation.Domain.Commands;
using QuadraticEquation.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation.EntityFramework.Commands
{
    public class CreateQuadraticEquationCommand : ICreateQuadraticEquationCommand
    {
        private readonly QuadraticEquationDbContextFactory _contextFactory;

        public CreateQuadraticEquationCommand(QuadraticEquationDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Domain.Models.QuadraticEquation quadraticEquation)
        {
            using (QuadraticEquationDbContext context = _contextFactory.Create())
            {
                QuadraticEquationDto quadraticEquationDto = new QuadraticEquationDto()
                {
                    Id= quadraticEquation.Id,
                    A = quadraticEquation.A,
                    B = quadraticEquation.B,
                    C = quadraticEquation.C
                };
                context.QuadraticEquations.Add(quadraticEquationDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
