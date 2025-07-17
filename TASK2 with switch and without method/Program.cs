using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        string choice;

        do
        {
            Console.WriteLine("\nP - Print numbers");
            Console.WriteLine("A - Add a number");
            Console.WriteLine("M - Display mean of the numbers");
            Console.WriteLine("S - Display the smallest number");
            Console.WriteLine("L - Display the largest number");
            Console.WriteLine("F - Find a number");
            Console.WriteLine("C - Clear the list");
            Console.WriteLine("Q - Quit");
            Console.Write("\nEnter your choice: ");
            choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "p":
                    if (GetListSize(numbers) == 0)
                        Console.WriteLine("[] - the list is empty");
                    else
                    {
                        Console.Write("[ ");
                        for (int i = 0; i < GetListSize(numbers); i++)
                            Console.Write(numbers[i] + " ");
                        Console.WriteLine("]");
                    }
                    break;

                case "a":
                    Console.Write("Enter an integer to add: ");
                    string input = Console.ReadLine();
                    int value;
                    bool valid = int.TryParse(input, out value);
                    if (valid)
                    {
                        bool exists = false;
                        int size = GetListSize(numbers);

                        for (int i = 0; i < size; i++)
                        {
                            if (numbers[i] == value)
                            {
                                exists = true;
                                break;
                            }
                        }
                        //                          *************الجزء بتاع البونص*****************   

                        if (exists)
                        {
                            Console.WriteLine("This number already exists in the list, not added.");
                        }
                        else
                        {
                            numbers.Insert(size, value);
                            Console.WriteLine($"{value} added");
                        }
                    }
                    else
                        Console.WriteLine("Invalid number!");
                    break;

                case "m":
                    if (GetListSize(numbers) == 0)
                        Console.WriteLine("Unable to calculate the mean - no data");
                    else
                    {
                        int total = 0;
                        int size = GetListSize(numbers);
                        for (int i = 0; i < size; i++)
                            total += numbers[i];
                        double mean = (double)total / size;
                        Console.WriteLine($"The mean is: {mean}");
                    }
                    break;

                case "s":
                    if (GetListSize(numbers) == 0)
                        Console.WriteLine("Unable to determine the smallest number - list is empty");
                    else
                    {
                        int smallest = numbers[0];
                        int size = GetListSize(numbers);
                        for (int i = 1; i < size; i++)
                        {
                            if (numbers[i] < smallest)
                                smallest = numbers[i];
                        }
                        Console.WriteLine($"The smallest number is {smallest}");
                    }
                    break;

                case "l":
                    if (GetListSize(numbers) == 0)
                        Console.WriteLine("Unable to determine the largest number - list is empty");
                    else
                    {
                        int largest = numbers[0];
                        int size = GetListSize(numbers);
                        for (int i = 1; i < size; i++)
                        {
                            if (numbers[i] > largest)
                                largest = numbers[i];
                        }
                        Console.WriteLine($"The largest number is {largest}");
                    }
                    break;

                case "f":
                    Console.Write("Enter number to find: ");
                    string findInput = Console.ReadLine();
                    int target;
                    if (int.TryParse(findInput, out target))
                    {
                        int foundIndex = -1;
                        int size = GetListSize(numbers);
                        for (int i = 0; i < size; i++)
                        {
                            if (numbers[i] == target)
                            {
                                foundIndex = i;
                                break;
                            }
                        }

                        if (foundIndex != -1)
                            Console.WriteLine($"{target} found at index {foundIndex}");
                        else
                            Console.WriteLine($"{target} not found in the list");
                    }
                    else
                        Console.WriteLine("Invalid number!");
                    break;

                case "c":
                    int n = GetListSize(numbers);
                    if (n == 0)
                        Console.WriteLine("The list is already empty");
                    else
                    {
                        for (int i = n - 1; i >= 0; i--)
                            numbers.RemoveAt(i);
                        Console.WriteLine("List cleared.");
                    }
                    break;

                case "q":
                    Console.WriteLine("Goodbye");
                    break;

                default:
                    Console.WriteLine("Unknown selection, please try again");
                    break;
            }

        } while (choice != "q");
    }


    static int GetListSize(List<int> list)
    {
        int size = 0;
        try
        {
            while (true)
            {
                int x = list[size];
                size++;
            }
        }
        catch
        {
            return size;
        }
    }
}
