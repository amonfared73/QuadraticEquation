using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation.Domain.Models
{
    public class QuadraticEquation
    {
        public Guid Id { get; }
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public QuadraticEquation(Guid id, double a, double b, double c)
        {
            Id = id;
            A = a;
            B = b;
            C = c;
        }
        public override string ToString()
        {
            string result = "";
            if (B == 0 && C == 0)
            {
                if (A == 1)
                    result = string.Format("x^2 = 0");
                else if (A == -1)
                    result = string.Format("-x^2 = 0");
                else
                    result = string.Format("{0}x^2 = 0", A.ToString());
            }
            else if (B != 0 && C == 0)
            {
                if (A == 1)
                {
                    if (B == 1)
                        result = string.Format("x^2 + x = 0");
                    else if (B == -1)
                        result = string.Format("x^2 - x = 0");
                    else if (B != 1 && B != -1 && B > 0)
                        result = string.Format("x^2 + {0}x = 0", B.ToString());
                    else if (B != 1 && B != -1 && B < 0)
                        result = string.Format("x^2 - {0}x = 0", Math.Abs(B).ToString());
                }
                if (A == -1)
                {
                    if (B == 1)
                        result = string.Format("-x^2 + x = 0");
                    else if (B == -1)
                        result = string.Format("-x^2 - x = 0");
                    else if (B != 1 && B != -1 && B > 0)
                        result = string.Format("-x^2 + {0}x = 0", B.ToString());
                    else if (B != 1 && B != -1 && B < 0)
                        result = string.Format("-x^2 - {0}x = 0", Math.Abs(B).ToString());
                }
                else if (A != 1 && A != -1)
                {
                    if (B == 1)
                        result = string.Format("{0}x^2 + x = 0", A.ToString());
                    else if (B == -1)
                        result = string.Format("{0}x^2 - x = 0", A.ToString());
                    else if (B != 1 && B != -1 && B > 0)
                        result = string.Format("{0}x^2 + {1}x = 0", A.ToString(), B.ToString());
                    else if (B != 1 && B != -1 && B < 0)
                        result = string.Format("{0}x^2 - {1}x = 0", A.ToString(), Math.Abs(B).ToString());
                }
            }
            else if (B == 0 && C != 0)
            {
                if (A == 1)
                {
                    if (C > 0)
                        result = string.Format("x^2 + {0} = 0", C.ToString());
                    else if (C < 0)
                        result = string.Format("x^2 - {0} = 0", Math.Abs(C).ToString());
                }
                else if (A == -1)
                {
                    if (C > 0)
                        result = string.Format("-x^2 + {0} = 0", C.ToString());
                    else if (C < 0)
                        result = string.Format("-x^2 - {0} = 0", Math.Abs(C).ToString());
                }
                else if (A != -1 && A != 1)
                {
                    if (C > 0)
                        result = string.Format("{0}x^2 + {1} = 0", A.ToString(), C.ToString());
                    else if (C < 0)
                        result = string.Format("{0}x^2 - {1} = 0", A.ToString(), Math.Abs(C).ToString());
                }
            }
            else if (B != 0 && C != 0)
            {
                if (A == 1)
                {
                    if (B == 1)
                    {
                        if (C > 0)
                            result = string.Format("x^2 + x + {0} = 0", C.ToString());
                        else if (C < 0)
                            result = string.Format("x^2 + x - {0} = 0", Math.Abs(C).ToString());

                    }
                    else if (B == -1)
                    {
                        if (C > 0)
                            result = string.Format("x^2 - x + {0} = 0", C.ToString());
                        else if (C < 0)
                            result = string.Format("x^2 - x - {0} = 0", Math.Abs(C).ToString());

                    }
                    else if (B != 1 && B != -1 && B > 0)
                    {
                        if (C > 0)
                            result = string.Format("x^2 + {0}x + {1} = 0", B.ToString(), C.ToString());
                        else if (C < 0)
                            result = string.Format("x^2 + {0}x - {1} = 0", B.ToString(), Math.Abs(C).ToString());
                    }
                    else if (B != 1 && B != -1 && B < 0)
                    {
                        if (C > 0)
                            result = string.Format("x^2 - {0}x + {1} = 0", Math.Abs(B).ToString(), C.ToString());
                        else if (C < 0)
                            result = string.Format("x^2 - {0}x - {1} = 0", Math.Abs(B).ToString(), Math.Abs(C).ToString());
                    }
                }
                else if (A == -1)
                {
                    if (B == 1)
                    {
                        if (C > 0)
                            result = string.Format("-x^2 + x + {0} = 0", C.ToString());
                        else if (C < 0)
                            result = string.Format("-x^2 + x - {0} = 0", Math.Abs(C).ToString());

                    }
                    else if (B == -1)
                    {
                        if (C > 0)
                            result = string.Format("-x^2 - x + {0} = 0", C.ToString());
                        else if (C < 0)
                            result = string.Format("-x^2 - x - {0} = 0", Math.Abs(C).ToString());

                    }
                    else if (B != 1 && B != -1 && B > 0)
                    {
                        if (C > 0)
                            result = string.Format("-x^2 + {0}x + {1} = 0", B.ToString(), C.ToString());
                        else if (C < 0)
                            result = string.Format("-x^2 + {0}x - {1} = 0", B.ToString(), Math.Abs(C).ToString());
                    }
                    else if (B != 1 && B != -1 && B < 0)
                    {
                        if (C > 0)
                            result = string.Format("-x^2 - {0}x + {1} = 0", Math.Abs(B).ToString(), C.ToString());
                        else if (C < 0)
                            result = string.Format("-x^2 - {0}x - {1} = 0", Math.Abs(B).ToString(), Math.Abs(C).ToString());
                    }
                }
                else if (A != 1 && A != -1)
                {
                    if (B == 1)
                    {
                        if (C > 0)
                            result = string.Format("{0}x^2 + x + {1} = 0", A.ToString(), C.ToString());
                        else if (C < 0)
                            result = string.Format("{0}x^2 + x - {1} = 0", A.ToString(), Math.Abs(C).ToString());

                    }
                    else if (B == -1)
                    {
                        if (C > 0)
                            result = string.Format("{0}x^2 - x + {1} = 0", A.ToString(), C.ToString());
                        else if (C < 0)
                            result = string.Format("{0}x^2 - x - {1} = 0", A.ToString(), Math.Abs(C).ToString());

                    }
                    else if (B != 1 && B != -1 && B > 0)
                    {
                        if (C > 0)
                            result = string.Format("{0}x^2 + {1}x + {2} = 0", A.ToString(), B.ToString(), C.ToString());
                        else if (C < 0)
                            result = string.Format("{0}x^2 + {1}x - {2} = 0", A.ToString(), B.ToString(), Math.Abs(C).ToString());
                    }
                    else if (B != 1 && B != -1 && B < 0)
                    {
                        if (C > 0)
                            result = string.Format("{0}x^2 - {1}x + {2} = 0", A.ToString(), Math.Abs(B).ToString(), C.ToString());
                        else if (C < 0)
                            result = string.Format("{0}x^2 - {1}x - {2} = 0", A.ToString(), Math.Abs(B).ToString(), Math.Abs(C).ToString());
                    }
                }
            }
            return result;
        }

        public Complex[] Answers = new Complex[2];
        public async Task Solve()
        {
            double _delta;
            Complex _Delta;
            await Task.Run(() =>
            {
                _delta = Math.Pow(B, 2) - 4 * A * C;
                _Delta = (_delta >= 0) ? new Complex(Math.Pow(_delta, 0.5), 0) : new Complex(0, Math.Pow(Math.Abs(_delta), 0.5));
                Answers[0] = (-B + _Delta * 1) / (2 * A);
                Answers[1] = (-B + _Delta * -1) / (2 * A);
            });
        }
    }
}
