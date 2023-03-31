using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation.EntityFramework.DTOs
{
    public class QuadraticEquationDto
    {
        public Guid Id { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set;  }
    }
}
