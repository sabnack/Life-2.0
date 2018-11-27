using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Cell
    {
        public int X;
        public int Y;
        public int State; //0 - Dead, 1 - Life Yellow , 2 - Dying Red, 3 - Born Green
        public int Generation;

        public Cell(int x, int y, int state)
        {
            X = x;
            Y = y;
            State = state;
            Generation = 0;
        }

        public void NextGeneration1step(Cell[] Field, int cellNumberInArray)
        {
            int LifeCount = 0;

            int x = cellNumberInArray / Program.FieldX;
            int y = cellNumberInArray % Program.FieldX;

            for (var x1 = x - 1; x1 < x + 2; x1++)
            {
                for (var y1 = y - 1; y1 < y + 2; y1++)
                {
                    if (x1 == x && y1 == y)
                        continue;

                    int tmpX, tmpY;
                    LoopBack(out tmpX, x1);
                    LoopBack(out tmpY, y1);
                    if (tmpX != 0)
                        tmpX *= Program.FieldX;

                    if (Field[tmpX + tmpY].State == 1 || Field[tmpX + tmpY].State == 2)
                        LifeCount++;
                }
            }

            switch (State)
            {
                case 0:
                    {
                        if (LifeCount == 3)
                            State = 3;
                        break;
                    }
                case 1:
                    {
                        if (LifeCount != 3 && LifeCount != 2)
                            State = 2;
                        break;
                    }
                case 2:
                    {
                        State = 0;
                        break;
                    }
                case 3:
                    {
                        State = 1;
                        break;
                    }
            }
        }

        public void NextGeneration2step()
        {
            switch (State)
            {
                case 2:
                    {
                        State = 0;
                        break;
                    }
                case 3:
                    {
                        State = 1;
                        break;
                    }
            }
        }

        private void LoopBack(out int tmpX, int x1)
        {
            switch (x1)
            {
                case -1:
                    {
                        tmpX = Program.FieldX - 1;
                        break;
                    }

                case Program.FieldX:
                    {
                        tmpX = 0;
                        break;
                    }

                default:
                    {
                        tmpX = x1;
                        break;
                    }
            }
        }
    }


}
