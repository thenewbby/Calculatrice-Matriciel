using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace calculatrice
{
     class UserInput
         
    {
         private static Regex cal_rgx = new Regex(@"^(\w)\=(\w)([\+\-\*])(\w)$");
         private static Regex creat_rgx = new Regex(@"^(\w)\=\[(\d),(\d)\]$");

         private static void create(string operateur, string operande1, string operande2, string Mtrx_assign_name)
         {
             string mtrx_operande = CalMat.listMatrix.ContainsKey(operande1) ? operande1 : operande2;
             if (CalMat.listMatrix[mtrx_operande].Lines == CalMat.listMatrix[mtrx_operande].Columns)
             {
                 SquareMatrix matrix_assign = new SquareMatrix(CalMat.listMatrix[mtrx_operande].Lines, Mtrx_assign_name);
             }
             else
             {
                 CalMat.listMatrix.Add(Mtrx_assign_name, null);
                 //Matrix matrix_assign = new Matrix(CalMat.listMatrix[operande2].Columns, CalMat.listMatrix[operande1].Lines, Mtrx_assign_name);
             }
         }
         
         public static void parse(string control)
         {
             MatchCollection matches;

             control = control.Replace(" ", "");
             matches = cal_rgx.Matches(control);

             if (matches.Count > 0)
             {
                 string operateur = matches[0].Groups[3].ToString();
                 string operande1 = matches[0].Groups[2].ToString();
                 string operande2 = matches[0].Groups[4].ToString();
                 string Mtrx_assign_name =  matches[0].Groups[1].ToString();
                 switch (operateur)
                 {
                     case "+":
                         if (!CalMat.listMatrix.ContainsKey(Mtrx_assign_name))
                         {
                             create(operateur, operande1, operande2, Mtrx_assign_name);
                         }
                         CalMat.listMatrix[Mtrx_assign_name] = CalMat.listMatrix[operande1] + CalMat.listMatrix[operande2];
                         break;
                     case "-":
                         if (!CalMat.listMatrix.ContainsKey(Mtrx_assign_name))
                         {
                             create(operateur, operande1, operande2, Mtrx_assign_name);
                         }
                        CalMat.listMatrix[Mtrx_assign_name] = CalMat.listMatrix[operande1] - CalMat.listMatrix[operande2];
                         break;

                     case "*":
                         if (!CalMat.listMatrix.ContainsKey(Mtrx_assign_name))
                         {
                             create(operateur, operande1, operande2, Mtrx_assign_name);
                         }

                         if(!CalMat.listMatrix.ContainsKey(operande1))
                         {
                             CalMat.listMatrix[Mtrx_assign_name] = operande1 * CalMat.listMatrix[operande2];
                         }
                         else if (!CalMat.listMatrix.ContainsKey(operande2))
                         {
                             CalMat.listMatrix[Mtrx_assign_name] = operande2 * CalMat.listMatrix[operande1];
                         }
                         else
                         {
                             CalMat.listMatrix[Mtrx_assign_name] = CalMat.listMatrix[operande2] * CalMat.listMatrix[operande1];
                         }
                         Console.WriteLine(CalMat.listMatrix[Mtrx_assign_name]);


                         break;
                 }
             }

             matches = creat_rgx.Matches(control);

             if (matches.Count > 0)
             {



             }

         }
    }
}
