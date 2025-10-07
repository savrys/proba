using System;

class MatrixCalculator
{
    static void Main()
    {
        Console.WriteLine("=== КАЛЬКУЛЯТОР МАТРИЦ ===");
        
        // Основной цикл программы
        while (true)
        {
            // Вывод меню операций
            Console.WriteLine("\nВыберите операцию:");
            Console.WriteLine("1 - Создание и заполнение матрицы");
            Console.WriteLine("2 - Нахождение детерминанта матрицы");
            Console.WriteLine("3 - Нахождение обратной матрицы");
            Console.WriteLine("0 - Выход из программы");
            
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();
            
            // Обработка выбора пользователя
            switch (choice)
            {
                case "1":
                    CreateAndFillMatrix();
                    break;
                case "2":
                    CalculateDeterminant();
                    break;
                case "3":
                    CalculateInverseMatrix();
                    break;
                case "0":
                    Console.WriteLine("Программа завершена.");
                    return;
                default:
                    Console.WriteLine("Неверный выбор! Попробуйте снова.");
                    break;
            }
        }
    }
    
    // Метод для создания и заполнения матрицы
    static void CreateAndFillMatrix()
    {
        Console.WriteLine("\n--- СОЗДАНИЕ МАТРИЦЫ ---");
        
        // Запрос размеров матрицы
        Console.Write("Введите количество строк (n): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов (m): ");
        int m = int.Parse(Console.ReadLine());
        
        // Создание матрицы
        double[,] matrix = new double[n, m];
        
        // Выбор способа заполнения
        Console.WriteLine("\nВыберите способ заполнения матрицы:");
        Console.WriteLine("1 - Ввод с клавиатуры");
        Console.WriteLine("2 - Заполнение случайными числами");
        Console.Write("Ваш выбор: ");
        int fillChoice = int.Parse(Console.ReadLine());
        
        // Заполнение матрицы выбранным способом
        if (fillChoice == 1)
        {
            FillMatrixWithKeyboard(matrix);
        }
        else
        {
            FillMatrixWithRandom(matrix);
        }
        
        // Вывод созданной матрицы
        Console.WriteLine("\nСозданная матрица:");
        PrintMatrix(matrix);
    }
    
