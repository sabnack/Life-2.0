using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        public const int FieldX = 60;//60; //60; 35
                                     //  const int FieldY = 50;//230;//180; 80

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Cell[] CellArray = new Cell[FieldX * FieldX];
            Random rand = new Random();

            int count = 0;
            for (var x = 0; x < FieldX; x++)
            {
                for (var y = 0; y < FieldX; y++)
                {
                    CellArray[count] = new Cell(x, y, rand.Next(0, 2));
                    count++;
                }
            }

            ////Glider
            //CellArray[1 * FieldX + 2].State = 1;
            //CellArray[2 * FieldX + 3].State = 1;
            //CellArray[3 * FieldX + 1].State = 1;
            //CellArray[3 * FieldX + 2].State = 1;
            //CellArray[3 * FieldX + 3].State = 1;

            ////Glider2
            //CellArray[2 * FieldX - 3].State = 1;
            //CellArray[3 * FieldX - 4].State = 1;
            //CellArray[4 * FieldX - 4].State = 1;
            //CellArray[4 * FieldX - 3].State = 1;
            //CellArray[4 * FieldX - 2].State = 1;

            ////Glider3
            //CellArray[(FieldX - 4) * FieldX + 1].State = 1;
            //CellArray[(FieldX - 4) * FieldX + 2].State = 1;
            //CellArray[(FieldX - 4) * FieldX + 3].State = 1;
            //CellArray[(FieldX - 3) * FieldX + 3].State = 1;
            //CellArray[(FieldX - 2) * FieldX + 2].State = 1;

            ////Glider4
            //CellArray[(FieldX - 3) * FieldX - 2].State = 1;
            //CellArray[(FieldX - 3) * FieldX - 3].State = 1;
            //CellArray[(FieldX - 3) * FieldX - 4].State = 1;
            //CellArray[(FieldX - 2) * FieldX - 4].State = 1;
            //CellArray[(FieldX - 1) * FieldX - 3].State = 1;

            Console.SetCursorPosition(0, 0);
            PrintField(CellArray);
            Console.ReadKey();

            while (true)
            {
                for (var x = 0; x < FieldX * FieldX; x++)
                {
                    CellArray[x].NextGeneration1step(CellArray, x);
                }

                Console.SetCursorPosition(0, 0);
                PrintField(CellArray);
                //    Thread.Sleep(200);

                for (var x = 0; x < FieldX * FieldX; x++)
                {
                    CellArray[x].NextGeneration2step();
                }

                Console.SetCursorPosition(0, 0);
                PrintField(CellArray);
                //   Thread.Sleep(200);
            }
        }

        static void PrintField(Cell[] Field)
        {
            Console.Write("┌");
            for (var i = 0; i < FieldX * 2; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┐");

            for (var count = 0; count < FieldX * FieldX; count++)
            {
                if (count % FieldX == 0 && count != 0) Console.Write("│\n│");
                if (count == 0) Console.Write("│");
                switch (Field[count].State)
                {
                    case 0:
                        {
                            Console.Write("  ");
                            break;
                        }
                    case 1:
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("■ ");
                            Console.ResetColor();
                            break;
                        }
                    case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("■ ");
                            Console.ResetColor();
                            break;
                        }
                    case 3:
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("■ ");
                            Console.ResetColor();
                            break;
                        }
                }
                if (count == FieldX * FieldX - 1) Console.Write("│");
            }

            Console.WriteLine();
            Console.Write("└");
            for (var i = 0; i < FieldX * 2; i++)
            {
                Console.Write("─");
            }
            Console.Write("┘");
        }
    }
}
