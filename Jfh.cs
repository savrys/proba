using System;

class MatrixOperations
{
    static void Main()
    {
        Console.WriteLine("Программа работы с матрицами");
        
        int[,] matrix1 = null;
        int[,] matrix2 = null;
        
        // Главный цикл программы - обеспечивает постоянную работу меню
        while (true)
        {
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("ГЛАВНОЕ МЕНЮ");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("1 - Создать матрицы");
            Console.WriteLine("2 - Вывести матрицы");
            Console.WriteLine("3 - Сложение матриц");
            Console.WriteLine("4 - Найти детерминант");
            Console.WriteLine("5 - Найти обратную матрицу");
            Console.WriteLine("0 - Выход из программы");
            Console.Write("Выберите действие: ");
            
            string choice = Console.ReadLine();
            
            // Обработка выбора пользователя из главного меню
            switch (choice)
            {
                case "1":
                    // Создание двух матриц с указанием их названий
                    matrix1 = CreateMatrix("первой");
                    matrix2 = CreateMatrix("второй");
                    break;
                    
                case "2":
                    // Проверка существования матриц перед выводом
                    if (CheckMatricesCreated(matrix1, matrix2))
                    {
                        PrintMatrix(matrix1, "Первая матрица");
                        PrintMatrix(matrix2, "Вторая матрица");
                    }
                    break;
                    
                case "3":
                    // Сложение матриц с проверкой возможности операции
                    if (CheckMatricesCreated(matrix1, matrix2))
                    {
                        AddMatrices(matrix1, matrix2);
                    }
                    break;
                    
                case "4":
                    // Отображение подменю для вычисления детерминанта
                    ShowDeterminantMenu(matrix1, matrix2);
                    break;
                    
                case "5":
                    // Отображение подменю для обратной матрицы
                    ShowInverseMenu(matrix1, matrix2);
                    break;
                    
                case "0":
                    Console.WriteLine("Выход из программы...");
                    return;
                    
                default:
                    Console.WriteLine("Неверный выбор! Попробуйте снова.");
                    break;
            }
        }
    }
    
    // Проверяет, созданы ли матрицы перед выполнением операций
    static bool CheckMatricesCreated(int[,] matrix1, int[,] matrix2)
    {
        if (matrix1 == null || matrix2 == null)
        {
            Console.WriteLine("Ошибка: Матрицы не созданы! Сначала выберите пункт 1.");
            return false;
        }
        return true;
    }
    
    // Меню для выбора матрицы для вычисления детерминанта
    static void ShowDeterminantMenu(int[,] matrix1, int[,] matrix2)
    {
        if (!CheckMatricesCreated(matrix1, matrix2)) return;
        
        Console.WriteLine("\n" + new string('-', 40));
        Console.WriteLine("ВЫЧИСЛЕНИЕ ДЕТЕРМИНАНТА");
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("1 - Детерминант первой матрицы");
        Console.WriteLine("2 - Детерминант второй матрицы");
        Console.WriteLine("3 - Детерминант обеих матриц");
        Console.Write("Выберите опцию: ");
        
        string choice = Console.ReadLine();
        
        // Обработка выбора в подменю детерминанта
        switch (choice)
        {
            case "1":
                CalculateAndShowDeterminant(matrix1, "первой");
                break;
                
            case "2":
                CalculateAndShowDeterminant(matrix2, "второй");
                break;
                
            case "3":
                CalculateAndShowDeterminant(matrix1, "первой");
                CalculateAndShowDeterminant(matrix2, "второй");
                break;
                
            default:
                Console.WriteLine("Неверный выбор!");
                break;
        }
    }
    
