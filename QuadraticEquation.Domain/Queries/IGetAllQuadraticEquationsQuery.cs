using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation.Domain.Queries
{
    public interface IGetAllQuadraticEquationsQuery
    {
        Task<IEnumerable<Domain.Models.QuadraticEquation>> Execute();
    }
}
