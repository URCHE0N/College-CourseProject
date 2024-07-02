using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module;

namespace BusinessLogic
{
    public class LogicBusiness
    {
        //Метод заполнения массива A случайными числами
        public static int[,] RandomMassivA()
        {
            ModuleData.A = new int[ModuleData.M, ModuleData.M];
            Random r = new Random();
            for (int i = 0; i < ModuleData.M; i++)
            {
                for (int j = 0; j < ModuleData.M; j++)
                {
                    ModuleData.A[i, j] = r.Next(ModuleData.Astart, ModuleData.Aend + 1);
                }
            }
            return ModuleData.A;
        }
        //Метод вычисления главной диагонали в массиве A
        public static double MainDiagonal()
        {
            ModuleData.S = 0;
            for (int i = 0; i < ModuleData.M; i++)
            {
                for (int j = 0; j < ModuleData.M; j++)
                {
                    if (i == j)
                    {
                        ModuleData.S += ModuleData.A[i, j];
                    }
                }
            }
            return Math.Round(ModuleData.S, 2);
        }
        //Метод расчета массива C по арифметической прогрессии
        public static double[] MassivC()
        {
            ModuleData.C = new double[ModuleData.M];
            for (int i = 0; i < ModuleData.M; i++)
            {
                if (i == 0)
                {
                    ModuleData.C[i] = ModuleData.C1;
                }
                else
                {
                    ModuleData.C[i] = Math.Round(ModuleData.C[i - 1] + ModuleData.R, 2);
                }
            }

            return ModuleData.C;
        }
        //Метод расчета массива X по заданной формуле
        public static double[] MassivX()
        {
            ModuleData.X = new double[ModuleData.M];
            double sum = 0;
            for (int i = 0; i < ModuleData.M; i++)
            {
                if (i == 0)
                {
                    ModuleData.P = 1;
                }
                else
                {
                    ModuleData.P = ModuleData.X[i - 1];
                }
                for (int k = 0; k < ModuleData.M; k++)
                {
                    sum += (ModuleData.A[i, k] + ModuleData.C[k]) / (Math.Abs(ModuleData.A[i, k] - ModuleData.P) + 1);
                }
                ModuleData.X[i] = Math.Round((ModuleData.B + ModuleData.S) * ModuleData.C[i] + sum, 2);
                sum = 0;
            }
            return ModuleData.X;
        }
        //Метод расчета формулы Лагранжа
        public static double LagrangeFormula(double[] x, double[] func, double t)
        {
            int n = x.Length;
            double s = 0;
            for (int i = 0; i < n; i++)
            {
                double p = 1;
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        p = p * (t - x[j]) / (x[i] - x[j]);
                    }
                }
                s += func[i] * p;
            }
            return s;
        }
        //Метод расчета массива Y по формуле Лагранжа
        public static double[] MassivY()
        {
            int n = ModuleData.M;
            int m = (int)((n - 1) / ModuleData.H) + 1;
            double[] arg = new double[n];
            ModuleData.Y = new double[m];
            for (int i = 0; i < n; i++)
            {
                arg[i] = i;
            }
            int j = 0;
            for (double t = arg[0]; t < m; t += ModuleData.H)
            {
                if (j < m)
                {
                    ModuleData.Y[j] = Math.Round(LagrangeFormula(arg, ModuleData.X, t), 2);
                    j++;
                }
            }
            return ModuleData.Y;
        }
        //Метод сортировки массива Y методом простого выбора по возрастанию
        public static double[] SelectionSortMassivY()
        {
            int min;
            double temp;
            ModuleData.YSort = new double[ModuleData.Y.Length];
            for (int i = 0; i < ModuleData.Y.Length; i++)
            {
                ModuleData.YSort[i] = ModuleData.Y[i];
            }
            for (int i = 0; i < ModuleData.YSort.GetLength(0) - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < ModuleData.YSort.GetLength(0); j++)
                {
                    if (ModuleData.YSort[j] < ModuleData.YSort[min])
                    {
                        min = j;
                    }
                }
                temp = ModuleData.YSort[i];
                ModuleData.YSort[i] = Math.Round(ModuleData.YSort[min], 2);
                ModuleData.YSort[min] = temp;
            }
            return ModuleData.YSort;
        }
        //Метод создания и записи всех исходных данных в текстовый файл
        public static void RecordingAllDataTextFile()
        {
            using (StreamWriter writer = new StreamWriter("../AllData.txt", false))
            {
                writer.WriteLine($"Разность арифметической прогрессии (R) = {ModuleData.R}\n");
                writer.WriteLine($"Некая переменная (B) = {ModuleData.B}\n");
                writer.WriteLine($"Размерность массива A (M) = {ModuleData.M}\n");
                writer.WriteLine($"Шаг (H) = {ModuleData.H}\n");
                writer.WriteLine($"Сумма главной диагонали (S) = {ModuleData.S}\n");
                writer.WriteLine("Массив A\n");
                for (int i = 0; i < ModuleData.A.GetLength(0); i++)
                {
                    for (int j = 0; j < ModuleData.A.GetLength(1); j++)
                    {
                        writer.Write($"{ModuleData.A[i, j]}\t");
                    }
                    writer.WriteLine();
                }
                writer.WriteLine("\nМассив C\n");
                for (int i = 0; i < ModuleData.C.Length; i++)
                {
                    writer.Write($"{ModuleData.C[i]}\t");
                }
                writer.WriteLine();
                writer.WriteLine("\nМассив X\n");
                for (int i = 0; i < ModuleData.X.Length; i++)
                {
                    writer.Write($"{ModuleData.X[i],-15}");
                }
                writer.WriteLine();
                writer.WriteLine("\nМассив Y\n");
                for (int i = 0; i < ModuleData.Y.Length; i++)
                {
                    writer.Write($"{ModuleData.Y[i],-15}");
                }
                writer.WriteLine();
                writer.WriteLine("\nОтсортированный массив Y\n");
                for (int i = 0; i < ModuleData.YSort.Length; i++)
                {
                    writer.Write($"{ModuleData.YSort[i],-15}");
                }
            }
        }
    }
}