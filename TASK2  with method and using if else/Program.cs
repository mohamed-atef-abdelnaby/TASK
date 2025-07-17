using System;
using System.Collections.Generic;

namespace ListManagerIfElseMethod
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int>();
            string choice = "";

            while (true)
            {
                ShowMenu();
                choice = Console.ReadLine().ToLower();

                if (choice == "q")
                {
                    Console.WriteLine("Goodbye");
                    break;
                }
                else if (choice == "p")
                    PrintList(numbers);
                else if (choice == "a")
                    AddNumber(numbers);
                else if (choice == "m")
                    DisplayMean(numbers);
                else if (choice == "s")
                    DisplaySmallest(numbers);
                else if (choice == "l")
                    DisplayLargest(numbers);
                else if (choice == "f")
                    SearchNumber(numbers);
                else if (choice == "c")
                    ClearList(numbers);
                else
                    Console.WriteLine("Unknown selection, please try again.");
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("P - Print numbers");
            Console.WriteLine("A - Add a number");
            Console.WriteLine("M - Display mean of the numbers");
            Console.WriteLine("S - Display the smallest number");
            Console.WriteLine("L - Display the largest number");
            Console.WriteLine("F - Find a number in the list");
            Console.WriteLine("C - Clear the list");
            Console.WriteLine("Q - Quit");
            Console.Write("Enter your choice: ");
        }

        static void PrintList(List<int> list)
        {
            if (GetListSize(list) == 0)
                Console.WriteLine("[] - the list is empty");
            else
            {
                Console.Write("[ ");
                for (int i = 0; i < GetListSize(list); i++)
                    Console.Write(list[i] + " ");
                Console.WriteLine("]");
            }
        }

        static void AddNumber(List<int> list)
        {
            Console.Write("Enter an integer to add: ");
            string input = Console.ReadLine();
            int value;
            if (int.TryParse(input, out value))
            {
                bool exists = false;
                int size = GetListSize(list);
                for (int i = 0; i < size; i++)
                {
                    if (list[i] == value)
                    {
                        exists = true;
                        break;
                    }
                }
                if (exists)
                    Console.WriteLine("This number already exists in the list, not added.");
                else
                {
                    list.Insert(size, value);
                    Console.WriteLine($"{value} added");
                }
            }
            else
                Console.WriteLine("Invalid input.");
        }

        static void DisplayMean(List<int> list)
        {
            int size = GetListSize(list);
            if (size == 0)
                Console.WriteLine("Unable to calculate the mean - no data");
            else
            {
                int total = 0;
                for (int i = 0; i < size; i++)
                    total += list[i];
                double mean = (double)total / size;
                Console.WriteLine($"The mean is {mean}");
            }
        }

        static void DisplaySmallest(List<int> list)
        {
            int size = GetListSize(list);
            if (size == 0)
            {
                Console.WriteLine("Unable to determine the smallest number - list is empty");
                return;
            }
            int min = list[0];
            for (int i = 1; i < size; i++)
                if (list[i] < min)
                    min = list[i];
            Console.WriteLine($"The smallest number is {min}");
        }

        static void DisplayLargest(List<int> list)
        {
            int size = GetListSize(list);
            if (size == 0)
            {
                Console.WriteLine("Unable to determine the largest number - list is empty");
                return;
            }
            int max = list[0];
            for (int i = 1; i < size; i++)
                if (list[i] > max)
                    max = list[i];
            Console.WriteLine($"The largest number is {max}");
        }

        static void SearchNumber(List<int> list)
        {
            Console.Write("Enter a number to search: ");
            string input = Console.ReadLine();
            int target;
            if (int.TryParse(input, out target))
            {
                int size = GetListSize(list);
                bool found = false;
                for (int i = 0; i < size; i++)
                {
                    if (list[i] == target)
                    {
                        Console.WriteLine($"{target} found at index {i}");
                        found = true;
                        break;
                    }
                }
                if (!found)
                    Console.WriteLine($"{target} not found in the list.");
            }
            else
                Console.WriteLine("Invalid input.");
        }

        static void ClearList(List<int> list)
        {
            int size = GetListSize(list);
            for (int i = size - 1; i >= 0; i--)
                list.RemoveAt(i);
            Console.WriteLine("List cleared.");
        }

        static int GetListSize(List<int> list)
        {
            int count = 0;
            try
            {
                while (true)
                {
                    int temp = list[count];
                    count++;
                }
            }
            catch
            {

            }
            return count;
        }
    }
}
