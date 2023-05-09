using System;

namespace ScanlineMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int screenWidth = 40;
            int screenHeight = 20;
            char[,] screen = new char[screenHeight, screenWidth];

            // Definir los segmentos de los polígonos en la escena
            int[][] segments = new int[][] {
                new int[] { 10, 5, 30, 5 },
                new int[] { 30, 5, 30, 15 },
                new int[] { 30, 15, 10, 15 },
                new int[] { 10, 15, 10, 5 }
            };

            // Bucle principal del programa
            for (int y = 0; y < screenHeight; y++)
            {
                int[] activeSegments = new int[segments.Length];
                int activeSegmentCount = 0;

                // Encontrar segmentos activos
                for (int i = 0; i < segments.Length; i++)
                {
                    int x1 = segments[i][0];
                    int y1 = segments[i][1];
                    int x2 = segments[i][2];
                    int y2 = segments[i][3];

                    if ((y1 <= y && y < y2) || (y2 <= y && y < y1))
                    {
                        activeSegments[activeSegmentCount] = i;
                        activeSegmentCount++;
                    }
                }

                // Encontrar intersecciones y colorear los píxeles
                for (int i = 0; i < activeSegmentCount; i++)
                {
                    int currentSegment = activeSegments[i];
                    int x1 = segments[currentSegment][0];
                    int y1 = segments[currentSegment][1];
                    int x2 = segments[currentSegment][2];
                    int y2 = segments[currentSegment][3];

                    double x = x1 + ((double)(y - y1) / (y2 - y1)) * (x2 - x1);

                    for (int j = (int)x; j < screenWidth; j++)
                    {
                        screen[y, j] = '#';
                    }
                }
            }

            // Imprimir la imagen en la consola
            for (int y = 0; y < screenHeight; y++)
            {
                for (int x = 0; x < screenWidth; x++)
                {
                    Console.Write(screen[y, x]);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}

