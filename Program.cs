using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Bai_tap5_DotNet_TTTH
{
    internal class Program
    {
        static void DisplayArray(int[] arr)
        {
            foreach (var element in arr)
            { 
                Write(element + "  ");

            }
            WriteLine();
        }

        static int[] InvertArray(int[] arr)
        {
            int[] tempArr = new int[arr.Length];
            for (int i = 0; i < tempArr.Length; i++)
            {
                tempArr[i] = arr[arr.Length - 1 - i];
            }
            return tempArr;
        }

        static int SumOfOdds(int[] arr)
        {
            int sum = 0;
            for (int i = 0;i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                    sum += arr[i];
            }
            return sum;
        }

        static int FindOccurancesElement(int[] arr, int value)
        {
            int temp = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == value)
                {
                    temp++;
                }
            }
            return temp;
        }

        static void PrintNon_duplicateElements(int[] arr)
        {
            WriteLine("Elements are not duplicated in the array:");
            for(int i = 0; i<arr.Length; i++)
            {
                if(FindOccurancesElement(arr, arr[i]) > 1)
                {
                    continue;
                }
                else
                {
                    Write($"\t{arr[i]}");
                }
            }
        }

        static void SplitArrayIntoOddsEvens(int[] arr, out int[] odds, out int[] evens)
        {
            odds = arr.Where(x => x % 2 != 0).ToArray();
            evens = arr.Where(x => x % 2 == 0).ToArray();
        }

        static void DesscendingArraySort(int[] arr)
        {
            for(int i = 0; i < arr.Length -1;i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if(arr[j] > arr[i])
                    {
                        int temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
          
            }
        }

        static int FindSencondMax(int[] arr)
        {
            DesscendingArraySort(arr);
            DisplayArray(arr);
            return arr[1];
        }

        static void Main(string[] args)
        {
            char continueAction;
            WriteLine("Enter the number of elements of array:");
            string input = Console.ReadLine();
            while (!int.TryParse(input, out int intNum) || intNum <= 0)
            {
                WriteLine("You have to enter the positive number:");
                input = Console.ReadLine();
            }
            int[] arr = new int[int.Parse(input)];
            WriteLine("Enter value of each:");
            for (int i = 0; i < arr.Length; i++)
            {
                Write($"Element {i + 1}: ");
                arr[i] = int.Parse(ReadLine());
            }
            do 
            {
                WriteLine();
                WriteLine("1: Display the entered array and the inverted array ");
                WriteLine("2: Calculate sum of odd elements in the array");
                WriteLine("3: Find the number of occurrences which is user entered in the array");
                WriteLine("4: Print out the non-duplicate elements in the array");
                WriteLine("5: Divide the array into even and odd arrays");
                WriteLine("6: Sort the array in descending array");
                WriteLine("7: Find the second largest in the array");
                WriteLine("Enter your option: ");
                string option = ReadLine();

                if (int.TryParse(option, out int value) && value >= 1 && value <= 7)
                { 
                    switch (value) 
                    {
                        case 1:
                            {
                                WriteLine("Your array is:");
                                DisplayArray(arr);
                                WriteLine("Your inverted array is:");
                                DisplayArray(InvertArray(arr)); ;
                            }
                            break;
                        case 2:
                            WriteLine($"The sum of odds elements: " + SumOfOdds(arr));
                            break;
                        case 3:
                            {
                                WriteLine("Enter value which you want to find: ");
                                int looking = int.Parse(ReadLine());
                                WriteLine($"Number of occurrences of the element entered by the user: " +
                                FindOccurancesElement(arr, looking));
                            }
                            break;
                        case 4:
                            PrintNon_duplicateElements(arr);
                            break;
                        case 5:
                            {
                                int[] oddsArr, evensArr;

                                SplitArrayIntoOddsEvens(arr, out oddsArr, out evensArr);

                                WriteLine("Evens array:");
                                DisplayArray(evensArr);
                                WriteLine("Odds array:");
                                DisplayArray(oddsArr);
                            }
                            break;
                        case 6:
                            {
                                WriteLine("Descending array:");
                                DesscendingArraySort(arr);
                                DisplayArray(arr);
                            }
                            break;
                        case 7:
                            {
                                int secondMax = FindSencondMax(arr);

                                WriteLine($"Second largest element in the array is {secondMax}");
                            }
                            break;
                        default: break;
                    }
                }
                else
                {
                    WriteLine("Invalid number. Please re-enter !");
                }
                WriteLine("\nDo you want continue, please press 'y' or 'Y' to continue");
                continueAction = ReadKey().KeyChar;
                
            } while (continueAction == 'y' || continueAction == 'Y');
            ReadKey();

        }
    }
}