    // Метод для заполнения матрицы с клавиатуры
    static void FillMatrixWithKeyboard(double[,] matrix)
    {
        Console.WriteLine("\nЗаполнение матрицы с клавиатуры:");
        
        // Поэлементный ввод матрицы
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"Введите элемент [{i},{j}]: ");
                matrix[i, j] = double.Parse(Console.ReadLine());
            }
        }
    }
    
    // Метод для заполнения матрицы случайными числами
    static void FillMatrixWithRandom(double[,] matrix)
    {
        Console.WriteLine("\nЗаполнение матрицы случайными числами:");
        
        // Запрос диапазона случайных чисел
        Console.Write("Введите нижнюю границу диапазона (a): ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Введите верхнюю границу диапазона (b): ");
        int b = int.Parse(Console.ReadLine());
        
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
    
    // Метод для вычисления детерминанта
    static void CalculateDeterminant()
    {
        Console.WriteLine("\n--- ВЫЧИСЛЕНИЕ ДЕТЕРМИНАНТА ---");
        
        // Создание матрицы
        Console.WriteLine("Создайте матрицу для вычисления детерминанта:");
        double[,] matrix = CreateSingleMatrix();
        
        // Проверка на квадратность матрицы
        if (!IsSquareMatrix(matrix))
        {
            Console.WriteLine("Ошибка: Детерминант можно вычислить только для квадратной матрицы!");
            return;
        }
        
        try
        {
            // Вычисление и вывод детерминанта
            double determinant = CalculateDeterminantRecursive(matrix);
            Console.WriteLine($"\nДетерминант матрицы: {determinant:F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при вычислении детерминанта: {ex.Message}");
        }
    }
    
    // Метод для вычисления обратной матрицы
    static void CalculateInverseMatrix()
    {
        Console.WriteLine("\n--- ВЫЧИСЛЕНИЕ ОБРАТНОЙ МАТРИЦЫ ---");
        
        // Создание матрицы
        Console.WriteLine("Создайте матрицу для вычисления обратной матрицы:");
        double[,] matrix = CreateSingleMatrix();
        
        // Проверка на квадратность матрицы
        if (!IsSquareMatrix(matrix))
        {
            Console.WriteLine("Ошибка: Обратная матрица существует только для квадратной матрицы!");
            return;
        }
        
        try
        {
            // Вычисление обратной матрицы
            double[,] inverseMatrix = CalculateInverse(matrix);
            
            // Вывод результата
            Console.WriteLine("\nИсходная матрица:");
            PrintMatrix(matrix);
            Console.WriteLine("\nОбратная матрица:");
            PrintMatrix(inverseMatrix);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
    
    // Метод для создания одной матрицы
    static double[,] CreateSingleMatrix()
    {
        // Запрос размеров матрицы
        Console.Write("Введите количество строк (n): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов (m): ");
        int m = int.Parse(Console.ReadLine());
        
        double[,] matrix = new double[n, m];
        
        // Выбор способа заполнения
        Console.WriteLine("Выберите способ заполнения матрицы:");
        Console.WriteLine("1 - Ввод с клавиатуры");
        Console.WriteLine("2 - Заполнение случайными числами");
        Console.Write("Ваш выбор: ");
        int choice = int.Parse(Console.ReadLine());
        
        // Заполнение матрицы
        if (choice == 1)
        {
            FillMatrixWithKeyboard(matrix);
        }
        else
        {
            FillMatrixWithRandom(matrix);
        }
        
        // Вывод созданной матрицы
        Console.WriteLine("\nСозданная матрица:");
        PrintMatrix(matrix);
        
        return matrix;
    }
    
    // Метод для вывода матрицы на экран
    static void PrintMatrix(double[,] matrix)
    {
        // Вывод каждого элемента матрицы
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j],8:F2}");
            }
            Console.WriteLine();
        }
    }
    
    // Проверка является ли матрица квадратной
    static bool IsSquareMatrix(double[,] matrix)
    {
        return matrix.GetLength(0) == matrix.GetLength(1);
    }
    
    // Рекурсивный метод вычисления детерминанта
    static double CalculateDeterminantRecursive(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        
        // Базовые случаи рекурсии
        if (n == 1) return matrix[0, 0];
        if (n == 2) return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        
        double determinant = 0;
        
        // Разложение по первой строке
        for (int j = 0; j < n; j++)
        {
            // Вычисление минора и рекурсивный вызов
            double[,] minor = GetMinor(matrix, 0, j);
            double minorDet = CalculateDeterminantRecursive(minor);
            
            // Учет знака и добавление к детерминанту
            determinant += (j % 2 == 0 ? 1 : -1) * matrix[0, j] * minorDet;
        }
        
        return determinant;
    }
    
    // Метод для получения минора матрицы
    static double[,] GetMinor(double[,] matrix, int rowToRemove, int colToRemove)
    {
        int n = matrix.GetLength(0);
        double[,] minor = new double[n - 1, n - 1];
        
        int minorRow = 0;
        
        // Построение минора исключением строки и столбца
        for (int i = 0; i < n; i++)
        {
            if (i == rowToRemove) continue;
            
            int minorCol = 0;
            for (int j = 0; j < n; j++)
            {
                if (j == colToRemove) continue;
                
                minor[minorRow, minorCol] = matrix[i, j];
                minorCol++;
            }
            minorRow++;
        }
        
        return minor;
    }
    
    // Метод для вычисления обратной матрицы
    static double[,] CalculateInverse(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        
        // Вычисление детерминанта
        double determinant = CalculateDeterminantRecursive(matrix);
        
        // Проверка на вырожденность матрицы
        if (Math.Abs(determinant) < 1e-10)
        {
            throw new Exception("Обратная матрица не существует (определитель равен нулю)");
        }
        
        // Создание матрицы алгебраических дополнений
        double[,] adjugate = new double[n, n];
        
        // Вычисление матрицы алгебраических дополнений
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // Получение минора и вычисление его детерминанта
                double[,] minor = GetMinor(matrix, i, j);
                double minorDet = CalculateDeterminantRecursive(minor);
                
                // Учет знака и деление на детерминант
                adjugate[j, i] = ((i + j) % 2 == 0 ? 1 : -1) * minorDet / determinant;
            }
        }
        
        return adjugate;
    }
}
