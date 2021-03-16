// Decompiled with JetBrains decompiler
// Type: Level_1.Lesson_7.Cross
// Assembly: Lesson7.3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6685D32A-58B6-4422-9B0D-3C1A4A1072AF
// Assembly location: C:\Users\doroncheva\Source\Repos\overveg\csharp-study\lesson7\Lesson7.3\Lesson7.3\bin\Debug\netcoreapp3.1\Lesson7.3.dll

using System;

namespace Level_1.Lesson_7
{
    internal class Cross
    {
        private static int SIZE_X = 5;
        private static int SIZE_Y = 5;
        private static char[,] field = new char[Cross.SIZE_Y, Cross.SIZE_X];
        private static int MaxWinningSequence = Cross.SIZE_X >= 4 ? 4 : 3;
        private static char PLAYER_DOT = 'X';
        private static char AI_DOT = 'O';
        private static char EMPTY_DOT = '.';
        private static Random random = new Random();

        private static void InitField()
        {
            for (int index1 = 0; index1 < Cross.SIZE_Y; ++index1)
            {
                for (int index2 = 0; index2 < Cross.SIZE_X; ++index2)
                    Cross.field[index1, index2] = Cross.EMPTY_DOT;
            }
        }

        private static void PrintField()
        {
            Console.Clear();
            Console.WriteLine(nameof(PrintField));
            Console.WriteLine("-------");
            for (int index1 = 0; index1 < Cross.SIZE_Y; ++index1)
            {
                Console.Write("|");
                for (int index2 = 0; index2 < Cross.SIZE_X; ++index2)
                    Console.Write(Cross.field[index1, index2].ToString() + "|");
                Console.WriteLine();
            }
            Console.WriteLine("-------");
        }

        private static void SetSym(int y, int x, char sym) => Cross.field[y, x] = sym;

        private static bool IsCellValid(int y, int x) => x >= 0 && y >= 0 && x <= Cross.SIZE_X - 1 && y <= Cross.SIZE_Y - 1 && (int)Cross.field[y, x] == (int)Cross.EMPTY_DOT;

        private static bool IsFieldFull()
        {
            for (int index1 = 0; index1 < Cross.SIZE_Y; ++index1)
            {
                for (int index2 = 0; index2 < Cross.SIZE_X; ++index2)
                {
                    if ((int)Cross.field[index1, index2] == (int)Cross.EMPTY_DOT)
                        return false;
                }
            }
            return true;
        }

        private static void PlayerStep()
        {
            Console.WriteLine(nameof(PlayerStep));
            int x;
            int y;
            do
            {
                Console.WriteLine(string.Format("Введите координаты X Y (1-{0})", (object)Cross.SIZE_X));
                x = int.Parse(Console.ReadLine()) - 1;
                y = int.Parse(Console.ReadLine()) - 1;
            }
            while (!Cross.IsCellValid(y, x));
            Cross.SetSym(y, x, Cross.PLAYER_DOT);
        }

        private static void AiStep()
        {
            Console.WriteLine(nameof(AiStep));
            int x;
            int y;
            do
            {
                x = Cross.random.Next(0, Cross.SIZE_X);
                y = Cross.random.Next(0, Cross.SIZE_Y);
            }
            while (!Cross.IsCellValid(y, x));
            Cross.SetSym(y, x, Cross.AI_DOT);
        }

        private static bool CheckWin(char sym) => Cross.CheckWinHorizontal(sym) || Cross.CheckWinVertical(sym) || Cross.CheckWinMainDiag(sym) || Cross.CheckWinAdditionalDiag(sym);

        private static bool CheckWinHorizontal(char sym)
        {
            int num = 1;
            for (int index1 = 0; index1 < Cross.SIZE_Y; ++index1)
            {
                for (int index2 = 0; index2 < Cross.SIZE_X - 1; ++index2)
                {
                    if ((int)Cross.field[index1, index2] == (int)Cross.field[index1, index2 + 1] && (int)Cross.field[index1, index2] == (int)sym)
                        ++num;
                    if (num == Cross.MaxWinningSequence)
                        return true;
                }
            }
            return false;
        }

        private static bool CheckWinVertical(char sym)
        {
            int num = 1;
            for (int index1 = 0; index1 < Cross.SIZE_Y; ++index1)
            {
                for (int index2 = 0; index2 < Cross.SIZE_X - 1; ++index2)
                {
                    if ((int)Cross.field[index2, index1] == (int)sym && (int)Cross.field[index2, index1] == (int)Cross.field[index2 + 1, index1])
                        ++num;
                    if (num == Cross.MaxWinningSequence)
                        return true;
                }
            }
            return false;
        }

        private static bool CheckWinMainDiag(char sym)
        {
            int num1 = Cross.SIZE_X - Cross.MaxWinningSequence;
            for (int index1 = 0; index1 <= num1; ++index1)
            {
                for (int index2 = 0; index2 <= num1; ++index2)
                {
                    int num2 = 1;
                    int index3 = index1;
                    int index4 = index2;
                    while (index3 < index1 + Cross.MaxWinningSequence - 1)
                    {
                        if ((int)Cross.field[index3, index4] == (int)sym && (int)Cross.field[index3, index4] == (int)Cross.field[index3 + 1, index4 + 1])
                            ++num2;
                        ++index3;
                        ++index4;
                    }
                    if (num2 == Cross.MaxWinningSequence)
                        return true;
                }
            }
            return false;
        }

        public static bool isValid(int i, int j) => i >= 0 && i < Cross.SIZE_X && j < Cross.SIZE_Y && j >= 0;

        private static bool CheckWinAdditionalDiag(char sym)
        {
            int sizeX = Cross.SIZE_X;
            int sizeY = Cross.SIZE_Y;
            for (int index = 0; index < sizeX; ++index)
            {
                int i = index - 1;
                int j = 1;
                int num = 1;
                for (; Cross.isValid(i, j); ++j)
                {
                    if ((int)Cross.field[i, j] == (int)Cross.field[i + 1, j - 1] && (int)Cross.field[i, j] == (int)sym)
                    {
                        ++num;
                        if (num == Cross.MaxWinningSequence)
                            return true;
                    }
                    --i;
                }
            }
            for (int index = 1; index < sizeY; ++index)
            {
                int i = sizeX - 2;
                int j = index + 1;
                int num = 1;
                for (; Cross.isValid(i, j); ++j)
                {
                    if ((int)Cross.field[i, j] == (int)Cross.field[i + 1, j - 1] && (int)Cross.field[i, j] == (int)sym)
                    {
                        ++num;
                        if (num == Cross.MaxWinningSequence)
                            return true;
                    }
                    --i;
                }
            }
            return false;
        }

        private static void Main(string[] args)
        {
            Cross.InitField();
            Cross.PrintField();
            do
            {
                Cross.PlayerStep();
                Cross.PrintField();
                if (!Cross.CheckWin(Cross.PLAYER_DOT))
                {
                    if (!Cross.IsFieldFull())
                    {
                        Cross.AiStep();
                        Cross.PrintField();
                        if (Cross.CheckWin(Cross.AI_DOT))
                            goto label_5;
                    }
                    else
                        goto label_3;
                }
                else
                    goto label_1;
            }
            while (!Cross.IsFieldFull());
            goto label_7;
        label_1:
            Console.WriteLine("DotPeek Win!");
            return;
        label_3:
            Console.WriteLine("DRAW");
            return;
        label_5:
            Console.WriteLine("AI Win!");
            return;
        label_7:
            Console.WriteLine("DRAW");
        }
    }
}
