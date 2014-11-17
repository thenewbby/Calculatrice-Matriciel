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
        

        
        public static Matrix operator+ (Matrix a, Matrix b)
        {
            if (a.Lines == b.Lines && a.Columns == b.Columns)
            {
                Matrix c = new Matrix(a.Columns, a.Lines);
                for (int i = 0; i < a.Lines ; i++)
                {
                    for (int j = 0; j < a.Columns; j++)
                    {
                        c.Elements[i, j] = a.Elements[i, j] + b.Elements[i, j];
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

        
          public static Matrix operator- (Matrix a, Matrix b)
          {
              if (a.Lines == b.Lines && a.Columns == b.Columns)
              {
                  Matrix c = new Matrix(a.Columns, a.Lines);
                  for (int i = 0; i < a.Lines ; i++)
                  {
                      for (int j = 0; j < a.Columns; j++)
                      {
                          c.Elements[i, j] = a.Elements[i, j] - b.Elements[i, j];
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

          public static Matrix operator* (Matrix a, Matrix b)
          {
              if (a.Columns == b.Lines)
              {
                  Matrix c = new Matrix(b.Columns, a.Lines);
                  for (int i = 0; i < a.Lines; i++)
                  {
                      for(int j = 0; j < b.Columns; j++)
                      {
                          for (int z = 0; z < b.Columns; z++)
                          {
                              c.Elements[i, j] += a.Elements[i, z] * b.Elements[z, j];
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


        public Matrix(int c, int l)
        {
            this.Elements = new int[c, l];
            this.Lines = l;
            this.Columns = c;
        }

        public void Input ()
            {
             bool num = false;
             for (int i = 0; i < this.Lines; i++ )
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    while ( !num )
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

    }
}
