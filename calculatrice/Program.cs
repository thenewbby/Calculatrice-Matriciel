using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculatrice
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Dictionary<String, Matrix> listMatrix = new Dictionary<String, Matrix>();
            String command = Console.ReadLine();
            Parser.parseCommand(command);
            if (listMatrix.ContainsKey("A") && listMatrix.ContainsKey("B"))
            {
                listMatrix.Add("C", listMatrix["A"] + listMatrix["B"]);
            }
            */
            
            SquareMatrix A = new SquareMatrix(4);
            //Matrix B = new Matrix(3,3);
            //Matrix C= new Matrix (2,2);
            A.Input();
            //B.Input();
            Console.Write(A);
            //Console.WriteLine("\n");
           /* C = A + B;
            C.Display();
            Console.WriteLine("\n");
            */
            //(A - B).Display();
            
            A.Det();
        }
    }
}