    // Меню для выбора матрицы для вычисления обратной матрицы
    static void ShowInverseMenu(int[,] matrix1, int[,] matrix2)
    {
        if (!CheckMatricesCreated(matrix1, matrix2)) return;
        
        Console.WriteLine("\n" + new string('-', 40));
        Console.WriteLine("ВЫЧИСЛЕНИЕ ОБРАТНОЙ МАТРИЦЫ");
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("1 - Обратная матрица для первой");
        Console.WriteLine("2 - Обратная матрица для второй");
        Console.WriteLine("3 - Обратные матрицы для обеих");
        Console.Write("Выберите опцию: ");
        
        string choice = Console.ReadLine();
        
        // Обработка выбора в подменю обратной матрицы
        switch (choice)
        {
            case "1":
                CalculateAndShowInverse(matrix1, "первой");
                break;
                
            case "2":
                CalculateAndShowInverse(matrix2, "второй");
                break;
                
            case "3":
                CalculateAndShowInverse(matrix1, "первой");
                CalculateAndShowInverse(matrix2, "второй");
                break;
                
            default:
                Console.WriteLine("Неверный выбор!");
                break;
        }
    }
    
    // Вычисляет и отображает детерминант с обработкой ошибок
    static void CalculateAndShowDeterminant(int[,] matrix, string matrixName)
    {
        try
        {
            // Преобразуем int[,] в double[,] для вычислений
            double[,] doubleMatrix = ConvertToDoubleMatrix(matrix);
            double determinant = CalculateDeterminant(doubleMatrix);
            Console.WriteLine($"\nДетерминант {matrixName} матрицы: {determinant:F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nОшибка для {matrixName} матрицы: {ex.Message}");
        }
    }
    
    // Вычисляет и отображает обратную матрицу с обработкой ошибок
    static void CalculateAndShowInverse(int[,] matrix, string matrixName)
    {
        try
        {
            // Преобразуем int[,] в double[,] для вычислений
            double[,] doubleMatrix = ConvertToDoubleMatrix(matrix);
            double[,] inverse = CalculateInverse(doubleMatrix);
            PrintDoubleMatrix(inverse, $"Обратная матрица для {matrixName} матрицы");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nОшибка для {matrixName} матрицы: {ex.Message}");
        }
    }
    
