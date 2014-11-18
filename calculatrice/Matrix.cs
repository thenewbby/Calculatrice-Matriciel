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
        public int[,] Elements { get; set; }



        public static Matrix operator +(Matrix a, Matrix b)
        {
            return a.DoAdd(b);
        }

        protected Matrix DoAdd(Matrix b)
        {
            if (this.Lines == b.Lines && this.Columns == b.Columns)
            {
                Matrix c = new Matrix(this.Columns, this.Lines);
                for (int i = 0; i < this.Lines; i++)
                {
                    for (int j = 0; j < this.Columns; j++)
                    {
                        c.Elements[i, j] = this.Elements[i, j] + b.Elements[i, j];
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
            return a.DoSub(b);
        }

        protected Matrix DoSub (Matrix b)
        {
            if (this.Lines == b.Lines && this.Columns == b.Columns)
            {
                Matrix c = new Matrix(this.Columns, this.Lines);
                for (int i = 0; i < this.Lines; i++)
                {
                    for (int j = 0; j < this.Columns; j++)
                    {
                        c.Elements[i, j] = this.Elements[i, j] - b.Elements[i, j];
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
            return a.DoMul(b);
        }

        protected Matrix DoMul (Matrix b)
        {
            if (this.Columns == b.Lines)
            {
                Matrix c = new Matrix(b.Columns, this.Lines);
                for (int i = 0; i < this.Lines; i++)
                {
                    for (int j = 0; j < b.Columns; j++)
                    {
                        for (int z = 0; z < b.Columns; z++)
                        {
                            c.Elements[i, j] += this.Elements[i, z] * b.Elements[z, j];
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


        public static Matrix operator *(int a, Matrix b)
        {
            return b.DoScal(a);
        }

        protected Matrix DoScal (int a)
        {
            Matrix c = new Matrix(this.Lines, this.Columns);
            for (int i = 0; i < this.Lines; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    c.Elements[i, j] = a * this.Elements[i, j];
                }
            }
            return c;
        }


        public Matrix(int c, int l)
        {
            this.Elements = new int[c, l];
            this.Lines = l;
            this.Columns = c;
        }

        public void Input()
        {
            bool num = false;
            for (int i = 0; i < this.Lines; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    while (!num)
                    {
                        Console.WriteLine("taper le coef ne la case " + i + ";" + j);
                        if (int.TryParse(Console.ReadLine(), out Elements[i, j]))
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

        public override string ToString()
        {
            String value = "";

            for (int j = 0; j < this.Lines; j++)
            {
                for (int i = 0; i < this.Columns; i++)
                {
                    value += Elements[j, i] + "\t";
                }

                value += "\n";

            }
            return value;
        }
    }
}
