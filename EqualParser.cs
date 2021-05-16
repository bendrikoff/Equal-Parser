using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Parse
{

    static CultureInfo en = new CultureInfo("en-US");


    public static void ParseEqual()
    {
        Console.WriteLine("Enter count of equals");
        int equals = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter count of vars");
        int n = int.Parse(Console.ReadLine());

        Regex pattern = new Regex("(-|'+')?[0-9]*x[0-9]");

        double[,] matrix = new double[equals, n + 1];

        for (int j = 0; j < equals; j++)
        {
            Console.WriteLine($"Enter {j + 1}-st equal");
            string userStr = Console.ReadLine();


            string rightSide = userStr.Split('=')[1];
            string leftSide = userStr.Split('=')[0];


            List<double> list = new List<double>();
            for (int i = 0; i < n + 1; i++)
            {
                list.Add(0);
            }



            var matches1 = pattern.Matches(leftSide); 
            foreach (var a in matches1)
            {
                var splitStr = a.ToString().Split('x');
                string left = splitStr[0];
                string right = splitStr[1];
                if (left.Length == 0)
                {
                    list[int.Parse(right) - 1] = 1;
                    continue;
                }

                if (left.Length == 1 && left[0] == '-')
                {
                    list[int.Parse(right) - 1] = -1;
                    continue;
                }
                list[int.Parse(right) - 1] = int.Parse(left);

            }

            matrix[j, 3] = int.Parse(rightSide);
            for (int i = 0; i < n; i++)
            {
                matrix[j, i] = list[i];

            }

        }


        for (int i = 0; i < equals; i++)
        {
            for (int j = 0; j < n + 1; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

    }
}