    // Преобразует матрицу int[,] в double[,] для математических операций
    static double[,] ConvertToDoubleMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double[,] result = new double[rows, cols];
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = (double)matrix[i, j];
            }
        }
        return result;
    }
    
    // Создает матрицу с указанным именем и настройками
    static int[,] CreateMatrix(string matrixName)
    {
        Console.WriteLine($"\nСоздание {matrixName} матрицы:");
        
        // Ввод размерности матрицы
        Console.Write("Введите количество строк (n): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов (m): ");
        int m = int.Parse(Console.ReadLine());

        // Создание двумерного массива для матрицы
        int[,] matrix = new int[n, m];

        // Выбор способа заполнения матрицы
        Console.WriteLine("Выберите способ заполнения матрицы:");
        Console.WriteLine("1 - Ввод с клавиатуры");
        Console.WriteLine("2 - Заполнение случайными числами");
        int choice = int.Parse(Console.ReadLine());

        // Обработка выбора способа заполнения
        switch (choice)
        {
            case 1:
                FillMatrixWithKeyboard(matrix);
                break;
            case 2:
                FillMatrixWithRandom(matrix);
                break;
            default:
                Console.WriteLine("Неверный выбор. Используется случайное заполнение.");
                FillMatrixWithRandom(matrix);
                break;
        }
        
        Console.WriteLine($"{matrixName} матрица создана успешно!");
        return matrix;
    }

    // Заполняет матрицу значениями, введенными с клавиатуры
    static void FillMatrixWithKeyboard(int[,] matrix)
    {
        // Двойной цикл для обхода всех элементов матрицы
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"Введите элемент [{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    // Заполняет матрицу случайными числами в заданном диапазоне
    static void FillMatrixWithRandom(int[,] matrix)
    {
        // Ввод границ диапазона для случайных чисел
        Console.Write("Введите нижнюю границу диапазона (a): ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Введите верхнюю границу диапазона (b): ");
        int b = int.Parse(Console.ReadLine());

        // Создание генератора случайных чисел
        Random random = new Random();

        // Заполнение матрицы случайными числами
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(a, b + 1);
            }
        }
    }

    // Выводит матрицу на экран с заголовком
    static void PrintMatrix(int[,] matrix, string title = "")
    {
        if (!string.IsNullOrEmpty(title))
            Console.WriteLine($"\n{title}:");
            
        // Форматированный вывод элементов матрицы
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j],5}");
            }
            Console.WriteLine();
        }
    }

    // Выводит матрицу типа double с форматированием
    static void PrintDoubleMatrix(double[,] matrix, string title = "")
    {
        if (!string.IsNullOrEmpty(title))
            Console.WriteLine($"\n{title}:");
            
        // Вывод вещественных чисел с двумя знаками после запятой
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j],10:F4}"); // Увеличил точность для обратной матрицы
            }
            Console.WriteLine();
        }
    }

    // Выполняет сложение двух матриц
    static void AddMatrices(int[,] matrix1, int[,] matrix2)
    {
        // Проверка совместимости размеров матриц для сложения
        if (matrix1.GetLength(0) != matrix2.GetLength(0) ||
            matrix1.GetLength(1) != matrix2.GetLength(1))
        {
            Console.WriteLine("Ошибка: Матрицы нельзя сложить - разные размеры!");
            return;
        }

        // Создание результирующей матрицы
        int[,] result = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
        
        // Поэлементное сложение матриц
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        
        Console.WriteLine("\nРезультат сложения матриц:");
        PrintMatrix(result);
    }

    // Проверяет, является ли матрица квадратной
    static bool IsSquareMatrix(double[,] matrix)
    {
        return matrix.GetLength(0) == matrix.GetLength(1);
    }

    // Вычисляет детерминант матрицы рекурсивным методом
    public static double CalculateDeterminant(double[,] matrix)
    {
        if (!IsSquareMatrix(matrix))
            throw new Exception("Матрица должна быть квадратной для вычисления детерминанта");

        int n = matrix.GetLength(0);
        
        // Базовые случаи для матриц 1x1 и 2x2
        if (n == 1) return matrix[0, 0];
        if (n == 2)
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

        // Рекурсивное вычисление для матриц большего размера
        double det = 0;
        for (int j = 0; j < n; j++)
        {
            // Разложение по первой строке с чередованием знаков
            double sign = (j % 2 == 0) ? 1 : -1;
            det += sign * matrix[0, j] * CalculateDeterminant(GetMinor(matrix, 0, j));
        }
        return det;
    }

    // Создает минор матрицы путем исключения строки и столбца
    private static double[,] GetMinor(double[,] matrix, int row, int col)
    {
        int n = matrix.GetLength(0);
        double[,] minor = new double[n - 1, n - 1];
        int r = 0;

        // Копирование элементов, исключая указанные строку и столбец
        for (int i = 0; i < n; i++)
        {
            if (i == row) continue;
            
            int c = 0;
            for (int j = 0; j < n; j++)
            {
                if (j == col) continue;
                minor[r, c] = matrix[i, j];
                c++;
            }
            r++;
        }
        return minor;
    }

    // Вычисляет обратную матрицу методом алгебраических дополнений
    public static double[,] CalculateInverse(double[,] matrix)
    {
        if (!IsSquareMatrix(matrix))
            throw new Exception("Обратная матрица существует только для квадратных матриц");

        // Вычисление определителя для проверки существования обратной матрицы
        double det = CalculateDeterminant(matrix);
        if (Math.Abs(det) < 0.0000001) // Используем маленькое число вместо точного нуля
            throw new Exception("Обратная матрица не существует (определитель равен нулю)");

        int n = matrix.GetLength(0);
        double[,] inverse = new double[n, n];

        // Вычисление матрицы алгебраических дополнений
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // Вычисление алгебраического дополнения
                double sign = ((i + j) % 2 == 0) ? 1 : -1;
                double cofactor = sign * CalculateDeterminant(GetMinor(matrix, i, j));
                
                // Транспонирование и деление на определитель
                inverse[j, i] = cofactor / det;
            }
        }

        return inverse;
    }
}
