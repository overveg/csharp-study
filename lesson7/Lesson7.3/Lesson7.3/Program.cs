using System;
using System.Collections.Generic;
using System.Text;

namespace Level_1.Lesson_7
{
    class Cross
    {
        static int SIZE_X = 5;
        static int SIZE_Y = 5;
        static char[,] field = new char[SIZE_Y, SIZE_X];

        static int MaxWinningSequence = SIZE_X >= 4 ? 4 : 3;

        static char PLAYER_DOT = 'X';
        static char AI_DOT = 'O';
        static char EMPTY_DOT = '.';

        static Random random = new Random();

        //заполняем массив пустыми полями
        private static void InitField()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    field[i, j] = EMPTY_DOT;
                }
            }
        }

        //выводим заполненный массив полей
        private static void PrintField()
        {
            Console.Clear();
            Console.WriteLine("PrintField");
            Console.WriteLine("-------");
            for (int i = 0; i < SIZE_Y; i++)
            {
                Console.Write("|");
                for (int j = 0; j < SIZE_X; j++)
                {
                    Console.Write(field[i, j] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------");
        }

        private static void SetSym(int y, int x, char sym)
        {
            field[y, x] = sym;
        }

        private static bool IsCellValid(int y, int x)
        {
            if (x < 0 || y < 0 || x > SIZE_X - 1 || y > SIZE_Y - 1)
            {
                return false;
            }

            return field[y, x] == EMPTY_DOT;
        }

        private static bool IsFieldFull()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    if (field[i, j] == EMPTY_DOT)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void PlayerStep()
        {
            Console.WriteLine("PlayerStep");
            int x;
            int y;
            do
            {
                Console.WriteLine($"Введите координаты X Y (1-{SIZE_X})");
                x = Int32.Parse(Console.ReadLine()) - 1;
                y = Int32.Parse(Console.ReadLine()) - 1;
            } while (!IsCellValid(y, x));
            SetSym(y, x, PLAYER_DOT);
        }

        private static void AiStep()
        {
            Console.WriteLine("AiStep");
            int x;
            int y;
            do
            {
                x = random.Next(0, SIZE_X);
                y = random.Next(0, SIZE_Y);
            } while (!IsCellValid(y, x));
            SetSym(y, x, AI_DOT);
        }

        private static bool CheckWin(char sym)
        {
            return CheckWinHorizontal(sym) || CheckWinVertical(sym) || CheckWinMainDiag(sym) || CheckWinAdditionalDiag(sym);
        }
        private static bool CheckWinHorizontal(char sym)
        {
            int count = 1;
            //проверяем по горизонтали
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X - 1; j++)
                {
                    //если текущий символ равен следующему, записываем count
                    if (field[i, j] == field[i, j + 1] && field[i, j] == sym)
                    {
                        count++;
                    }
                    if (count == MaxWinningSequence)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private static bool CheckWinVertical(char sym)
        {
            int count = 1;
            //проверяем по вертикали
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X - 1; j++)
                {
                    if (field[j, i] == sym && field[j, i] == field[j + 1, i])
                    {
                        count++;
                    }
                    if (count == MaxWinningSequence) { return true; }
                }
            }
            return false;
        }

        private static bool CheckWinMainDiag(char sym)
        {
            //проверяем главные диагонали
            int count = 1;
            int maxIJ = SIZE_X - MaxWinningSequence;
            for (int i = 0; i <= maxIJ; i++)
            {
                for (int j = 0; j <= maxIJ; j++)
                {
                    count = 1;
                    for (int ic = i, jc = j; ic < (i + MaxWinningSequence - 1); ic++, jc++)
                    {
                        if (field[ic, jc] == sym && field[ic, jc] == field[ic + 1, jc + 1])
                        {
                            count++;
                        }
                    }
                    if (count == MaxWinningSequence) { return true; }
                }
            }

            return false;
        }
        public static bool isValid(int i, int j)
        {
            if (i < 0 || i >= SIZE_X || j >= SIZE_Y || j < 0)
            {
                return false;
            }
            return true;
        }

        private static bool CheckWinAdditionalDiag(char sym)
        {
            int R = SIZE_X;
            int C = SIZE_Y;
            //проверяем побочные диагонали с левого края
            for (int k = 0; k < R; k++)
            {
                int i = k - 1;
                int j = 1;
                int count = 1;
                while (isValid(i, j))
                {
                    if (field[i, j] == field[i + 1, j - 1] && field[i, j] == sym)
                    {
                        count++;
                        if (count == MaxWinningSequence) return true;
                    }
                    i--;
                    j++;
                }
            }
            //проверяем побочные диагонали по нижнему краю
            for (int k = 1; k < C; k++)
            {
                int i = R - 2;
                int j = k + 1;
                int count = 1;
                while (isValid(i, j))
                {
                    if (field[i, j] == field[i + 1, j - 1] && field[i, j] == sym)
                    {
                        count++;
                        if (count == MaxWinningSequence) return true;
                    }
                    i--;
                    j++;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            InitField();
            PrintField();
            while (true)
            {
                PlayerStep();
                PrintField();
                if (CheckWin(PLAYER_DOT))
                {
                    Console.WriteLine("Player Win!");
                    break;
                }
                if (IsFieldFull())
                {
                    Console.WriteLine("DRAW");
                    break;
                }
                AiStep();
                PrintField();
                if (CheckWin(AI_DOT))
                {
                    Console.WriteLine("AI Win!");
                    break;
                }
                if (IsFieldFull())
                {
                    Console.WriteLine("DRAW");
                    break;
                }
            }
        }
    }
}
