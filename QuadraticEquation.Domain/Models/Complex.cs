using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation.Domain.Models
{
    public class Complex
    {
        private double _real, _imaginary;
        public double Real
        {
            get
            {
                return _real;
            }
            set
            {
                _real = Math.Round(value, 2);
            }
        }
        public double Imaginary
        {
            get
            {
                return _imaginary;
            }
            set
            {
                _imaginary = Math.Round(value, 2);
            }
        }
        public Complex(double real = 0, double imaginary = 0)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }
        public static Complex operator +(Complex a, double b)
        {
            return new Complex(a.Real + b, a.Imaginary);
        }
        public static Complex operator -(Complex a, double b)
        {
            return new Complex(a.Real - b, a.Imaginary);
        }
        public static Complex operator +(double a, Complex b)
        {
            return new Complex(a + b.Real, b.Imaginary);
        }
        public static Complex operator -(double a, Complex b)
        {
            return new Complex(a - b.Real, b.Imaginary);
        }
        public static Complex operator +(Complex a, int b)
        {
            return new Complex(a.Real + b, a.Imaginary);
        }
        public static Complex operator -(Complex a, int b)
        {
            return new Complex(a.Real - b, a.Imaginary);
        }
        public static Complex operator +(int a, Complex b)
        {
            return new Complex(a + b.Real, b.Imaginary);
        }
        public static Complex operator -(int a, Complex b)
        {
            return new Complex(a - b.Real, b.Imaginary);
        }
        public static Complex operator /(Complex a, double b)
        {
            return new Complex(a.Real / b, a.Imaginary / b);
        }
        public static Complex operator *(Complex a, double b)
        {
            return new Complex(a.Real * b, a.Imaginary * b);
        }
        public static bool operator ==(Complex a, Complex b)
        {
            return a.Real == b.Real && a.Imaginary == b.Imaginary;
        }
        public static bool operator !=(Complex a, Complex b)
        {
            return !(a == b);
        }
        public static implicit operator Complex(double a)
        {
            return new Complex(a, 0);
        }
        public static implicit operator Complex(int a)
        {
            return new Complex(a, 0);
        }
        public override string ToString()
        {
            string result = string.Empty;
            if (Real == 0 && Imaginary == 0)
            {
                result = string.Format("0");
            }
            else if (Real != 0)
            {
                if (Imaginary == 1)
                    result = string.Format("{0} + j", Real.ToString());
                else if (Imaginary == -1)
                    result = string.Format("{0} - j", Real.ToString());
                else if (Imaginary > 0 && Imaginary != 1)
                    result = string.Format("{0} + {1}j", Real.ToString(), Imaginary.ToString());
                else if (Imaginary < 0 && Imaginary != -1)
                    result = string.Format("{0} - {1}j", Real.ToString(), Math.Abs(Imaginary).ToString());
                else if (Imaginary == 0)
                    result = string.Format("{0}", Real.ToString());
            }
            else if (Real == 0)
            {
                if (Imaginary == 1)
                    result = string.Format("j");
                else if (Imaginary == -1)
                    result = string.Format("-j");
                else if (Imaginary > 0 && Imaginary != 1)
                    result = string.Format("{0}j", Imaginary.ToString());
                else if (Imaginary < 0 && Imaginary != -1)
                    result = string.Format("-{0}j", Math.Abs(Imaginary).ToString());
            }
            return result;
        }
        public override bool Equals(object? obj)
        {
            return obj is Complex complex && Real == complex.Real && Imaginary == complex.Imaginary;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary);
        }
    }
}
