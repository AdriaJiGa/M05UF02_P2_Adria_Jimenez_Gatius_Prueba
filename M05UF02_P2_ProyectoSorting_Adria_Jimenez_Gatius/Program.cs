using System;
using System.Diagnostics;

namespace M05UF02_P2_ProyectoSorting_Adria_Jimenez_Gatius
{
    public class SortingArray
    {
        public int[] array;
        public int[] arrayCreciente;
        public int[] arrayDecreciente;

        public SortingArray(int elements, Random random)
        {
            array = new int[elements];
            arrayCreciente = new int[elements];
            arrayDecreciente = new int[elements];
            for (int i = 0; i < elements; i++)
            {
                array[i] = random.Next();
            }
            Array.Copy(array, arrayCreciente, elements);
            Array.Sort(arrayCreciente); 
            Array.Copy(arrayCreciente, arrayDecreciente, elements);
            Array.Reverse(arrayDecreciente);


        }
        public void Sort(Action<int[]> func)
        {
            Console.WriteLine(func.Method.Name);
            Stopwatch time = new Stopwatch();
            int [] temp = new int[array.Length];
            Array.Copy (array, temp, array.Length);
            time.Start();
            func (temp);
            time.Stop();

            Console.WriteLine("Initial: " + time.ElapsedMilliseconds+"ms and "+ time.ElapsedTicks + " ticks.");
         
            time.Reset();

            time.Start ();
            func(temp);
            time.Stop ();

            Console.WriteLine("Increasing: " + time.ElapsedMilliseconds + "ms and "+ time.ElapsedTicks + " ticks.");
            time.Reset();
            Array.Reverse (temp);
            time.Start () ;
            func (temp);
            time.Stop ();
            Console.WriteLine("Decreasing: " + time.ElapsedMilliseconds + "ms and"+ time.ElapsedTicks + " ticks.");
            


        }
        public void BubbleSort(int[]array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j+1])
                    {
                        int temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;
                    }


                }
            }
        }
        public void BubbleSortEarlyExit(int[] array)
        {
            bool ordered = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[i])
                    {
                        ordered = false;
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }


                }
                if (ordered)
                    return;
            }

        }
        public void QuickSort(int [] array)
        {
            QuickSort(array,0, array.Length-1);
        }

        public void QuickSort(int[] array, int left, int right)
        {
            if (left<right)
            {
                int pivot = QuickSortPivot(array, left, right);
                QuickSort(array,left,pivot);
                QuickSort(array,pivot+1, right);

            }
   
        }
        public int QuickSortPivot(int[]array, int left, int right)
        {
            int pivot= array[(left+right)/2];
            while (true)
            {
                while (array[left]<pivot)
                {
                    left++;
                }
                while (array[right] > pivot)
                {
                    right--;
                }
                if (left>=right)
                {
                    return left;
                }
                else
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                }
            return 0;
            }
            
        }
        
        

          
       public void InsertionSort(int[] arr)
       {
          int n = arr.Length;
          for (int i = 1; i < n; ++i)
          {
            int key = arr[i];
            int j = i - 1;

            // Move elements of arr[0..i-1],
            // that are greater than key,
            // to one position ahead of
            // their current position
             while (j >= 0 && arr[j] > key)
             {
                 arr[j + 1] = arr[j];
                 j = j - 1;
             }
              arr[j + 1] = key;
          }
       }
        public void MergeSort(int[] arr, int left, int middle, int right)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = middle - left + 1;
            int n2 = right - middle;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[left + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[middle + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = left;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }

        }
        public void Msort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // Find the middle
                // point
                int m = l + (r - l) / 2;

                // Sort first and
                // second halves
                Msort(arr, l, m);
                Msort(arr, m + 1, r);

                // Merge the sorted halves
                MergeSort(arr, l, m, r);
            }









        }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many elements do you want?");
            int elements = int.Parse(Console.ReadLine());

            Console.WriteLine("What seed do you want to use?");
            int seed = int.Parse(Console.ReadLine());

            Random random = new Random(seed);
            SortingArray array= new SortingArray(elements, random);
            array.Sort(array.BubbleSort);
            array.Sort(array.BubbleSortEarlyExit);

            array.Sort(array.QuickSort);
            array.Sort(array.InsertionSort);
            

        }
    }
}
