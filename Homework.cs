using System;

namespace HomeWork4
{
    class Program
    {
      
            static void Main(string[] args)
            {
                int NumCity = int.Parse(Console.ReadLine());
                string[] name = new string[NumCity];
                for (int i = 0; i < NumCity; i++)
                {
                    Console.Write("NameCITY : ");
                    name[i] = Console.ReadLine();
                }
                int[,] s = new int[NumCity, NumCity];

                for (int x = 1; x < NumCity; x++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        Console.Write("On the way : ");
                        s[x, j] = int.Parse(Console.ReadLine());
                        s[j, x] = s[x, j];
                    }
                }
                string Lastname = Console.ReadLine();
                int[] Distances = DijkstraAlgo(s, 0, NumCity);
                Print(Distances, Lastname, name);

            }
            static int MiniMumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
            {
                int min = int.MaxValue;
                int minIndex = 0;

                for (int v = 0; v < verticesCount; ++v)
                {
                    if (shortestPathTreeSet[v] == false && distance[v] <= min)
                    {
                        min = distance[v];
                        minIndex = v;
                    }
                }

                return minIndex;
            }

            static void Print(int[] Distances, string Lastname, string[] name)
            {
                Console.WriteLine("Shot Distance:");

                for (int i = 0; i < name.Length; i++)
                {
                    if (Lastname == name[i])
                    {
                        Console.WriteLine(Distances[i]);
                        break;
                    }
                }

            }
            static int[] DijkstraAlgo(int[,] graph, int source, int verticesCount)
            {
                int[] distance = new int[verticesCount];
                bool[] shortestPathTreeSet = new bool[verticesCount];

                for (int i = 0; i < verticesCount; ++i)
                {
                    distance[i] = int.MaxValue;
                    shortestPathTreeSet[i] = false;
                }

                distance[source] = 0;

                for (int count = 0; count < verticesCount - 1; ++count)
                {
                    int u = MiniMumDistance(distance, shortestPathTreeSet, verticesCount);
                    shortestPathTreeSet[u] = true;

                    for (int v = 0; v < verticesCount; ++v)
                        if (!shortestPathTreeSet[v] && graph[u, v] != -1 && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                            distance[v] = distance[u] + graph[u, v];
                }
                return distance;
            }
        }
    
}
