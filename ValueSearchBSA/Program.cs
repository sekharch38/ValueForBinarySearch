using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ValueSearchBSA
{
    class Program
    {
        static void Main(string[] args)
        {
            ArraryEmaple a = new ArraryEmaple();
            bool isNum = false;
            int sizeNum;

            Console.WriteLine("Enter the limit of array:");
            string sizeString = Console.ReadLine();
            isNum = Int32.TryParse(sizeString, out sizeNum);
            if (isNum)
            {
                int[] numArray = new int[sizeNum];
                Console.WriteLine("Enter array values (numeric only) in Unsorted order. ");
                for (int i = 0; i < sizeNum; i++)
                {
                    int tempValue;
                    string arrayItem = Console.ReadLine();
                    isNum = Int32.TryParse(arrayItem, out tempValue);
                    if (isNum)
                    {
                        numArray[i] = tempValue;
                    }
                    else
                    {
                        Console.WriteLine("You enters a non-numeric value!");
                        break;
                    }
                }
                int[] numArrar2 = (int[])numArray.Clone();
                Console.WriteLine("Enter search value (numeric only).");
                int searchNum;
                string searchString = Console.ReadLine();
                isNum = Int32.TryParse(searchString, out searchNum);
                if (isNum)
                {
                    //Binary Search Algorithm should not be applicable in UnsortedArray List. So that we have to be in Sorted List. For that only I have implemented Sort Array List Method.
                    int[] SortedArray = a.SortArry(numArray);
                    //Here I have Applied Binary Search Algorithm to Sorted Arrary List
                    int resultValue = a.BinarySearchArray(SortedArray, 0, SortedArray.Length - 1, searchNum);
                    if (resultValue != -1)
                    {
                        int Location = 0;
                        for (int i = 0; i < numArrar2.Length; i++)
                        {
                            if (numArrar2[i] == searchNum)
                            {
                                Location = i;
                            }
                        }
                        Console.WriteLine("Search successful");
                        Console.WriteLine("Value {0} found at location {1}\n", searchNum, Location + 1);
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("The Value: " + searchNum + " is not Found in the Un Sorted List !");
                    }
                }

                else
                {
                    Console.WriteLine("Search value must be numeric!");
                    Console.ReadLine();
                    return;
                }
            }
            else
            {
                Console.WriteLine("You must enter a numeric value!");
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
    public class ArraryEmaple
    {
        public int[] SortArry(int[] arr)
        {
            int temp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }


        public int BinarySearchArray(int[] arr, int start, int end, int val)
        {
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (arr[mid] == val)
                {
                    return mid;

                }
                else if (val > arr[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            return -1;
        }
    }
}
