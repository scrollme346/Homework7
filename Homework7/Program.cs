using System;

class Program
{
    static void Main()
    {
        int[] array = new int[30];
        Random random = new Random();

        // Заполняем массив случайными числами от 1 до 100.
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 101);
        }

        Console.WriteLine("Исходный массив:");
        PrintArray(array);
        Console.WriteLine();//Визуал френдли:)

        // Сортировка пузырьком
        BubbleSort(array);
        Console.WriteLine("Массив после сортировки пузырьком:");
        PrintArray(array);
        Console.WriteLine();

        // Сортировка выбором
        SelectionSort(array);
        Console.WriteLine("Массив после сортировки выбором:");
        PrintArray(array);
        Console.WriteLine();

        // Сортировка вставками
        InsertionSort(array);
        Console.WriteLine("Массив после сортировки вставками:");
        PrintArray(array);
        Console.WriteLine();

        // Рекурсивная сортировка вставками
        RecursiveInsertionSort(array, array.Length);
        Console.WriteLine("Массив после рекурсивной сортировки вставками:");
        PrintArray(array);
        Console.WriteLine();

        Console.ReadLine();
    }

    // Метод для вывода цифр
    static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    // Сортировка пузырьком
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                // Если текущий элемент больше следующего, меняем их местами
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // Сортировка выбором
    static void SelectionSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            // Находим минимальный элемент в оставшейся части массива
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            // Меняем найденный минимальный элемент с текущим элементом
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }

    // Сортировка вставками
    static void InsertionSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 1; i < n; ++i)
        {
            int key = arr[i];
            int j = i - 1;

            // Перемещаем элементы, большие чем key, на одну позицию вперед
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }

            // Вставляем key в правильную позицию
            arr[j + 1] = key;
        }
    }

    // Рекурсивная сортировка вставками
    static void RecursiveInsertionSort(int[] arr, int n)
    {
        // Если массив размером 1 то уже отсортирован
        if (n <= 1)
            return;

        // Сортируем подмассив без последнего элемента
        RecursiveInsertionSort(arr, n - 1);

        // Вставляем последний элемент в отсортированный подмассив
        int lastElement = arr[n - 1];
        int j = n - 2;

        // Перемещаем все элементы больше lastElement на одну позицию вперед
        while (j >= 0 && arr[j] > lastElement)
        {
            arr[j + 1] = arr[j];
            j--;
        }

        // Вставляем lastElement в правильную позицию
        arr[j + 1] = lastElement;
    }
}
