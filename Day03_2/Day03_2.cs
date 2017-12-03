using System;

namespace Day03_2
{
    class Day03_2
    {
        static void Main(string[] args)
        {
            const int input = 289326;
            var arr = new int[2048, 2048];
            var stepsInOneDirection = 1;
            var shouldStepsBeChanged = true;
            var direction = Direction.Right;
            var x = 0;
            var y = 0;
            const int offset = 1024;

            arr[x + offset, y + offset] = 1;
            while (true)
            {
                for (var step = 0; step < stepsInOneDirection; step++)
                {
                    var sumOfNeigbours = 0;
                    switch (direction)
                    {
                        case Direction.Up:
                            y++;
                            break;
                        case Direction.Down:
                            y--;
                            break;
                        case Direction.Left:
                            x--;
                            break;
                        case Direction.Right:
                            x++;
                            break;
                    }
                    //begining with right Element
                    sumOfNeigbours = arr[x + 1 + offset, y + offset] + arr[x + 1 + offset, y + 1 + offset] + arr[x + offset, y + 1 + offset] + arr[x - 1 + offset, y + 1 + offset] +
                                     arr[x - 1 + offset, y + offset] + arr[x - 1 + offset, y - 1 + offset] + arr[x + offset, y - 1 + offset] + arr[x + 1 + offset, y - 1 + offset];
                    if (sumOfNeigbours > input)
                    {
                        Console.WriteLine(sumOfNeigbours);
                        return;
                    }
                    arr[x + offset, y + offset] = sumOfNeigbours;
                }
                switch (direction)
                {
                    case Direction.Up:
                        direction = Direction.Left;
                        break;
                    case Direction.Down:
                        direction = Direction.Right;
                        break;
                    case Direction.Left:
                        direction = Direction.Down;
                        break;
                    case Direction.Right:
                        direction = Direction.Up;
                        break;
                }
                shouldStepsBeChanged = !shouldStepsBeChanged;
                if (shouldStepsBeChanged)
                {
                    stepsInOneDirection++;
                }
            }
        }
    }

    enum Direction
    {
        Right,
        Up,
        Left,
        Down
    }
}
