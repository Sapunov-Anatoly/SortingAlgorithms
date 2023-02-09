using System;
using System.Runtime.CompilerServices;

namespace SortingAlgorithms
{
    internal class Program
    {
        static int[] GenerateArr( int DataSetSize)
        {
            int[] DataSet = new int[DataSetSize];
            Random randomizer = new Random();

            for (int i = 0; i < DataSet.Length; i++)
            {
                DataSet[i] = randomizer.Next(0, 2000);
            }

            return DataSet;
        }

        static void PrintDataSet(int[] DataSet)
        {
            int count = 0;

            Console.Write("[");

            foreach (int value in DataSet)
            {
                count++;

                if (count != DataSet.Length)
                {
                    Console.Write(value + ", ");
                }
                else
                {
                    Console.Write(value);
                }
            }

            Console.WriteLine("]");
        }

        static int[] CloningDataSet(int[] DataSet,int DataSetSize)
        {
            int[] CloneDataSet = new int[DataSetSize];

            for(int i = 0; i < DataSetSize; i++)
            {
                CloneDataSet[i] = DataSet[i];
            }

            return CloneDataSet;
        }

        static void SwapValues(ref int a, ref int b)
        {
            int tempValue = a;
            a = b;
            b = tempValue;
        }

        static int[] BubbleSort(int[] DataSet)
        {
            Console.WriteLine("Алгоритм 'Сортировка пузырьком'");

            int swapCount = 0;

            for (int i = 0; i < DataSet.Length; i++)
            {
                for (int j = 0; j < DataSet.Length - 1 - i; j++)
                {
                    if (DataSet[j] > DataSet[j + 1])
                    {
                        SwapValues(ref DataSet[j], ref DataSet[j + 1]);
                        swapCount++;
                    }
                }
            }

            Console.WriteLine("Количество перестановок: " + swapCount);

            return DataSet;
        }

        static int[] CocktailSort(int[] DataSet)
        {
            Console.WriteLine("Алгоритм 'Шейкерная сортировка'");

            int swapCount = 0;

            for (int i = 0; i < DataSet.Length / 2; i++)
            {
                for (int j = i; j < DataSet.Length - i - 1; j++)
                {
                    if (DataSet[j] > DataSet[j + 1])
                    {
                        SwapValues(ref DataSet[j], ref DataSet[j + 1]);
                        swapCount++;
                    }
                }

                for (int j = DataSet.Length - 2 - i; j > i; j--)
                {
                    if (DataSet[j - 1] > DataSet[j])
                    {
                        SwapValues(ref DataSet[j - 1], ref DataSet[j]);
                        swapCount++;
                    }
                }
            }

            Console.WriteLine("Количество перестановок: " + swapCount);

            return DataSet;
        }

        static int[] CombSort(int[] DataSet)
        {
            Console.WriteLine("Алгоритм 'Сортировка расчёской'");

            int swapCount = 0;
            int currentStep = DataSet.Length - 1;

            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < DataSet.Length; i++)
                {
                    if (DataSet[i] > DataSet[i + currentStep])
                    {
                        SwapValues(ref DataSet[i], ref DataSet[i + currentStep]);
                        swapCount++;
                    }
                }

                currentStep = currentStep * 1000 / 1247;
            }

            for (int i = 0; i < DataSet.Length; i++)
            {
                for (int j = 0; j < DataSet.Length - 1 - i; j++)
                {
                    if (DataSet[j] > DataSet[j + 1])
                    {
                        SwapValues(ref DataSet[j], ref DataSet[j + 1]);
                        swapCount++;
                    }
                }
            }

            Console.WriteLine("Количество перестановок: " + swapCount);

