using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculatrice
{
    class Matrix
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        public double[,] Elements { get; set; }
        public string name { get; set; }

        public Matrix(int c, int l)
        {
            this.Elements = new double[c, l];
            this.Lines = l;
            this.Columns = c;
        }

        public Matrix(int c, int l, string nom)
        {
            this.Elements = new double[c, l];
            this.Lines = l;
            this.Columns = c;
            this.name = nom;
            if (!CalMat.listMatrix.ContainsKey(this.name))
            {
                CalMat.listMatrix.Add(this.name, this);
            }
            
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Lines == b.Lines && a.Columns == b.Columns)
            {
                Matrix c = new Matrix(a.Columns, a.Lines);
                for (int i = 0; i < a.Lines; i++)
                {
                    for (int j = 0; j < a.Columns; j++)
                    {
                        c.Elements[j, i] = a.Elements[j, i] + b.Elements[j, i];
                    }
                }
                return c;
            }
            else
            {
                Console.WriteLine("operation impossible");
                return null;
            }
        }


        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Lines == b.Lines && a.Columns == b.Columns)
            {
                Matrix c = new Matrix(a.Columns, a.Lines);
                for (int i = 0; i < a.Lines; i++)
                {
                    for (int j = 0; j < a.Columns; j++)
                    {
                        c.Elements[j, i] = a.Elements[j, i] - b.Elements[j, i];
                    }
                }
                return c;
            }
            else
            {
                Console.WriteLine("operation impossible");
                return null;
            }
        }


        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns == b.Lines)
            {
                Matrix c = new Matrix(b.Columns, a.Lines);
                for (int i = 0; i < a.Lines; i++)
                {
                    for (int j = 0; j < b.Columns; j++)
                    {
                        for (int z = 0; z < a.Columns; z++)
                        {
                            c.Elements[j, i] += a.Elements[z, i] * b.Elements[j, z];
                        }
                    }
                }
                return c;
            }
            else
            {
                Console.WriteLine("operation impossible");
                return null;
            }
        }

        public static Matrix operator *(double a, Matrix b)
        {
            Matrix c = new Matrix(b.Lines, b.Columns);
            for (int i = 0; i < b.Lines; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    c.Elements[i, j] = a * b.Elements[i, j];
                }
            }
            return c;
        }

        public static Matrix operator *(string a, Matrix b)
        {
            double value;
            if (Double.TryParse(a, out value))
            {
                return value * b;
            }
            Console.WriteLine("impossible de convertir '" + a + "' en double dans l'operateur * de matrix");
            return null;
        }

        public static Matrix operator *(Matrix b, string a)
        {
            return a * b;
        }

        public static Matrix operator *(Matrix b, double a)
        {
            return a * b;
        }

        public void Input()
        {
            bool num = false;
            for (int j = 0; j < this.Lines; j++)
            {
                for (int i = 0; i < this.Columns; i++)
                {
                    while (!num)
                    {
                        Console.WriteLine("taper le coef ne la case " + i + ";" + j);
                        if (double.TryParse(Console.ReadLine(), out Elements[i, j]))
                        {
                            num = true;
                            Console.WriteLine("ok");
                        }
                        else
                        {
                            Console.WriteLine("taper un entier");
                        }
                    }
                    num = false;

                }
            }
        }

        public Matrix Trans()
        {
            Matrix T = new Matrix(this.Lines, this.Columns);
            for (int i = 0 ; i < this.Lines ; i++)
            {
                for (int j = 0 ; j < this.Columns ; j++)
                {
                    T.Elements[i, j] = this.Elements[j, i];
                }
            }
            return T;
        }

        public override string ToString()
        {
            String value = "";

            for (int j = 0; j < this.Lines; j++)
            {
                for (int i = 0; i < this.Columns; i++)
                {
                    value += Elements[i, j] + "\t";
                }

                value += "\n";

            }
            return value;
        }
    }
}
