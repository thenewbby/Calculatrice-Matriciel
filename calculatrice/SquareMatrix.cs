using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculatrice
{
    class SquareMatrix : Matrix
    {

        public SquareMatrix(int c) : base(c,c)
        {

            this.Elements = new int[c, c];
            this.Lines = c;
            this.Columns = c;
        }

        public static SquareMatrix operator +(SquareMatrix a, SquareMatrix b)
        {
            return a.DoAdd(b);
        }

        protected SquareMatrix DoAdd(SquareMatrix b)
        {
            if (this.Lines == b.Lines && this.Columns == b.Columns)
            {
                SquareMatrix c = new SquareMatrix(this.Columns);
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

        public static SquareMatrix operator -(SquareMatrix a, SquareMatrix b)
        {
            return a.DoSub(b);
        }

        protected SquareMatrix DoSub(SquareMatrix b)
        {
            if (this.Lines == b.Lines && this.Columns == b.Columns)
            {
                SquareMatrix c = new SquareMatrix(this.Columns);
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

        public static SquareMatrix operator *(SquareMatrix a, SquareMatrix b)
        {
            return a.DoMul(b);
        }

        protected SquareMatrix DoMul(SquareMatrix b)
        {
            if (this.Columns == b.Lines)
            {
                SquareMatrix c = new SquareMatrix(b.Columns);
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

        public static SquareMatrix operator *(int a, SquareMatrix b)
        {
            return b.DoScal(a);
        }

        protected new SquareMatrix DoScal(int a)
        {
            SquareMatrix c = new SquareMatrix(this.Lines);
            for (int i = 0; i < this.Lines; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    c.Elements[i, j] = a * this.Elements[i, j];
                }
            }
            return c;
        }
        /*
        protected int SubMatrix(SquareMatrix a, int x)
        {
            if (a.Columns == 2)
            {
                return a.Elements[0, 0] * a.Elements[1, 1] - a.Elements[0, 1] * a.Elements[1, 0];
            }
            else
            {
                SquareMatrix b = new SquareMatrix(a.Lines - 1);
                int f = 0, g = 0, interDet = 0;
                for (int i = 1; i < a.Lines; i++)
                {
                    g = 0;
                    for(int j = 0; j < a.Columns; j++)
                    {
                        if (j == x)
                        {
                            continue;
                        }
                        else
                        {
                            b.Elements[f, g] = a.Elements[i, j];
                            g++;
                        }
                    }
                    f ++;
                }
                Console.WriteLine("\n");
                for(int i = 0;i < a.Lines; i++)
                {
                   interDet += b.SubMatrix(b,i) * (int) Math.Pow(-1,i)* a.Elements[0,i];
                   Console.WriteLine("det:" + interDet);
                   //Console.WriteLine("\n");
                }
                

                return interDet;
               
            }
        }


        public int Det()
        {
                if (this.Lines == 1)
                {
                    return this.Elements[0, 0];
                }
                else
                {
                    int det = 0;
                    for ( int j = 0; j < this.Columns; j++)
                    {
                        det += (int) Math.Pow(-1, j) * this.Elements[0, j] * this.SubMatrix(this, j);
                        

                    }
                    Console.WriteLine(det);
                    return det;
                }
         }
        */




        /*public int Det ()
        {
            if (this.Lines == 1)
            {
                return this.Elements[0, 0];
            }
            else if (this.Columns == 2)
            {
                return this.Elements[0, 0] * this.Elements[1, 1] - this.Elements[0, 1] * this.Elements[1, 0];
            }
            else
            {
                SquareMatrix subMatrix = new SquareMatrix(this.Lines - 1);
                int f, g, det = 0;
                for(int x = 0 ; x < this .Columns; x++)
                {
                    f = 0;
                    for (int i = 1; i < this.Lines; i++)
                    {
                        g = 0;
                        for(int j = 0; j < this.Columns; j++)
                        {
                            if (j != x)
                            {
                                subMatrix.Elements[f, g] = this.Elements[i, j];
                                g++;
                            }
                        }
                        f ++;
                    }
                    Console.WriteLine("\n");
                    Console.Write(subMatrix);
                    for(int i = 0;i < this.Lines; i++)
                    {
                        det += subMatrix.Det() * (int) Math.Pow(-1,i)* this.Elements[0,i];
                        
                    }
                }
                Console.WriteLine("det");
                return det;
            }
        }*/


        /*public int Det ()
        {
            int M;
            SquareMatrix c = this; 
            for (int j = 0 ; j < this.Columns; j++)
            {
                M = j;
                for (int i = j; i < this.Lines -1 ; i++ )
                {
                    //if ( this.Elements[ i , j ] > this  )
                    //{

                    //}
                }
            }
        }
         */
    }            
}