            return DataSet;
        }

        static int[] InsertionSort(int[] DataSet)
        {
            Console.WriteLine("Алгоритм 'Сортировка вставками'");

            int swapCount = 0;
            int x;
            int j;

            for (int i = 1; i < DataSet.Length; i++)
            {
                x = DataSet[i];
                j = i;
                while (j > 0 && DataSet[j - 1] > x)
                {
                    SwapValues(ref DataSet[j], ref DataSet[j - 1]);
                    j -= 1;
                    swapCount++;
                }
                DataSet[j] = x;
            }

            Console.WriteLine("Количество перестановок: " + swapCount);

            return DataSet;
        }

        static int[] SelectionSort(int[] DataSet)
        {
            Console.WriteLine("Алгоритм 'Сортировка выбором'");

            int swapCount = 0;

            for (int i = 0; i < DataSet.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < DataSet.Length; j++)
                {
                    if (DataSet[j] < DataSet[min])
                    {
                        min = j;
                    }
                }
     
                SwapValues(ref DataSet[min], ref DataSet[i]);
                swapCount++;
            }

            Console.WriteLine("Количество перестановок: " + swapCount);

            return DataSet;
        }

        public class QuickSortClass
        {
            private static int swapCount = 0;

            public static int[] QuickSort(int[] DataSet, int leftIndex, int rightIndex)
            {
                int i = leftIndex;
                int j = rightIndex;
                int pivot = DataSet[leftIndex];

                while (i <= j)
                {
                    while (DataSet[i] < pivot)
                    {
                        i++;
                    }

                    while (DataSet[j] > pivot)
                    {
                        j--;
                    }
                    if (i <= j)
                    {
                        SwapValues(ref DataSet[i], ref DataSet[j]);
                        i++;
                        j--;
                        swapCount++;
                    }
                }

                if (leftIndex < j)
                {
                    QuickSort(DataSet, leftIndex, j);
                }

                if (i < rightIndex)
                {
                    QuickSort(DataSet, i, rightIndex);
                }

                return DataSet;
            }

            public static int[] QuickSortInterface(int[] DataSet)
            {
                Console.WriteLine("Алгоритм 'Быстрая сортировка'");

                DataSet = QuickSort(DataSet, 0, DataSet.Length - 1);

                Console.WriteLine("Количество перестановок: " + swapCount);

                return DataSet;
            }
        }

        public class MergeSortClass
        {
            static void Merge(int[] DataSet, int lowIndex, int middleIndex, int highIndex)
            {
                var left = lowIndex;
                var right = middleIndex + 1;
                var tempDataSet = new int[highIndex - lowIndex + 1];
                var index = 0;

                while ((left <= middleIndex) && (right <= highIndex))
                {
                    if (DataSet[left] < DataSet[right])
                    {
                        tempDataSet[index] = DataSet[left];
                        left++;
                    }
                    else
                    {
                        tempDataSet[index] = DataSet[right];
                        right++;
                    }

                    index++;
                }

                for (var i = left; i <= middleIndex; i++)
                {
                    tempDataSet[index] = DataSet[i];
                    index++;
                }

                for (var i = right; i <= highIndex; i++)
                {
                    tempDataSet[index] = DataSet[i];
                    index++;
                }

                for (var i = 0; i < tempDataSet.Length; i++)
                {
                    DataSet[lowIndex + i] = tempDataSet[i];
                }
            }

            public static int[] MergeSort(int[] DataSet, int lowIndex, int highIndex)
            {
                if (lowIndex < highIndex)
                {
                    var middleIndex = (lowIndex + highIndex) / 2;
                    MergeSort(DataSet, lowIndex, middleIndex);
                    MergeSort(DataSet, middleIndex + 1, highIndex);
                    Merge(DataSet, lowIndex, middleIndex, highIndex);
                }

                return DataSet;
            }

            public static int[] MergeSortInterface(int[] DataSet)
            {
                Console.WriteLine("Алгоритм 'Сортировка слиянием'");

                DataSet = MergeSort(DataSet, 0, DataSet.Length - 1);

                return DataSet;
            }
        }

        public class HeapSortClass
        {
            public static int[] HeapSort(int[] DataSet)
            {
                Console.WriteLine("Алгоритм 'Сортировка выбором'");

                int swapCount = 0;

                for (int i = DataSet.Length / 2 - 1; i >= 0; --i)
                {
                    long prev_i = i;
                    i = PyramidFormation(DataSet, i, DataSet.Length);
                    if (prev_i != i) ++i;
                }

                for (int j = DataSet.Length - 1; j > 0; --j)
                {
                    SwapValues(ref DataSet[0], ref DataSet[j]);
                    swapCount++;

                    int i = 0;
                    int prev_i = -1;

                    while (i != prev_i)
                    {
                        prev_i = i;
                        i = PyramidFormation(DataSet, i, j);
                    }
                }

                Console.WriteLine("Количество перестановок: " + swapCount);

                return DataSet;
            }

            static int PyramidFormation(int[] DataSet, int i, int N)
            {
                int imax;
                int buf;

                if ((2 * i + 2) < N)
                {
                    if (DataSet[2 * i + 1] < DataSet[2 * i + 2])
                    {
                        imax = 2 * i + 2;
                    }
                    else
                    {
                        imax = 2 * i + 1;
                    }
                }
                else
                {
                    imax = 2 * i + 1;
                }

                if (imax >= N)
                {
                    return i;
                }

                if (DataSet[i] < DataSet[imax])
                {
                    buf = DataSet[i];
                    DataSet[i] = DataSet[imax];
                    DataSet[imax] = buf;

                    if (imax < N / 2)
                    {
                        i = imax;
                    }
                }

                return i;
            }
        }

        static void PrintResultSort(int[] DataSet, int[] DataSetClone)
        {
            Console.Write("Исходный набор данных       : ");
            PrintDataSet(DataSetClone);
            Console.Write("Отсортированный набор данных: ");
            PrintDataSet(DataSet);
        }

        static void Main(string[] args)
        {
            int DataSetSize;

            while (true)
            {
                Console.WriteLine("Введите кол-во элементов для сортировки (от 2 до 10000):");
                Console.Write(">> ");
                DataSetSize = Convert.ToInt32(Console.ReadLine());
                if (DataSetSize < 2 || DataSetSize > 10000)
                {
                    Console.WriteLine("Введено неизвестное значение!");
                    continue;
                }
                else break;
            }

            int[] DataSet = new int[DataSetSize];
            int generateDataSetMode;

            while (true)
            {
                Console.WriteLine("\nВыберите способ генерации набора данных: ");
                Console.WriteLine("1 - Ручной ввод");
                Console.WriteLine("2 - Случайным образом");
                Console.Write(">> ");

                generateDataSetMode = Convert.ToInt32(Console.ReadLine());

                if (generateDataSetMode < 1 || generateDataSetMode > 2)
                {
                    Console.WriteLine("Введено неизвестное значение!");
                    continue;
                }
                else break;
            }

            switch (generateDataSetMode)
            {
                case 1:
                    Console.WriteLine("\nПоочередно введите данные: ");

                    for (int i = 0; i < DataSetSize; i++)
                    {
                        Console.Write(">> ");
                        try
                        {
                            int value = Convert.ToInt32(Console.ReadLine());
                            DataSet[i] = value;
                        }
                        catch
                        {
                            Console.WriteLine("Разрешено вводить только цифры!");
                            i--;
                        }
                    }

                    if (DataSet.Length < 50)
                    {
                        Console.WriteLine("\nВведенный набор данных: ");
                        PrintDataSet(DataSet);
                    }

                    break;

                case 2:
                    DataSet = GenerateArr(DataSetSize);

                    if (DataSet.Length < 50)
                    {
                        Console.WriteLine("\nСгенерированный набор данных: ");
                        PrintDataSet(DataSet);
                    }

                    break;
            }

            while (true)
            {
                int[] DataSetClone = CloningDataSet(DataSet, DataSetSize);

                Console.WriteLine("\nВыберите  алгоритм сортировки:");
                Console.WriteLine("1 - Сортировка пузырьком");
                Console.WriteLine("2 - Шейкерная сортировка");
                Console.WriteLine("3 - Сортировка расчёской");
                Console.WriteLine("4 - Сортировка вставками");
                Console.WriteLine("5 - Сортировка выбором");
                Console.WriteLine("6 - Быстрая сортировка");
                Console.WriteLine("7 - Сортировка слиянием");
                Console.WriteLine("8 - Пирамидальная сортировка");

                Console.Write(">> ");

                int algorythmSelection = Convert.ToInt32(Console.ReadLine());

                if (algorythmSelection < 1 || algorythmSelection > 8)
                {
                    Console.WriteLine("Введено неизвестное значение!");
                    continue;
                }

                Console.Write("\n");

                switch (algorythmSelection)
                {
                    case 1:
                        DataSet = BubbleSort(DataSet);
                        PrintResultSort(DataSet, DataSetClone);
                        break;

                    case 2:
                        DataSet = CocktailSort(DataSet);
                        PrintResultSort(DataSet, DataSetClone);
                        break;

                    case 3:
                        DataSet = CombSort(DataSet);
                        PrintResultSort(DataSet, DataSetClone);
                        break;

                    case 4:
                        DataSet = InsertionSort(DataSet);
                        PrintResultSort(DataSet, DataSetClone);
                        break;

                    case 5:
                        DataSet = SelectionSort(DataSet);
                        PrintResultSort(DataSet, DataSetClone);
                        break;

                    case 6:
                        DataSet = QuickSortClass.QuickSortInterface(DataSet);
                        PrintResultSort(DataSet, DataSetClone);
                        break;

                    case 7:
                        DataSet = MergeSortClass.MergeSortInterface(DataSet);
                        PrintResultSort(DataSet, DataSetClone);
                        break;

                    case 8:
                        DataSet = HeapSortClass.HeapSort(DataSet);
                        PrintResultSort(DataSet, DataSetClone);
                        break;
                }

                Console.WriteLine("\nВыбрать другой алгоритм? Y/n");

                string RepeatAlgorythmSelection;
                while (true)
                {
                    Console.Write(">> ");
                    RepeatAlgorythmSelection = Console.ReadLine();

                    if (RepeatAlgorythmSelection != "Y" && RepeatAlgorythmSelection != "y" && RepeatAlgorythmSelection != "N" && RepeatAlgorythmSelection != "n")
                    {
                        Console.WriteLine("Введено неизвестное значение!");
                        continue;
                    }
                    else break;
                }

                if (RepeatAlgorythmSelection == "Y" || RepeatAlgorythmSelection == "y")
                {
                    DataSet = DataSetClone;
                    continue;
                }
                else
                {
                    Console.WriteLine("Программа завершила свою работу");
                    break;
                }
            }
        }
    }
}
