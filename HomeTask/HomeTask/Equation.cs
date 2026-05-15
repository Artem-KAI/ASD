namespace lvl1
{
    class Equation
    {
        double[][] A, L, U;
        double[] B;
        double[] x, y;
        int[] P;

        private void LUP()
        {
            int n = A.Length;

            // Ініціалізація зубчастих масивів
            L = new double[n][];
            U = new double[n][];
            double[][] A_copy = new double[n][];
            P = new int[n];

            for (int i = 0; i < n; i++)
            {
                L[i] = new double[n];
                U[i] = new double[n];
                A_copy[i] = (double[])this.A[i].Clone(); // Копіюємо рядки
                P[i] = i;
            }

            for (int i = 0; i < n; i++)
            {
                double max = 0;
                int pos = i;
                for (int k = i; k < n; k++)
                {
                    if (Math.Abs(A_copy[k][i]) > max)
                    {
                        max = Math.Abs(A_copy[k][i]);
                        pos = k;
                    }
                }

                int temp = P[i];
                P[i] = P[pos];
                P[pos] = temp;

                for (int k = 0; k < n; k++)
                {
                    double temp2 = A_copy[i][k];
                    A_copy[i][k] = A_copy[pos][k];
                    A_copy[pos][k] = temp2;
                }

                for (int k = i + 1; k < n; k++)
                {
                    A_copy[k][i] = A_copy[k][i] / A_copy[i][i];
                    for (int j = i + 1; j < n; j++)
                        A_copy[k][j] = A_copy[k][j] - A_copy[k][i] * A_copy[i][j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                    U[i][j] = A_copy[i][j];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (i == j)
                        L[i][j] = 1;
                    else
                        L[i][j] = A_copy[i][j];
                }
            }
        }

        private void SolveSystem()
        {
            int n = B.Length;
            x = new double[n];
            y = new double[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                    y[i] = y[i] + L[i][j] * y[j];
                y[i] = B[P[i]] - y[i];
            }

            for (int i = n - 1; i > -1; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < n; j++)
                    sum = sum + U[i][j] * x[j];
                x[i] = (y[i] - sum) / U[i][i];
            }
        }

        private void InputVariant()
        {
            // Жорстко задані дані твого варіанту з фото
            A = new double[][]
            {
                new double[] { -1, 2, -5, -1 },
                new double[] { 6, 2, -7, 2 },
                new double[] { 6, 4, 8, 5 },
                new double[] { -8, 9, -5, -2 }
            };
            B = new double[] { -14, -49, 37, 41 };
        }

        private void OutputMatrix(double[] mas, string title)
        {
            Console.WriteLine(title);
            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine($"{mas[i],5:F2}");
            }
            Console.WriteLine();
        }

        private void OutputMatrix(double[][] mas, string title)
        {
            Console.WriteLine(title);
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    Console.Write($"{mas[i][j],10:F2}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void OutputMatrix(int[] mas, string title)
        {
            Console.WriteLine(title);
            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine(mas[i]);
            }
            Console.WriteLine();
        }

        private void OutputEquations()
        {
            Console.WriteLine("System of equations: ");
            int n = B.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Додаємо знак "+", якщо число додатне
                    string sign = A[i][j] >= 0 ? "+" : "";
                    Console.Write($"{sign}{A[i][j]:F2}x{j + 1}  ");
                }
                Console.WriteLine($"= {B[i],7:F2}");
            }
            Console.WriteLine();
        }

        public void Execute()
        {
            InputVariant();
            OutputEquations();
            LUP();
            SolveSystem();
            OutputMatrix(L, "L matrix:");
            OutputMatrix(U, "U matrix:");
            OutputMatrix(P, "P matrix:");
            OutputMatrix(y, "y matrix:");
            OutputMatrix(x, "x matrix (Відповідь):");
        }
    }
}
