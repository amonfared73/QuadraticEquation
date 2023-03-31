using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation.Domain.Commands
{
    public interface IUpdateQuadraticEquationCommand
    {
        Task Execute(Domain.Models.QuadraticEquation quadraticEquation);
    }
}
