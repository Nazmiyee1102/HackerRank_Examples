using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        int size = 3;
        int[,] grid = new int[3, 3]
        {
             { 0, 3, 8 },  
             { 4, 1, 7 },  
             { 2, 6, 5 }   
        };

        PrintGrid(grid, size);  // Başlangıç durumu

        Move(grid, size, "RIGHT");
        PrintGrid(grid, size);  // Sağ hamleden sonra durumu yazdır

        Move(grid, size, "DOWN");
        PrintGrid(grid, size);

                // Boş hücrenin (0) koordinatlarını bul
                (int x, int y) FindEmptyCell(int[,] grid, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        return (i, j);  // Boş hücrenin konumu (satır, sütun)
                    }
                }
            }
            return (-1, -1); // Bulunamazsa



        }

        bool Move(int[,] grid, int size, string direction)
        {
            // Boş hücreyi bul
            var (x, y) = FindEmptyCell(grid, size);

            if (direction == "UP" && x > 0)
            {
                // Yukarı hareket: Boş hücreyi yukarıdaki taş ile yer değiştir
                grid[x, y] = grid[x - 1, y];
                grid[x - 1, y] = 0;
                return true;
            }
            else if (direction == "DOWN" && x < size - 1)
            {
                // Aşağı hareket
                grid[x, y] = grid[x + 1, y];
                grid[x + 1, y] = 0;
                return true;
            }
            else if (direction == "LEFT" && y > 0)
            {
                // Sola hareket
                grid[x, y] = grid[x, y - 1];
                grid[x, y - 1] = 0;
                return true;
            }
            else if (direction == "RIGHT" && y < size - 1)
            {
                // Sağa hareket
                grid[x, y] = grid[x, y + 1];
                grid[x, y + 1] = 0;
                return true;
            }

            return false; // Geçersiz hamle

        }

        void PrintGrid(int[,] grid, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }


        }


    }
}