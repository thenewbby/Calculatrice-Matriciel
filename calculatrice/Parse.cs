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
         private static Regex cal_rgx     = new Regex(@"^(\w)\=(\w)([\+\-\*])(\w)$");
         private static Regex creat_rgx   = new Regex(@"^(\w)\=\[(\d),(\d)\]$");
         private static Regex showCal_rgx = new Regex(@"^(\w)([\+\-\*])(\w)$");
         private static Regex exit_rgx    = new Regex(@"(exit)");
         private static Regex meth_rgx    = new Regex(@"^(\w+)\((\w)\)$");
         private static Regex methaff_rgx = new Regex(@"^(\w)\=(\w+)\((\w)\)$");

         private static void create( string operande1, string operande2, string Mtrx_assign_name)
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
                 string operateur        = matches[0].Groups[3].ToString();
                 string operande1        = matches[0].Groups[2].ToString();
                 string operande2        = matches[0].Groups[4].ToString();
                 string Mtrx_assign_name = matches[0].Groups[1].ToString();
                 switch (operateur)
                 {
                     case "+":
                         if (!CalMat.listMatrix.ContainsKey(Mtrx_assign_name))
                         {
                             create(operande1, operande2, Mtrx_assign_name);
                         }
                         CalMat.listMatrix[Mtrx_assign_name] = CalMat.listMatrix[operande1] + CalMat.listMatrix[operande2];
                         break;
                     case "-":
                         if (!CalMat.listMatrix.ContainsKey(Mtrx_assign_name))
                         {
                             create(operande1, operande2, Mtrx_assign_name);
                         }
                        CalMat.listMatrix[Mtrx_assign_name] = CalMat.listMatrix[operande1] - CalMat.listMatrix[operande2];
                         break;

                     case "*":
                         if (!CalMat.listMatrix.ContainsKey(Mtrx_assign_name))
                         {
                             create(operande1, operande2, Mtrx_assign_name);
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
                             CalMat.listMatrix[Mtrx_assign_name] = CalMat.listMatrix[operande1] * CalMat.listMatrix[operande2];
                         }


                         break;
                 }
             }

             matches = creat_rgx.Matches(control);

             if (matches.Count > 0)
             {
                 string Mtrx_assign_name = matches[0].Groups[1].ToString();
                 string dim1             = matches[0].Groups[2].ToString();
                 string dim2             = matches[0].Groups[3].ToString();

                 if ( !CalMat.listMatrix.ContainsKey(Mtrx_assign_name) )
                 {
                     if (dim1 == dim2)
                     {
                         int dim;
                         if (int.TryParse(dim1, out dim))
                         {
                             SquareMatrix matrix_creat = new SquareMatrix(dim, Mtrx_assign_name);
                         }
                         else
                         {
                             Console.WriteLine("les dimentions données ne sont pas valide");
                         }

                     }
                     else
                     {
                         int dim_1, dim_2;
                         if (int.TryParse(dim1, out dim_1) && int.TryParse(dim2, out dim_2))
                         {
                             Matrix matrix_creat = new Matrix(dim_1, dim_2, Mtrx_assign_name);
                         }
                     }
                      CalMat.listMatrix[Mtrx_assign_name].Input();
                 }
                 else
                 {
                     Console.WriteLine("il existe deja une matrice " + Mtrx_assign_name);
                 }
             }

             matches = showCal_rgx.Matches(control);

             if (matches.Count > 0)
             {
                 string operande1 = matches[0].Groups[1].ToString();
                 string operateur = matches[0].Groups[2].ToString();
                 string operande2 = matches[0].Groups[3].ToString();

                 switch(operateur)
                 {
                     case "+":
                         Console.WriteLine(CalMat.listMatrix[operande1] + CalMat.listMatrix[operande2]);
                         break;


                     case "-":
                         Console.WriteLine(CalMat.listMatrix[operande1] - CalMat.listMatrix[operande2]);
                         break;

                     case "*":
                         if (!CalMat.listMatrix.ContainsKey(operande1))
                         {
                             Console.WriteLine(operande1 * CalMat.listMatrix[operande2]);
                         }
                         else if (!CalMat.listMatrix.ContainsKey(operande2))
                         {
                             Console.WriteLine(operande2 * CalMat.listMatrix[operande1]);
                         }
                         else
                         {
                             Console.WriteLine(CalMat.listMatrix[operande1] * CalMat.listMatrix[operande2]);
                         }

                         break;
                 }
             }

             matches = exit_rgx.Matches(control);

             if (matches.Count>0)
             {
                 System.Diagnostics.Process.GetCurrentProcess().Kill();
             }

             matches = meth_rgx.Matches(control);

             if(matches.Count > 0)
             {
                 string method = matches[0].Groups[1].ToString();
                 string matrix = matches[0].Groups[2].ToString();

                 if (method == "trans")
                 {
                     Console.WriteLine(CalMat.listMatrix[matrix].Trans());
                 }
                 else if (method == "det")
                 {
                     if (CalMat.listMatrix[matrix].Lines == CalMat.listMatrix[matrix].Columns)
                     {
                         ((SquareMatrix)CalMat.listMatrix[matrix]).Det();
                     }
                 }
                 else if (method == "trace")
                 {
                     if (CalMat.listMatrix[matrix].Lines == CalMat.listMatrix[matrix].Columns)
                     {
                         ((SquareMatrix)CalMat.listMatrix[matrix]).Trace();
                     }

                 }
                 else if (method == "norme")
                 {
                     if (CalMat.listMatrix[matrix].Lines == CalMat.listMatrix[matrix].Columns)
                     {
                         ((SquareMatrix)CalMat.listMatrix[matrix]).Norme();
                     }
                 }
             }

             matches = methaff_rgx.Matches(control);

             if(matches.Count >0)
             {
                 string Mtrx_assign_name = matches[0].Groups[1].ToString();
                 string method           = matches[0].Groups[2].ToString();
                 string matrix           = matches[0].Groups[3].ToString();
                 if (method == "trans")
                 {
                     if (!CalMat.listMatrix.ContainsKey(Mtrx_assign_name))
                     {
                         if (CalMat.listMatrix[matrix].Lines == CalMat.listMatrix[matrix].Columns)
                         {
                             SquareMatrix matrix_assign = new SquareMatrix(CalMat.listMatrix[matrix].Lines, Mtrx_assign_name);
                         }
                         else
                         {
                             CalMat.listMatrix.Add(Mtrx_assign_name, null);
                         }
                     }
                     CalMat.listMatrix[Mtrx_assign_name] = CalMat.listMatrix[matrix].Trans();
                     Console.WriteLine(CalMat.listMatrix[Mtrx_assign_name]);
                 }
             }
         }
    }
}

