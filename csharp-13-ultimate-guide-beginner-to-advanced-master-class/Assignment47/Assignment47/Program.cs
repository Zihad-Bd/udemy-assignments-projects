using System;
using System.Collections.Generic;

namespace Assignment47
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<int> result = FindLargest(new List<List<int>>() {
new List<int>( ) { 67, 100, 23 },
new List<int>( ) { 80, 99, 750, 99 },
 new List<int>( ) { 888, 333, 9898 } });
            foreach (int i in result)
            {
                Console.WriteLine(i + " ");
            }
           
        }
        static List<int> FindLargest(List<List<int>> collections)
        {
            List<int> newList = new List<int>();
            for (int i = 0; i < collections.Count; i++)
            {
                int largest = int.MinValue;
                for (int j = 0; j < collections[i].Count; j++)
                {
                    if (collections[i][j] > largest)
                    {
                        largest = collections[i][j];
                    }
                }
                newList.Add(largest);
            }
            return newList;
        }
    }
}
