using NUnit.Framework;
using System;
using Module;
using BusinessLogic;


namespace NUnitTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Main_Diagonal_Array_A()
        {
            ModuleData.M = 3;
            ModuleData.A = new int[3, 3] { { 3, 8, 2 }, { 2, 9, 1 }, { 5, 6, 5 } };
            double result = 17;
            double actual = LogicBusiness.MainDiagonal();
            Assert.AreEqual(result, actual);
        }

        [Test]
        public void Main_Diagonal_Array_A_if_all_zero()
        {
            ModuleData.M = 3;
            ModuleData.A = new int[3, 3];
            double result = 0;
            double actual = LogicBusiness.MainDiagonal();
            Assert.AreEqual(result, actual);
        }

        [Test]
        public void Array_X_testing()
        {
            ModuleData.B = -12.6;
            ModuleData.S = 15;
            ModuleData.M = 5;
            ModuleData.C = new double[] { -5, -4.8, -4.6, -4.4, -4.2 };
            ModuleData.A = new int[5, 5] { { 3, 8, -3, -1, 6 }, { 2, 2, 0, 7, 6 }, { 3, -6, 10, -2, -10 }, { 4, 2, -4, 10, 9 }, { 6, 3, 3, 2, -10 } };
            double[] X = LogicBusiness.MassivX();
            double[] result = { -15.29, -11.93, -17.92, -10.95, -17.71 };
            Assert.AreEqual(result, X);
        }

        [Test]
        public void Array_y_testing()
        {
            ModuleData.M = 5;
            ModuleData.H = 0.2;
            ModuleData.X = new double[] { -15.29, -11.93, -17.92, -10.95, -17.71 };
            double[] Y = LogicBusiness.MassivY();
            double[] result = { -15.29, -11.15, -9.36, -9.26, -10.28, -11.93, -13.8, -15.55, -16.93, -17.75, -17.92, -17.41, -16.29, -14.68, -12.81, -10.95, -9.49, -8.87, -9.61, -12.33, -17.71 };
            Assert.AreEqual(result, Y);
        }

        [Test]
        public void Selection_Sort_Array_Y_testing()
        {
            ModuleData.Y = new double[] { -15.29, -11.15, -9.36, -9.26, -10.28, -11.93, -13.8, -15.55, -16.93, -17.75, -17.92, -17.41, -16.29, -14.68, -12.81, -10.95, -9.49, -8.87, -9.61, -12.33, -17.71 };
            double[] result = { -17.92, -17.75, -17.71, -17.41, -16.93, -16.29, -15.55, -15.29, -14.68, -13.8, -12.81, -12.33, -11.93, -11.15, -10.95, -10.28, -9.61, -9.49, -9.36, -9.26, -8.87 };
            double[] sort_y = LogicBusiness.SelectionSortMassivY();
            Assert.AreEqual(result, sort_y);
        }

        [Test]
        public void Selection_Sort_Array_Y_if_all_zero()
        {
            ModuleData.Y = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            double[] result = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            double[] sort_y = LogicBusiness.SelectionSortMassivY();
            Assert.AreEqual(result, sort_y);
        }

        [Test]
        public void Lagrange_Formula_testing()
        {
            double[] x = { 0.28, 0.4, 1.14 };
            double[] y1 = new double[Convert.ToInt32(Math.Round(((x.Length - 1) / 0.2) + 1))];
            double[] Y = new double[x.Length];
            for (int i = 0; i < Y.Length; i++)
            {
                Y[i] = i;
            }
            int j = 0;
            for (double t = 0; t <= x.Length - 1; t += 0.2)
            {
                y1[j] = Math.Round(LogicBusiness.LagrangeFormula(Y, x, t), 2);
                j++;
            }
            double[] y = { 0.28, 0.25, 0.25, 0.28, 0.33, 0.4, 0.5, 0.62, 0.77, 0.94, 1.14 };
            Assert.AreEqual(y, y1);
        }
    }
}