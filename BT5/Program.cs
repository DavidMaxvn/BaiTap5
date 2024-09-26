using System;
using System.Collections.Generic;

namespace BT5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhập số phần tử của mảng: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhập phần tử thứ {0}: ", i + 1);
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nMảng vừa nhập là: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + ", ");
            }

            // In mảng dữ liệu theo chiều ngược lại
            Console.WriteLine("\nMảng sau khi đảo ngược là: ");
            for (int i = n - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + ", ");
            }

            // Gọi hàm để tìm và hiển thị các phần tử trùng nhau
            List<string> duplicates = FindDuplicateElements(arr, n);

            // In ra kết quả
            Console.WriteLine("\nCác phần tử trùng nhau trong mảng là: ");
            foreach (var item in duplicates)
            {
                Console.Write(item);
            }

            // In các phần tử duy nhất trong mảng
            Console.WriteLine("\nCác phần tử duy nhất trong mảng là: ");
            PrintUniqueElements(arr, n);

            Console.WriteLine("\nCác phần tử chẵn trong mảng là: ");
            for (int i = 0; i < n; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    Console.Write(arr[i] + " ");
                }
            }

            Console.WriteLine("\nCác phần tử lẻ trong mảng là: ");
            for (int i = 0; i < n; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    Console.Write(arr[i] + " ");
                }
            }

            // Lưu mảng ban đầu vào một mảng khác
            int[] originalArray = (int[])arr.Clone();

            // Sắp xếp mảng theo thứ tự giảm dần
            SelectionSortDescending(arr);
            Console.WriteLine("\nMảng sau khi sắp xếp theo thứ tự giảm dần là: ");
            PrintArray(arr);

            // Tìm phần tử lớn thứ hai trong mảng ban đầu
            int secondLargest = FindSecondLargest(originalArray);
            if (secondLargest != int.MinValue)
            {
                Console.WriteLine($"Phần tử lớn thứ hai trong mảng ban đầu là: phần tử '{secondLargest}' ");
            }
            else
            {
                Console.WriteLine($"Không có phần tử lớn thứ hai (có thể do mảng chỉ chứa một phần tử hoặc tất cả đều giống nhau).");
            }

            Console.ReadLine();
        }

        // Hàm tìm số phần tử giống nhau và trả về danh sách kết quả
        static List<string> FindDuplicateElements(int[] arr, int n)
        {
            List<string> results = new List<string>();
            bool[] isDuplicate = new bool[n]; // Mảng đánh dấu phần tử đã trùng lặp

            for (int i = 0; i < n; i++)
            {
                if (isDuplicate[i]) continue; // Bỏ qua nếu đã đánh dấu

                int count = 1; // Khởi tạo biến đếm cho phần tử hiện tại
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        count++;
                        isDuplicate[j] = true; // Đánh dấu phần tử đã được đếm
                    }
                }

                if (count > 1)
                {
                    results.Add($"Phần tử '{arr[i]}' xuất hiện {count} lần");
                    isDuplicate[i] = true; // Đánh dấu phần tử hiện tại đã được đếm
                }
            }

            return results;
        }

        // Hàm in các phần tử duy nhất trong mảng
        static void PrintUniqueElements(int[] arr, int n)
        {
            bool[] isDuplicate = new bool[n]; // Mảng đánh dấu phần tử đã trùng lặp

            // Đánh dấu các phần tử trùng lặp
            for (int i = 0; i < n; i++)
            {
                if (isDuplicate[i]) continue; // Bỏ qua nếu đã đánh dấu

                bool foundDuplicate = false; // Biến để kiểm tra nếu có phần tử trùng
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        isDuplicate[j] = true; // Đánh dấu phần tử trùng
                        foundDuplicate = true; // Đã tìm thấy phần tử trùng
                    }
                }

                if (!foundDuplicate) // Nếu không tìm thấy phần tử trùng
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }

        // Hàm sắp xếp mảng theo thứ tự giảm dần bằng Selection Sort
        static void SelectionSortDescending(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                // Giả định phần tử lớn nhất là phần tử đầu tiên trong phần chưa sắp xếp
                int maxIndex = i;

                // Tìm phần tử lớn nhất trong mảng còn lại
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] > arr[maxIndex])
                    {
                        maxIndex = j; // Cập nhật chỉ số phần tử lớn nhất
                    }
                }

                // Hoán đổi phần tử lớn nhất với phần tử đầu tiên trong phần chưa sắp xếp
                if (maxIndex != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[maxIndex];
                    arr[maxIndex] = temp;
                }
            }
        }

        // Hàm tìm phần tử lớn thứ hai trong mảng
        static int FindSecondLargest(int[] arr)
        {
            int largest = int.MinValue;
            int secondLargest = int.MinValue;

            foreach (int num in arr)
            {
                if (num > largest)
                {
                    secondLargest = largest;
                    largest = num;
                }
                else if (num > secondLargest && num != largest)
                {
                    secondLargest = num;
                }
            }

            return secondLargest;
        }

        // Hàm in mảng
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}
