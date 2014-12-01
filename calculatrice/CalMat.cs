using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalMat
{
    class CalMat
    {
        public static Dictionary<String, Matrix> listMatrix = new Dictionary<String, Matrix>();
        static void Main(string[] args)
        {
            while (true)
            {
                string control = Console.ReadLine();
                UserInput.parse(control);
            }
            

            /*String command = Console.ReadLine();
            Parser p = new Parser(command);
            if (p.isCreation) {
                listMatrix[p.matrixName] = new Matrix(p.matrixSize);
                listMatrix[p.matrixName].setElements(p.matrixElements);
            }
            if (listMatrix.ContainsKey("A") && listMatrix.ContainsKey("B"))
            {
                listMatrix.Add("C", listMatrix["A"] + listMatrix["B"]);
            }
            */
            
            /*
            SquareMatrix A = new SquareMatrix(3);
            //Matrix B = new Matrix(3,3);
            //Matrix C= new Matrix (2,2);
            A.Input();
            //B.Input();
            A.Det();
            //Console.WriteLine("\n");
           /* C = A + B;
            C.Display(;)
            Console.WriteLine("\n");
            
            Console.Write("\n");
            Console.Write(A);
            */
            
            //A.Det();
        }
    }
}
